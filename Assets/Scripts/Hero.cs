using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Tooltip("Used for avoiding projectiles and enemys")]
    [SerializeField] private LayerMask enemyMask;
    [Tooltip("Max velocity for movement")]
    [SerializeField] private Vector2 maxVelocity;
    private Rigidbody2D myRigidbody2D;
    private BoxCollider2D myBoxCollider2d;
    [SerializeField] private Camera cam;
    // [SerializeField] private GameObject prefab;
    private Bounds cameraBounds;
    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2d = GetComponent<BoxCollider2D>();
        cameraBounds = new Bounds(cam.transform.position, new Vector3(cam.orthographicSize * ((float) cam.pixelWidth / (float) cam.pixelHeight) *2, cam.orthographicSize * 2));
        // Debug.Log("vboudns:" + cameraBounds);
        // Debug.Log(myBoxCollider2d.size);
    }
    private void Update()
    {
        AvoidDanger();
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
        //     position = new Vector3(position.x, position.y, 0f);
        //     Instantiate(prefab, position, Quaternion.identity);
        // }
    }
    private float DistanceToDanger(float xOffset)
    {
        Vector2 origin = new Vector2(transform.position.x + xOffset, transform.position.y + myBoxCollider2d.size.y / 2);
        // Debug.DrawRay(origin, Vector2.up, Color.red, 0.1f, false);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, myBoxCollider2d.size, 0f, Vector2.up, Mathf.Infinity, enemyMask);

        float distance = Mathf.Infinity;
        if (hits.Length > 0)
        {
            distance = hits[0].distance;
            foreach (RaycastHit2D hit in hits)
                if (hit.distance < distance)
                        distance = hit.distance;
        }
        return distance;
    }
    private void AvoidDanger()
    {
        const int left = 0, center = 1, right = 2;

        float[] distances = new float[3];
        float playerSizeX = myBoxCollider2d.size.x;

        for(int i = 0; i < 3; i++)
            distances[i] = DistanceToDanger((i - 1) * playerSizeX);

        // Debug.Log("Left: " + distances[left] + "Center: " + distances[center] + " Right: " + distances[right]);
    
        float playerMaxX = transform.position.x + playerSizeX;
        float playerMinX = transform.position.x - playerSizeX;

        if (playerMaxX >= cameraBounds.max.x)
            distances[right] = 0f;
        if (playerMinX <= cameraBounds.min.x)
            distances[left] = 0f;
        // Debug.Log("Left: " + distances[left] + "Center: " + distances[center] + " Right: " + distances[right]);

        int furthestIndex = center;
        float furthestDistance = distances[furthestIndex];
        for (int i = 0; i < 3; i++)
            if (distances[i] > furthestDistance)
            {
                furthestIndex = i;
                furthestDistance = distances[i];
            }
        

        // Debug.Log("Going:"+(furthestIndex-1));

        myRigidbody2D.velocity = new Vector2((furthestIndex - 1) * maxVelocity.x, myRigidbody2D.velocity.y);
    } 
}
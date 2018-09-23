using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Tooltip("Used for avoiding projectiles and enemys")]
    [SerializeField] private LayerMask enemyMask;
    [Tooltip("Max velocity for movement")]
    [SerializeField] private Vector2 maxVelocity;
    [SerializeField] private GameObject projectilePrefab;
    [Tooltip("Seconds between shots")]
    [SerializeField] private float fireRate;
    [SerializeField] private float initialProjectileSpeed;
    [SerializeField] private float minSafeDistanceToAttack;
    private GameObject boss;
    private Rigidbody2D myRigidbody2D;
    private BoxCollider2D myBoxCollider2d;
    private Bounds cameraBounds;
    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myBoxCollider2d = GetComponent<BoxCollider2D>();
        cameraBounds = new Bounds(Camera.main.transform.position, new Vector3(Camera.main.orthographicSize * ((float) Camera.main.pixelWidth / (float) Camera.main.pixelHeight) *2, Camera.main.orthographicSize * 2));
        InvokeRepeating("Fire", fireRate, fireRate);
        InvokeRepeating("AvoidDanger", 0.3f, 0.3f);
        boss = GameObject.Find("BossBody1V1");
    }
    private void FixedUpdate()
    {
    }
    private void Fire()
    {
		GameObject currentBullet = Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
		currentBullet.GetComponent<Rigidbody2D>().velocity =  Vector2.up * initialProjectileSpeed;
    }
    private float DistanceToDanger(float xOffset)
    {
        Vector2 origin = new Vector2(transform.position.x + xOffset, transform.position.y + myBoxCollider2d.size.y / 2);
        Debug.DrawRay(origin, Vector2.up, Color.red, 0.1f, false);
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

        Debug.Log("Left: " + distances[left] + "Center: " + distances[center] + " Right: " + distances[right]);
    
        float playerMaxX = transform.position.x + playerSizeX;
        float playerMinX = transform.position.x - playerSizeX;

        if (playerMaxX >= cameraBounds.max.x)
            distances[right] = 0f;
        if (playerMinX <= cameraBounds.min.x)
            distances[left] = 0f;
        Debug.Log("Left: " + distances[left] + "Center: " + distances[center] + " Right: " + distances[right]);

        int furthestIndex = center;
        float furthestDistance = distances[furthestIndex];
        int closestIndex = center;
        float closestDistance = distances[closestIndex];
        for (int i = 0; i < 3; i++)
        {
            if (distances[i] > furthestDistance)
            {
                furthestIndex = i;
                furthestDistance = distances[i];
            }
            if (distances[i] < closestDistance)
            {
                closestIndex = i;
                closestDistance = distances[i];
            }
        }


        Debug.Log("Going:"+(furthestIndex-1));
        if (closestDistance < minSafeDistanceToAttack)
            myRigidbody2D.velocity = new Vector2((furthestIndex - 1) * maxVelocity.x, myRigidbody2D.velocity.y);
        else
            AttackBoss();

    }
    private void AttackBoss()
    {
        if (boss.transform.position.x > transform.position.x)
            myRigidbody2D.velocity = new Vector2(maxVelocity.x, myRigidbody2D.velocity.y);
        else
            myRigidbody2D.velocity = new Vector2(-maxVelocity.x, myRigidbody2D.velocity.y);
    }
}
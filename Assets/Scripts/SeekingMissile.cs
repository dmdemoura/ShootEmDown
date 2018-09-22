using UnityEngine;

public class SeekingMissile : DamageOnHit
{
    [SerializeField] private float velocity;
    private Rigidbody2D myRigidBody2D;
    private GameObject target;
    private void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (target)
        {
            Debug.DrawLine(transform.position, target.transform.position, Color.red, 0.1f);
            Vector2 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
            myRigidBody2D.velocity = dir.normalized * velocity;
        }
        else
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(enemyTag);
            GameObject closest = null;
            float shortestDistance = Mathf.Infinity;
            foreach (GameObject obj in objs)
            {
                float dist = Mathf.Abs(Vector2.Distance(obj.transform.position, transform.position));
                if (dist < shortestDistance)
                {
                    closest = obj;
                    shortestDistance = dist;
                }
            }
            target = closest;
        }
    }
}
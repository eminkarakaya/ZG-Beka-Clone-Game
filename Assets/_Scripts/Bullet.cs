using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float explosionForce;
    public GameObject effect;
    public float speed;
    public Vector3 dir;
    public float r;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Ground")
        {
            Debug.Log("ground");
            var cols = Physics.OverlapSphere(transform.position, r);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce, transform.position, r, 1, ForceMode.Impulse);
                if(rb.TryGetComponent(out Health health))
                {
                    health.Hp -= damage;
                }
            }
        
        }
    }

    void Update()
    {
        transform.position += dir*Time.deltaTime*speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Gun raycast;
    public GameObject effect;
    public AudioClip fireExpSound;  
    // public static event System.Action bulletTrigger;
    public float explosionForce;
    public int damage;
    public float speed;
    public Vector3 dir;
    public float r;
    void Start()
    {
        raycast = GameObject.FindObjectOfType<Gun>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Ground")
        {
            BulletTrigger();
            
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
    public void BulletTrigger()
    {
        if(fireExpSound != null)
        {
            AudioSource.PlayClipAtPoint(fireExpSound,raycast.hit.point);
        }
        if(effect != null)
        {
            Instantiate(effect,raycast.hit.point,Quaternion.identity);
        }
    }
    void Update()
    {
        transform.position += dir*Time.deltaTime*speed;
    }
}

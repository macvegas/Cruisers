using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float lifeSpan;
    protected GameObject explosionEffect;
    protected GameObject splashEffect;
    // Start is called before the first frame update
    void Start()
    {
        //use CancelInvoke to stop
        Invoke("DestroyProjectile", lifeSpan);
        explosionEffect = Resources.Load("explosion") as GameObject;
        splashEffect = Resources.Load("waterSplash") as GameObject;
        //Debug.LogError(gameObject.name);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponentInParent<Boat>() != null || collision.collider.gameObject.GetComponentInChildren<Boat>() != null)
        {
            ParticleSystem ps = explosionEffect.GetComponent<ParticleSystem>();
            GameObject explosion = Instantiate(explosionEffect, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(splashEffect, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}

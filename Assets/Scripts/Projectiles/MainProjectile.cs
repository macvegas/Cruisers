using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    vanish = 0,
    explosion = 1,
    splash = 2,
    rebound = 3
}

public class MainProjectile : MonoBehaviour
{
    public float lifeSpan;
    public float speed;
    protected GameObject explosionEffect;
    protected GameObject splashEffect;
    private float damage;

    public float Damage { get => damage; set => damage = value; }

    void Start()
    {
        //use CancelInvoke to stop if needed
        Invoke("DestroyProjectile", lifeSpan);
        explosionEffect = GetEffectPrefab(EffectType.explosion);
        splashEffect = GetEffectPrefab(EffectType.splash);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Boat boat = collision.collider.gameObject.GetComponentInParent<Boat>() ?? collision.collider.gameObject.GetComponentInChildren<Boat>();
        //collisions with boats
        if (boat)
        {
            boat.TakeDamage(Damage);

            // explosion effect
            ParticleSystem ps = explosionEffect.GetComponent<ParticleSystem>();
            GameObject explosion = Instantiate(explosionEffect, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
        }
        //collisions with environment
        else
        {
            Instantiate(splashEffect, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    //Gets name of effects like : 
    public GameObject GetEffectPrefab(EffectType effectName)
    {
        string className = this.GetType().Name;
        GameObject effect = Resources.Load(className + "_" + effectName) as GameObject;
        return effect;
    }
}

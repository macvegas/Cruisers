using System;
using UnityEngine;

public class BoatShootProjectiles : MonoBehaviour
{
    [SerializeField] private GameObject pfCanonBall;

    private void Awake()
    {
        GetComponent<Boat>().OnShoot += BoatShootProjectile_OnShoot;
    }

    private void BoatShootProjectile_OnShoot(object sender, Boat.OnShootEventArgs e)
    {
        Debug.Log("Shots fired!");
        //Shoot
        GameObject projectile = Instantiate(pfCanonBall, e.canonPosition, Quaternion.identity);

        Vector3 shootDir = e.shootDirection;
        Debug.Log("shootposition: x=" + e.shootDirection.x + " y=" + e.shootDirection.y);
        projectile.GetComponent<CanonBall>().Setup(shootDir);
        projectile.GetComponent<Rigidbody>().velocity = e.projectileVelocity;
    }
}

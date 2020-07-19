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
        GameObject projectileTransform = Instantiate(pfCanonBall, e.canonPosition, Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.canonPosition).normalized;
        projectileTransform.GetComponent<CanonBall>().Setup(shootDir);
    }
}

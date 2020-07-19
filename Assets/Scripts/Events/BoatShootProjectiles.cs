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
        Debug.Log("Shoot Direction: x=" + shootDir.x + "y=" + shootDir.y + "z=" + shootDir.z);
        Debug.Log("mouse position: x=" + e.shootPosition.normalized.x + "y=" + e.shootPosition.normalized.y + "z=" + e.shootPosition.z);
        projectileTransform.GetComponent<CanonBall>().Setup(shootDir);
    }
}

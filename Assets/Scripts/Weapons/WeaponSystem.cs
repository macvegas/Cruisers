using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponOrientation : ushort
    {
        Forward = 0,
        Left = 1,
        Right = 2,
        Back = 3,
        Sides= 4
    }
public abstract class WeaponSystem : MonoBehaviour
{
    protected GameObject projectilePrefab;
    protected WeaponOrientation shootingDirection;

    protected Boat boat;
    protected string weaponName;
    public float damagePerProjectile;
    public float coolDownTime;
    public bool canShoot = true;

    protected virtual void Start()
    {
        boat = GetComponent<Boat>();
        
        LoadPrefab();
    }
    
    public void LoadPrefab()
    {
        
        string className = this.GetType().Name;
        projectilePrefab = Resources.Load(className + "_ProjPrefab") as GameObject;
    }
    
    // Takes all the shootingpoints of the boat and makes them instanciate the projectile
    public void Fire(WeaponOrientation _shootingDirection)
    {
        List<Transform> shootingPoints = GetShootingPoints(_shootingDirection);
        foreach (Transform shootPoint in shootingPoints)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            projectile.name = projectilePrefab.name;
            projectile.GetComponent<MainProjectile>().Damage = damagePerProjectile;
            // ignores collision with shooter
            foreach (Collider col in boat.GetBoatColliders())
            {
                Physics.IgnoreCollision(projectile.GetComponent<Collider>(), col);
            }

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = shootPoint.forward * projectile.GetComponent<MainProjectile>().speed;
            
        }
    }

    public void Fire()
    {
        WeaponOrientation effectiveDirection = shootingDirection;
        if (shootingDirection == WeaponOrientation.Sides)
        {
            Vector3 boatPositionOnScreen = boat.CameraPlayer.WorldToScreenPoint(boat.transform.position);
            Vector3 boatForwardPosition = boat.CameraPlayer.WorldToScreenPoint(boat.transform.position + boat.transform.forward);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            Vector3 boatOrientationVector = boatForwardPosition - boatPositionOnScreen;
            Vector3 mouseVector = mousePosition - boatPositionOnScreen;

            Vector3 result = Vector3.Cross(boatOrientationVector, mouseVector).normalized;

            if (result.z > 0)
            {
                effectiveDirection = WeaponOrientation.Left;
            }
            else
            {
                effectiveDirection = WeaponOrientation.Right;
            }
            
        }
        Fire(effectiveDirection);
    }

    private List<Transform> GetShootingPoints(WeaponOrientation shootingDirection)
    {
        
        return boat.GetShootingPoints(shootingDirection);
    }
}

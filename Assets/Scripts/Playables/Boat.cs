using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Boat : MainPlayableEntity
{
    /******************************************************************
     * TEMPORARY VALUES FOR TESTS --> TO GIVE TO ACTUAL BOATS AFTER
     ******************************************************************/
    public float Speed=1;
    public float RotationSpeed=1;
    public float Size=1;

    /*******************************************************************
     *******************************************************************
     *******************************************************************/
    public HealthBar healthBar;
    private float maxHealth = 100;
    private float currentHealth;


    //public event EventHandler<OnShootEventArgs> OnShoot;

    public Camera CameraPlayer;

    /********************************************************************
     ********************* GETTERS / SETTERS ****************************
     ********************************************************************/
    public float MaxHealth
    {
        get => maxHealth;
        set{
            if (maxHealth == value)
            {
                return;
            }
            maxHealth = value;
            healthBar.SetMaxHealth(value);
        }
    }
    public float CurrentHealth { get => currentHealth;
        set
        {
            if (currentHealth == value || value <  0)
            {
                return;
            }
            currentHealth = value;
            healthBar.SetCurrentHealth(value);
        }
    }

    public List<Transform> GetShootingPoints(WeaponOrientation shootingDirection)
    {
        List<Transform> shootingPointsList = new List<Transform>();
        foreach (ShootingPoint point in GetComponentsInChildren<ShootingPoint>())
        {
            if (point.orientation == shootingDirection)
            {
                shootingPointsList.Add(point.gameObject.transform);
            }
        }
        return shootingPointsList;
    }


    void Update()
    {
    }

    private void LateUpdate()
    {
    }



    public override void Move(float horizontal, float vertical)
    {
        Vector3 move = new Vector3(0, 0, vertical);
        gameObject.transform.Translate(0, 0, vertical*Speed*Time.deltaTime);
        gameObject.transform.Rotate(0, horizontal * RotationSpeed * Time.deltaTime, 0);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    public void Die()
    {

    }

    public void Shoot(WeaponSystem weapon)
    {
        weapon.Fire();
    }

    public void Cast(Ability ability)
    {
        ability.Cast();
    }

    public List<Collider> GetBoatColliders()
    {
        Collider[] liste = GetComponentsInChildren<Collider>();
        return new List<Collider>(liste);
    }

    

    
}

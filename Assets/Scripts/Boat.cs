using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Boat : MonoBehaviour
{
    /******************************************************************
     * TEMPORARY VALUES FOR TESTS --> TO GIVE TO ACTUAL BOATS AFTER
     ******************************************************************/
    private float currentHealth;
    public float Speed=1;
    public float RotationSpeed=1;
    public float Size=1;

    /*******************************************************************
     *******************************************************************
     *******************************************************************/
    public HealthBar healthBar;
    private float maxHealth = 100;
    public List<Ability> abilities;
    public List<Weapon> weapons = new List<Weapon>();

    //
    public WeaponSystem sideCanons;
    //
    private Weapon selectedWeapon;
    protected Ability selectedAbility;

    public event EventHandler<OnShootEventArgs> OnShoot;

    public Camera CameraPlayer;

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

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 canonPosition;
        public Vector3 shootDirection;
        public Vector3 projectileVelocity;
    }

    protected virtual void Start()
    {
        //
        //MaxHealth = 100;
        //
        //CurrentHealth = MaxHealth;
        if (abilities.Count != 0)
        {
            selectedAbility = abilities[0];
        }
        if (weapons.Count != 0)
        {
            selectedWeapon= weapons[0];
        }
    }

    void Update()
    {
        ////handle movement
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        
        //if (x!=0 || y!=0 )
        //{
        //    Move(x,y);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    OnShoot?.Invoke(this, new OnShootEventArgs { 
        //        canonPosition = gameObject.transform.position + gameObject.transform.forward*10,
        //        shootDirection = gameObject.transform.position + getShootDir() + gameObject.transform.up * selectedWeapon.projectileAngle, 
        //        projectileVelocity = getShootDir() * selectedWeapon.projectileSpeed});
        //}

        ////handle ability cast
        //if (Input.GetKeyDown("space"))
        //{
        //    selectedAbility.Cast();
        //}

        //if (Input.GetKeyDown("f"))
        //{
        //    TakeDamage(10);
        //}
        //if (Input.GetKeyDown("r"))
        //{
        //    sideCanons.Shoot();
        //}
    }

    private void LateUpdate()
    {
        //if (MaxHealth != healthBar.slider.maxValue)
        //{
        //    healthBar.SetMaxHealth(MaxHealth);
        //}
        //if (CurrentHealth != healthBar.slider.value)
        //{
        //    healthBar.SetCurrentHealth(CurrentHealth);
        //}
    }



    public void Move(float horizontal, float vertical)
    {
        Vector3 move = new Vector3(0, 0, vertical);
        gameObject.transform.Translate(0, 0, vertical*Speed*Time.deltaTime);
        gameObject.transform.Rotate(0, horizontal * RotationSpeed * Time.deltaTime, 0);
    }

    private Vector3 getShootDir()
    {
        Vector3 shootDir;
        switch (selectedWeapon.direction)
        {
            case Weapon.WeaponDirEnum.Forward:
                shootDir = gameObject.transform.forward;
                break;
            case Weapon.WeaponDirEnum.Left:
                shootDir = -gameObject.transform.right;
                break;
            case Weapon.WeaponDirEnum.Right:
                shootDir = gameObject.transform.right;
                break;
            case Weapon.WeaponDirEnum.Back:
                shootDir = -gameObject.transform.forward;
                break;
            default:
                //Exception mauvaise dir
                Debug.LogError("Direction non definie pour l'arme");
                shootDir = gameObject.transform.forward;
                break;
        }
        return shootDir;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    public List<Collider> GetBoatColliders()
    {
        Collider[] liste = GetComponentsInChildren<Collider>();
        return new List<Collider>(liste);
    }
}

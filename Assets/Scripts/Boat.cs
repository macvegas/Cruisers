using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Boat : MonoBehaviour
{
    
    public float Health=100;
    public float Speed=1;
    public float RotationSpeed=1;
    public float Size=1;
    public List<Ability> abilities;
    public List<Weapon> weapons = new List<Weapon>();

    private Weapon selectedWeapon;
    private Ability selectedAbility;

    public event EventHandler<OnShootEventArgs> OnShoot;

    private Camera cam;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 canonPosition;
        public Vector3 shootDirection;
        public Vector3 projectileVelocity;
    }

    void Start()
    {
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
        //handle movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        if (x!=0 || y!=0 )
        {
            Move(x,y);
        }
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke(this, new OnShootEventArgs { 
                canonPosition = gameObject.transform.position + gameObject.transform.forward*10,
                shootDirection = gameObject.transform.position + getShootDir() + gameObject.transform.up * selectedWeapon.projectileAngle, 
                projectileVelocity = getShootDir() * selectedWeapon.projectileSpeed});
        }

        //handle ability cast
        if (Input.GetKeyDown("space"))
        {
            selectedAbility.Cast();
        }
    }

    private void Move(float horizontal, float vertical)
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
}

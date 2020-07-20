using System;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    
    public float Health;
    public float Speed=1;
    public float RotationSpeed=1;
    public float Size;
    public List<Ability> abilities;
    public List<Weapon> weapons = new List<Weapon>();

    private Weapon selectedWeapon;
    private Ability selectedAbility;

    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 canonPosition;
        public Vector3 shootPosition;
    }

    void Start()
    {
        if (abilities.Count != 0)
        {
            selectedAbility = abilities[0];
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
            OnShoot?.Invoke(this, new OnShootEventArgs { canonPosition = gameObject.transform.position + new Vector3(0, 0, 1f), shootPosition = Input.mousePosition});
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
}

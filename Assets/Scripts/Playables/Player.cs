using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MainPlayer
{
    SideCanons sideCanons = new SideCanons();
    
    public WeaponSystem GetSelectedWeapon()
    {
        return sideCanons;
    }

    public void Shoot()
    {
        if (boat.GetWeapons().Count > 0)
        {
            boat.Shoot(GetSelectedWeapon());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //handle movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
           boat.Move(x, y);
        }

        //handle ability cast
        if (Input.GetKeyDown("space"))
        {
            //boat.selectedAbility.Cast();
        }

        
        if (Input.GetKeyDown("r"))
        {
            Shoot();
        }
    }
}

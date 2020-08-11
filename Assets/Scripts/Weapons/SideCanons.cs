using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCanons : WeaponSystem
{
    // Start is called before the first frame update
    protected override void Start()
    {
        shootingDirection = WeaponOrientation.Sides;
        base.Start();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}

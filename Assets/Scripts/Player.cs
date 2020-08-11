using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableEntity
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //handle movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            Move(x, y);
        }

        //handle ability cast
        if (Input.GetKeyDown("space"))
        {
            selectedAbility.Cast();
        }

        if (Input.GetKeyDown("f"))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown("r"))
        {
            sideCanons.Shoot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    
    public float Health;
    public float Speed=1;
    public float RotationSpeed=1;
    public float Size;
    public Ability[] abilities;
    public Weapon[] weapons;

    private Weapon selectedWeapon;

    void Start()
    {
        //selectedWeapon = weapons[0];

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
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 move = new Vector3(0, 0, vertical);
        gameObject.transform.Translate(0, 0, vertical*Speed*Time.deltaTime);
        gameObject.transform.Rotate(0, horizontal * RotationSpeed * Time.deltaTime, 0);
    }
}

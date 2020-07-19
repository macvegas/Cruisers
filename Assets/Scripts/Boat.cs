using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    
    public float Health;
    public float Speed;
    public float RotationSpeed;
    public float Size;
    public Ability[] abilities;
    public Weapon[] weapons;

    private CharacterController controller;
    private Weapon selectedWeapon;

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        selectedWeapon = weapons[0];

    }

    void Update()
    {
        //handle movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero )
        {
            Move(move);
        }
    }

    private void Move(Vector3 movement)
    {
        controller.Move(movement * Time.deltaTime * Speed);
    }
}

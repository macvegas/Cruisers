using System;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    
    public float Health;
    public float Speed;
    public float RotationSpeed;
    public float Size;
    public Ability[] abilities;
    public List<Weapon> weapons = new List<Weapon>();

    private CharacterController controller;
    private Weapon selectedWeapon;

    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 canonPosition;
        public Vector3 shootPosition;
    }

    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        //handle movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero )
        {
            Move(move);
        }
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke(this, new OnShootEventArgs { canonPosition = gameObject.transform.position + new Vector3(0, 0, 1f), shootPosition = Input.mousePosition});
        }
    }

    private void Move(Vector3 movement)
    {
        controller.Move(movement * Time.deltaTime * Speed);
    }
}

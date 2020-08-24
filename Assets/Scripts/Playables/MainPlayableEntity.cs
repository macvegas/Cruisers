using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainPlayableEntity : MonoBehaviour
{

    private List<Ability> abilities = new List<Ability>();
    private List<WeaponSystem> weapons = new List<WeaponSystem>();

    public List<Ability> GetAbilities()
    {
        return abilities;
    }

    public List<WeaponSystem> GetWeapons()
    {
        return weapons;
    }

    public void AddWeapon(WeaponSystem weapon)
    {
        weapons.Add(weapon);
    }

    public void RemoveWeapon(WeaponSystem weapon)
    {
        weapons.Remove(weapon);
    }


    public abstract void Move(float horizontal, float vertical);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float damage;
    public float cooldown;
    

    public abstract void Cast();
}

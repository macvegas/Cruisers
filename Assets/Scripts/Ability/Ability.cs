using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float damage;
    public float cooldown;
    protected bool canCast = true;
    

    public abstract void Cast();

    protected IEnumerator CooldownTimer()
    {
        canCast = false;
        float time = 0f;
        while (time < cooldown)
        {
            time += Time.deltaTime;
            yield return null;
        }
        canCast = true;
    }
}

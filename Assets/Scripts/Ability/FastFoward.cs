using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoward : Ability
{
    public float executionTime = 0.35f;
    public float pushMultiplicator = 15f;
    GameObject target;
    public override void Cast()
    {
        target = gameObject;

        //  SUPPOSED to get list of visible boats and pushes it forward
        //target.transform.Translate(target.transform.forward * pushMultiplicator);
        if (canCast)
        {
            StartCoroutine(PushForward(target.transform.forward));
            StartCoroutine(CooldownTimer());
        }
        
    }

    private IEnumerator PushForward(Vector3 direction)
    {
        float time = 0f;
        while (time<executionTime)
        {
            time += Time.deltaTime;
            target.transform.position += direction * Time.deltaTime * pushMultiplicator;
            yield return null;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

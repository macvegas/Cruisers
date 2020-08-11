using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : PlayableEntity
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move(0.75f, 1f);
    }
}

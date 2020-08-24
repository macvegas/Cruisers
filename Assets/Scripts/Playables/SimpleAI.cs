using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MainPlayer
{

    // Update is called once per frame
    void Update()
    {
        boat.Move(0.75f, 1f);
    }
}

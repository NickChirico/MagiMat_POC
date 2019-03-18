using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneMaterial : MaterialClass
{   
    public override void Attack()
    {
        Debug.Log("Basic Attack");
    }

    public override void Special()
    {
        Debug.Log("No Basic Special");
    }
}


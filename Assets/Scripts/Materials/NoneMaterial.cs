using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneMaterial : MaterialClass
{   
    public override void Attack(GameObject player)
    {
        Debug.Log("Basic Attack");
    }

    public override void Special(GameObject player)
    {
        Debug.Log("No Basic Special");
    }
}


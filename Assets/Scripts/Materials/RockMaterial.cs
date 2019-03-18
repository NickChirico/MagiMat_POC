using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMaterial : MaterialClass
{
    public override void Attack()
    {
        Debug.Log("Rock Attack");
    }

    public override void Special()
    {
        Debug.Log("Rock Special");
    }
}

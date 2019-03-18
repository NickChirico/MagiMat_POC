using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineMaterial : MaterialClass
{
    public override void Attack()
    {
        Debug.Log("Vine Attack");
    }

    public override void Special()
    {
        Debug.Log("Vine Special");
    }
}

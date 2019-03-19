using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineMaterial : MaterialClass
{
    public override void Attack(GameObject player)
    {
        Debug.Log("Vine Attack");
    }

    public override void Special(GameObject player)
    {
        Debug.Log("Vine Special");
    }
}

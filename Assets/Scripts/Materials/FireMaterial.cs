using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMaterial : MaterialClass
{
    public override void Attack(GameObject player)
    {
        Debug.Log("Fire Attack");
    }

    public override void Special(GameObject player)
    {
        Debug.Log("Fire Special");
    }
}

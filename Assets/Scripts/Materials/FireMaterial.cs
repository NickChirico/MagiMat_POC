using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMaterial : MaterialClass
{
    public override void Attack()
    {
        Debug.Log("Fire Attack");
    }

    public override void Special()
    {
        Debug.Log("Fire Special");
    }
}

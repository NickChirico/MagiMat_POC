using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMaterial : MaterialClass
{
    public override void Attack(GameObject player)
    {
        Debug.Log("Rock Attack");
    }

    public override void Special(GameObject player)
    {
        Debug.Log("Rock Special");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Material
{
    None,
    Vine,
    Fire,
    Stone
}

public abstract class MaterialClass : MonoBehaviour
{
    public Material material;
    
    protected virtual void Attack()
    {
        
    }

    protected virtual void Special()
    {
        
    } 
}

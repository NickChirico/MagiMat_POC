using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Material
{
    public abstract void DebugName();

    public abstract void ChangeAttack();

}

public class NoMaterial : Material
{
    public override void DebugName()
    {
        Debug.Log("None");
    }

    public override void ChangeAttack()
    {
    }
}

public class Vine : Material
{
    public override void DebugName()
    {
        Debug.Log("VINE");
    }
    
    public override void ChangeAttack()
    {
    }
}

public class Fire : Material
{
    public override void DebugName()
    {
        Debug.Log("Fire");
    }
    
    public override void ChangeAttack()
    {
    }
}

public class Rock : Material
{
    public override void DebugName()
    {
        Debug.Log("Rock");
    }
    
    public override void ChangeAttack()
    {
    }
}

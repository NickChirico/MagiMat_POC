using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Services
{
    public static MaterialManager MatManager;

    public static Vine _Vine;
    public static Fire _Fire;
    public static Rock _Rock;
    public static NoMaterial None;

    public static void InstanciateMats()
    {
        _Vine = new Vine();
        _Fire = new Fire();
        _Rock = new Rock();
        None = new NoMaterial();
    }
}

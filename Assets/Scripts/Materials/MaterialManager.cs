using System.Collections;
using UnityEngine;

// This will manage what current material the player is using

/*public enum CurrentMaterial : int
{
    None = 0,
    Vine = 1,
    Fire = 2,
    Rock = 3
};*/

public class MaterialManager : MonoBehaviour
{
    public Material ActiveMaterial;

    private void Awake()
    {
        Services.InstanciateMats();

        ActiveMaterial = Services.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            EquipVine();
        }
    }

    private void UnequipMaterial()
    {
        ActiveMaterial = Services.None;
    }
    
    private void EquipVine()
    {
        ActiveMaterial = Services._Vine;
    }
    
    private void EquipFire()
    {
        ActiveMaterial = Services._Fire;
    }
    
    private void EquipRock()
    {
        ActiveMaterial = Services._Rock;
    }
}

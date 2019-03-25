using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MaterialsManager : MonoBehaviour
{
    public static MaterialsManager instance;
    
    //this dictionary will hold the player actions for each material
    //the key is a material enum and the value is a reference to the material script
    //use methods below to access the dictionary
    public static Dictionary<Material, MaterialClass> MaterialsDict = new Dictionary<Material, MaterialClass>();

    void Awake()
    {
        instance = this;
    }
    
    public static void AddMaterialScript(Material material, MaterialClass script)
    {
        //if the dictionary does not already contain this material, add the material and its script
        if (!MaterialsDict.ContainsKey(material))
        {
            MaterialsDict.Add(material, script);
        }
    }

    public static MaterialClass GetMaterialScript(Material material)
    {
        //take material enum as parameter and return reference to its script
        MaterialsDict.TryGetValue(material, out MaterialClass newMaterialScript);
        return newMaterialScript;
    }
}

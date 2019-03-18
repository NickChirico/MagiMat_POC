﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stores references to all player scripts
//store player's active material?

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] public static PlayerManager instance;
    
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public PlayerActions playerActions;

    [HideInInspector] public Material material;
    [HideInInspector] public MaterialClass materialScript;

    void Awake()
    {
        instance = this;
        
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerActions = GetComponent<PlayerActions>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        material = newMaterial;
        MaterialsManager.MaterialsDict.TryGetValue(material, out MaterialClass newMaterialScript);
        materialScript = newMaterialScript;
        
        Debug.Log("New Material: " + material);
    }
    
    public void Death()
    {
        playerMovement.enabled = false;
        playerHealth.enabled = false;
        playerActions.enabled = false;
    }
}

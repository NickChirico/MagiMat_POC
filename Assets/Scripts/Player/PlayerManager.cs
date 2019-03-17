using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stores references to all player scripts
//store player's active material?

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public PlayerActions playerActions;

    public Material material;
    public MaterialClass materialScript;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerActions = GetComponent<PlayerActions>();
    }

    public void Death()
    {
        playerMovement.enabled = false;
        playerHealth.enabled = false;
        playerActions.enabled = false;
    }
}

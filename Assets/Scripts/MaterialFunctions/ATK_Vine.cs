using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to the prefab for the Vine Attack hitbox/collider

public class ATK_Vine : MonoBehaviour
{
    private Vector2 playerLoc;
    private Vector2 activeLoc;

    public float SpawnOffset;
    
    void Update()
    {
        playerLoc = PlayerManager.instance.transform.position;
        Debug.Log(playerLoc);


        if (PlayerManager.instance.GetComponent<PlayerMovement>().FacingRight)
        {
            activeLoc = playerLoc + new Vector2(SpawnOffset, 0);
        }
        else
        {
            activeLoc = playerLoc + new Vector2(-SpawnOffset, 0);
        }
        
        this.transform.position = activeLoc;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            // ATTACK HIT ENEMY
            //    Call enemy Damage(), etc
        }
    }
}

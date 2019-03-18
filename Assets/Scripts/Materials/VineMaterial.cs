using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


// Houses the specific functionality for the moves/abilities associated with the Vine Material

public class VineMaterial : MaterialClass
{
    public GameObject VineSpecialObject;
    
    public GameObject VineObject;
    public float AttackDelay_sec;

    private Vector2 spawnPos;
    private GameObject _player;
    
    public override void Attack(GameObject player)
    {
        _player = player;
        Debug.Log("Vine Attack");
        
        if (player.GetComponent<PlayerMovement>()._isGrounded)
        {
            StartCoroutine(CreateAttack(AttackDelay_sec));
        }
    }

    public override void Special(GameObject player)
    {
        Debug.Log("Vine Special");
        
        Instantiate(VineSpecialObject, this.transform.position, Quaternion.Euler(new Vector2(0,0)));
    }
    

    // Spawns the Vine Attack prefab and dampens player movement during attack duration
    IEnumerator CreateAttack(float seconds)
    {
        //dampen player movement during attack
        PlayerMovement move = _player.GetComponent<PlayerMovement>();
        float startSpeed = move.acceleration;
        move.acceleration = -1*(startSpeed / 8);
        
        // wait before spawning attack prefab
        yield return new WaitForSeconds(seconds);
        Instantiate(VineObject, this.transform.position, Quaternion.identity);
        
        // wait before returning player movement to normal
        yield return new WaitForSeconds(0.35f);
        move.acceleration = startSpeed;
    }
}

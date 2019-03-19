using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMaterial : MaterialClass
{
    public float specialDashDistance;
    public float specialDashTime;
    
    public override void Attack(GameObject player)
    {
        Debug.Log("Fire Attack");
    }

    public override void Special(GameObject player)
    {
        Debug.Log("Fire Special");

        Vector3 direction = GlobalFunctions.FaceDirectionToVector2(PlayerManager.instance.playerMovement.faceDirection);

        StartCoroutine(FireSpecial(player, direction));
    }

    IEnumerator FireSpecial(GameObject player, Vector3 direction)
    {
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Enemies"), true);
        
        Vector2 velocity = playerRB.velocity;
        velocity.y = 0;
        playerRB.velocity = velocity;

        int upper = Mathf.RoundToInt(specialDashTime / 0.01f);
        for (int i = 0; i < upper; i++)
        {
            playerRB.MovePosition(player.transform.position + (direction * specialDashDistance/upper));
            yield return new WaitForSeconds(0.01f);
        }
        
        Physics2D.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Enemies"), false);
    }
}

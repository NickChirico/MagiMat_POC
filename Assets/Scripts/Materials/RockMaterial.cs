using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMaterial : MaterialClass
{
    [Header("Attack")] 
    public float attackDamage;
    public float attackMoveSpeed;
    public Vector2 attackOffset; //distance between the center of the hurt box and the player
    public bool attackHitMultipleTargets;
    public Vector2 attackSize; //size of hurt box assuming the attack is directed left or right
    public GameObject hurtBoxPrefab;

    [Header("Special")] 
    public float specialRadius; //radius around the player where the projectiles will spawn
    public int numberOfProjectiles; //how many projectiles spawn, they will always be equally spaced around the player
    public float projectileSpeed;
    public GameObject projectilePrefab;

    public override void Attack(GameObject player)
    {
        //sends a seismic/rock wave forward from the player
        //player must be grounded and the attack only travels on ground
        Debug.Log("Rock Attack");
        //get the player's direction
        int attackDirection = PlayerManager.instance.playerMovement.faceDirection;
        //only attack if the player is currently grounded
        if (PlayerManager.instance.playerMovement.isGrounded)
        {
            //attack can only go left or right
            if (attackDirection == 2 || attackDirection == 4)
            {
                //get V2 of attackDirection
                Vector2 attackDirectionV2 = GlobalFunctions.FaceDirectionToVector2(attackDirection);

                //set offset based off of offset values and the direction of the attack
                Vector3 directionalOffset = Vector2.zero;
                directionalOffset.x = attackOffset.x * attackDirectionV2.x;
                directionalOffset.y = attackOffset.y;

                //instantiate rock attack prefab which is a moving hurt box
                GameObject hurtBox = Instantiate(hurtBoxPrefab, player.transform.position + directionalOffset, Quaternion.identity);
                RockAttackHurtBox hbScript = hurtBox.GetComponent<RockAttackHurtBox>();

                //set hurt box's size and values
                hbScript._spriteRenderer.size = attackSize;
                hbScript._boxCollider.size = attackSize;
                hbScript.damage = attackDamage;
                hbScript.hitMultipleTargets = attackHitMultipleTargets;

                //values specific to the moving hurt box
                hbScript.speed = attackMoveSpeed;
                hbScript.direction = attackDirectionV2;
            }
        }
    }

    public override void Special(GameObject player)
    {
        //shoot rock projectiles in all directions
        Debug.Log("Rock Special");
        //based on the number of projectiles that should be spawned, determine the angle in radians between each projectile
        float radiansBetweenOrbiters = (360 * Mathf.Deg2Rad) / numberOfProjectiles;

        //do for each projectile
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            //radians tracks what angle from the player each projectile should spawn at
            float radians = i * radiansBetweenOrbiters;
            Vector2 playerPos = player.transform.position;
            //get a normalized vector2 of the angle from the player that the projectile should spawn
            //multiply this vector by the radius to find the final spawn position
            Vector2 spawnOffset = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * specialRadius;
            Vector2 spawnPosition = playerPos + spawnOffset;

            //instantiate the projectile
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity, this.transform);
            Rigidbody2D projRB = projectile.GetComponent<Rigidbody2D>();
            //give the projectile a velocity in the same direction as its direction from the player
            projRB.velocity = spawnOffset.normalized * projectileSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttackHurtBox : MovingHurtBox
{
    public float raycastDistance; //raycast distance for ground check
    public LayerMask groundLayers; //layers that are considered ground layers
    
    protected override void Update()
    {
        base.Update();
        //if the hurt box is no longer on top of ground, destroy it
        if (!CheckGrounded())
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual bool CheckGrounded()
    {
        //check whether or not the hurt box is above ground
        return Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayers);
    }
}

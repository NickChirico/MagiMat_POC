using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSpecialObject : MonoBehaviour
{
    GameObject player;

    private Vector3 trajectory;

    private bool isFlying;
    private bool JointEnabled;

    public float GrappleStep;

    public float MinGrappleDist;

    DistanceJoint2D joint;

    private void Start()
    {
        player = PlayerManager.instance.gameObject;
        trajectory.x = player.GetComponent<PlayerMovement>().InputVector.x;    
        trajectory.y = player.GetComponent<PlayerMovement>().InputVector.y;
        trajectory.z = 0;

        isFlying = true;
        JointEnabled = false;
        
        joint = player.gameObject.GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if(isFlying)
            this.transform.position += trajectory*0.15f;
        else
        {
        }

        if (joint.enabled)
        {
            if (joint.distance > MinGrappleDist)
            {
                joint.distance -= GrappleStep;
            }
            else
            {
                joint.enabled = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        isFlying = false;
        

        

        if (coll != null && coll.gameObject.GetComponent<Rigidbody2D>() != null)
            
        {
            Debug.Log("CONTACT");

            joint.enabled = true;
            joint.connectedBody = coll.gameObject.GetComponent<Rigidbody2D>();
            joint.connectedAnchor =
                coll.transform.position - new Vector3(coll.transform.position.x, coll.transform.position.y, 0);
            joint.distance = Vector2.Distance(player.transform.position, coll.transform.position);
        }



    }
}

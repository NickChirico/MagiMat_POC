using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSpecialObject : MonoBehaviour
{
    GameObject player;

    private Vector2 trajectory;
    
    private void Start()
    {
        player = PlayerManager.instance.gameObject;
        trajectory = player.GetComponent<PlayerMovement>().InputVector;    
        
    }

    private void Update()
    {
        /*DistanceJoint2D joint;
        joint = player.gameObject.GetComponent<DistanceJoint2D>();

        Vector3 targetPos = player.GetComponent<PlayerMovement>().InputVector * 8; //*range
        targetPos.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, targetPos - player.transform.position, 10f);
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            joint.enabled = true;
            joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            joint.connectedAnchor =
                hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
            joint.distance = Vector2.Distance(player.transform.position, hit.point);


        }*/

        //this.transform.position = 
    }
}

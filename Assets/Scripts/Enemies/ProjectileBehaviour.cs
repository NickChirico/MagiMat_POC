using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehaviour : MonoBehaviour
{
    [HideInInspector] public static Transform _Player;
    [HideInInspector] public Vector3 _TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.Find("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class FireToadFireball : ProjectileBehaviour
{
    private float FireballSpeed = 10;
    void Start()
    {
        _TargetPos = _Player.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _TargetPos, FireballSpeed*Time.deltaTime);
        if (transform.position == _TargetPos)
        {         
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

}

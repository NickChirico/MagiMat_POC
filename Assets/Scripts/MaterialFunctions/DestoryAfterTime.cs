using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterTime : MonoBehaviour
{
    public float Seconds;
    
    void Start()
    {
        StartCoroutine(countdown(Seconds));
    }

    IEnumerator countdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}

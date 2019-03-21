﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAbsorberProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float maxDistance;
    private float _distanceTravelled;

    public PlayerActions playerActionScript;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _distanceTravelled += _rigidbody2D.velocity.magnitude * Time.deltaTime;
        if (_distanceTravelled >= maxDistance)
        {
            DestroySelf();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        
        if (other.CompareTag("Enemy"))
        {
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                if (enemyScript.material != Material.None)
                {
                    PlayerManager.instance.ChangeMaterial(enemyScript.material);
                }
            }
        } 
        else if (other.CompareTag("MaterialSource"))
        {
            MaterialSource materialSourceScript = other.GetComponent<MaterialSource>();
            if (materialSourceScript != null)
            {
                if (materialSourceScript.material != Material.None)
                {
                    PlayerManager.instance.ChangeMaterial(materialSourceScript.material);
                }
            }
        }

        DestroySelf();
    }

    private void DestroySelf()
    {
        playerActionScript.materialAbsorberOut = false;
        Destroy(this.gameObject);  
    }
}

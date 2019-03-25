﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAbsorberProjectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public float maxDistance;
    private float _distanceTravelled;

    public GameObject particlePrefab;
    public int particleAmount;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //track how far the projectile has moved so far
        //when the projectile reaches its max distance, destroy it
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
            //do nothing when hitting the player
            //return so the projectile is not destroyed
            return;
        }
        
        if (other.CompareTag("Enemy"))
        {
            //on collision with an enemy, take the material from the enemy script
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                if (enemyScript.material != Material.None)
                {
                    PlayerManager.instance.ChangeMaterial(enemyScript.material);
                    SpawnParticles();
                }
            }
        } 
        else if (other.CompareTag("MaterialSource"))
        {
            //on collision with a material source, take its material
            MaterialSource materialSourceScript = other.GetComponent<MaterialSource>();
            if (materialSourceScript != null)
            {
                if (materialSourceScript.material != Material.None)
                {
                    PlayerManager.instance.ChangeMaterial(materialSourceScript.material);
                    SpawnParticles();
                }
            }
        }

        DestroySelf();
    }

    private void SpawnParticles()
    {
        //instantiate any number of particle prefabs when the projectile collides with something
        for (int i = 0; i < particleAmount; i++)
        {
            Vector2 pos = transform.position;
            GameObject particle = Instantiate(particlePrefab, pos, Quaternion.identity);
        }
    }
    
    private void DestroySelf()
    {
        PlayerManager.instance.playerActions.materialAbsorberOut = false;
        Destroy(this.gameObject);  
    }
}

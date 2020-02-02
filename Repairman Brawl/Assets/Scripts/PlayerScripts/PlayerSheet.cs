﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSheet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject projectile;

    Vector3 direction;

    public float projectileForce;

    public float health;
    public float maxHealth;


    public float minDamage;
    public float maxDamage;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q was pressed.");
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
           // Vector3 direction;
            switch (player.GetComponent<PlayerMovement>().lookDirection)
            {
                case PlayerMovement.facing.up:
                    direction = new Vector3(0.0f, 1.0f, 0.0f);
                    break;
                case PlayerMovement.facing.down:
                    direction = new Vector3(0.0f, -1.0f, 0.0f);
                    break;
                case PlayerMovement.facing.left:
                    direction = new Vector3(-1.0f, 0.0f, 0.0f);
                    break;
                case PlayerMovement.facing.right:
                    direction = new Vector3(1.0f, 0.0f, 0.0f);
                    break;
            }

            direction = direction.normalized;
         
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;


        }
    }




    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected!");
        if (collision.otherCollider.tag == "Player")
        {
            collision.otherCollider.GetComponent<PlayerSheet>().takeDamage(Random.Range(minDamage, maxDamage));
        }
    }





    void takeDamage(float damage)
    {
        health = health - Random.Range(minDamage, maxDamage);
        if (health <= 0)
        {
            Destroy(player);
        }
    }


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Variables")]
    //[SerializeField] private float x=1;
    public float incrementalValue;
    [SerializeField] float movement;
    //[SerializeField] float movespeed = 5f;
    [SerializeField] private float deathpoint;
    [SerializeField] private float respawnTime;


    [Header("References")]
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private Rigidbody2D rg2D;
    private void Start()
    {
        //this.transform.position = new Vector3(2, 2, 0);
    }
    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        //Debug.Log(movement);
        //rg2D.velocity = new Vector2(movement, rg2D.velocity.y) *movespeed;
        //if(this.transform.position.y <= -4.5f)
        //{
        //    PlayerDeath();
        //}
    }

    private void PlayerDeath()
    {
        //Debug.Log("Player Dead");
        StartCoroutine(PlayerRespawn());
        //Code to actually kill the player\
        //play death animation
        //Invoke Game over screen
        //Calculate score depending on time
        //Restart the level
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided with soemthing");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Triggered something");
        if(collision.gameObject.tag == "Checkpoint")
        {
            //Change colour of sprite
            //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            spawnpoint.position = collision.gameObject.transform.position;
        }
        if (collision.gameObject.tag == "DeathTrigger")
        {
            PlayerDeath();
        }
    }
    //private void PlayerRespawn()
    //{
    //    this.transform.position = spawnpoint.position;
    //}

    private IEnumerator PlayerRespawn()
    {
        //Debug.Log("player will respawn in " + respawnTime + "seconds");
        yield return new WaitForSeconds(respawnTime);
        //Debug.Log("Player respawned");
        this.transform.position = spawnpoint.position;
    }
}

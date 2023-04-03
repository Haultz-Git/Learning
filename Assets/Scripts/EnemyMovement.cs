using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] float lanePositionX;

    private const string PLAYERTAG = "Player";
    private float deltaY;
    void Start()
    {
        deltaY= 0;

        //Assign a sprite for the enemy
        //_spriteRenderer.sprite = enemySprites[Random.Range(0,enemySprites.Length)];

        //Picks a lane (left,centre,right) when spawning and assignes it to lanePositionX which then it assigns to transform>position>x
    }

    // Update is called once per frame
    void Update()
    {
        //increase deltaY per second
        deltaY = Time.deltaTime *moveSpeed;
        transform.position= new Vector3(transform.position.x,(transform.position.y-deltaY),transform.position.z);
        //Gradually moves down

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collides with player do somethings
        if(collision.gameObject.tag == gameObject.tag)
        {
            Debug.Log("Right Shape");
        }
        else
        {
            Debug.Log("Wrong Shape");
        }
    }
}

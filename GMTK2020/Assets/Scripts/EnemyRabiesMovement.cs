using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRabiesMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.position);
        if (this.gameObject && player.position.y<700)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDist && Vector2.Distance(transform.position, player.position) > retreatDist)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision with rabies and " + col);
        if (col.gameObject.tag=="Player"){
            Destroy(this.gameObject);
            // Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag=="Bullet"){
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    
        //trigger a cool animation instead
    }

}

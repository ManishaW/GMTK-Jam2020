using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public Transform player;
    public Transform mainInfectedEnemy;
    public bool isInfected = false;
    bool allowPickup;
    bool randomized = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainInfectedEnemy = GameObject.FindGameObjectWithTag("InitialEnemy").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //infected Enemy Movement
        if (this.gameObject && player.position.y < 800 && isInfected)
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
            randomized=false;
        }

        //neutral enemy movement
        if (!isInfected && mainInfectedEnemy && player.position.y < 800)
        {
            transform.position = Vector2.MoveTowards(transform.position, mainInfectedEnemy.position, speed * Time.deltaTime);
            randomized=false;


        } 
        if (!isInfected && mainInfectedEnemy.position == transform.position){
            //
            isInfected=true;
            gameObject.tag = "InfectedEnemy";
            speed =100;
        }


        if (allowPickup && Input.GetKeyDown(KeyCode.E) && !isInfected)
        {
            Debug.Log("pick up neutral char");
            Destroy(this.gameObject);
            MainCharacterMovement.holdingNeutralEnemy = true;
            allowPickup = false;
        }

        if (player.position.y > 800 && this.gameObject.tag!="InitialEnemy"){
            //randomize all locations
            //wait few seconds then do it ONCE
            if (!randomized) StartCoroutine(WaitToRandomize());

           
        }


    }
    IEnumerator WaitToRandomize()
    {
        yield return new WaitForSeconds(0.75f);
        var randomX = Random.Range(280,1230);
        var randomY= Random.Range(320,680);
        transform.position=new Vector3(randomX, randomY, 0);
        randomized=true;
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     Debug.Log("collision with rabies and " + col);
    //     if (col.gameObject.tag=="Player"){
    //         Destroy(this.gameObject);
    //         // Destroy(col.gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (isInfected && this.gameObject.tag!="InitialEnemy" && col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            // Destroy(this.gameObject);
            isInfected = false;
            gameObject.tag = "Untagged";
            speed =50;

        }
       

        //trigger a cool animation instead
    }
  
    void OnTriggerStay2D(Collider2D coll)
    {
        if (!isInfected && coll.gameObject.tag == "Player" && !MainCharacterMovement.holdingNeutralEnemy)
        {
            allowPickup = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNeutralMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public Transform mainRabiesEnemy;
    public Transform player;
    // Start is called before the first frame update
    bool allowPickup;
    void Start()
    {
        mainRabiesEnemy=GameObject.FindGameObjectWithTag("InitialEnemy").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
    //    if(Vector2.Distance(transform.position, mainRabiesEnemy.position)>stoppingDist){
        if (mainRabiesEnemy && player.position.y<800){
            transform.position=Vector2.MoveTowards(transform.position, mainRabiesEnemy.position, speed*Time.deltaTime);
        }
        else if(this.gameObject){
            //move randomly around


        }

    if (allowPickup && Input.GetKeyDown(KeyCode.E)){
            Destroy(this.gameObject);
            MainCharacterMovement.holdingNeutralEnemy = true;
            allowPickup=false;
    }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="InitialEnemy"){
            Debug.Log("here" + col);
            Destroy(this.gameObject); 
            //turn into the 
        }
    }
    void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player" && !MainCharacterMovement.holdingNeutralEnemy) {
           allowPickup=true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNeutralMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public float retreatDist;
    public Transform mainRabiesEnemy;
    // Start is called before the first frame update
    void Start()
    {
        mainRabiesEnemy=GameObject.FindGameObjectWithTag("InitialEnemy").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
    //    if(Vector2.Distance(transform.position, mainRabiesEnemy.position)>stoppingDist){
        if (mainRabiesEnemy){
            transform.position=Vector2.MoveTowards(transform.position, mainRabiesEnemy.position, speed*Time.deltaTime);
        }

    //  } 
    //  else if (Vector2.Distance(transform.position, mainRabiesEnemy.position)<stoppingDist && Vector2.Distance(transform.position, mainRabiesEnemy.position)>retreatDist){
    //      transform.position=this.transform.position;
    //  }
    //  else if (Vector2.Distance(transform.position, mainRabiesEnemy.position)<retreatDist){
    //      transform.position=Vector2.MoveTowards(transform.position, mainRabiesEnemy.position, -speed*Time.deltaTime);

    //  } 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("here" + col);
        if (col.gameObject.name=="InitialEnemy"){
            
            Destroy(this.gameObject);
        }
    }


}

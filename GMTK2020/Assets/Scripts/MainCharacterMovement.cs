using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainCharacterMovement : MonoBehaviour
{

    Rigidbody2D body;
    public GameObject crosshairs;
    float moveSpeed = 200f;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    // public float runSpeed;
    Animator camAnimator;
    bool inSafetyZone=true;


    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        camAnimator = cam.GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        crosshairs.transform.position = new Vector2(mousePos.x, mousePos.y);


    }

    private void FixedUpdate()
    {
        
        // Debug.Log(body.position.y);
        if (body.position.y<750 && inSafetyZone){
            inSafetyZone=false;
            camAnimator.SetTrigger("AtInfectedZone");
        } else if (body.position.y>800 && !inSafetyZone){
            camAnimator.SetTrigger("AtSafetyZone");
            inSafetyZone=true;

        }
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);

        // //angle
        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;


    }
     void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("player hit" + col);
        if (col.gameObject.tag=="InfectedEnemy"){

        }
       
    }
    
     void OnTriggerStay2D(Collider2D other)
      {
        //   Debug.Log(other.name);
          if (Input.GetKeyDown(KeyCode.E) && other.name=="AmmoRefillArea")
          {
            //   Debug.Log("Inside ammo and refill requested");
            //   Shooting.ammoCount=10;
            Shooting.refillAmmo();
          }
      }

}

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
    bool inSafetyZone = true;
    public static bool holdingNeutralEnemy = false;
    bool insideRefillArea;
    bool insideContainmentArea;
    bool insideHealingArea;
    bool ammoFull = true;
    int health = 2;
    public GameObject gameoverCanvas;

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

        if (Input.GetKeyDown(KeyCode.E) && insideRefillArea)
        {
            Shooting.refillAmmo();

        }
        if (Input.GetKeyDown(KeyCode.E) && insideContainmentArea && holdingNeutralEnemy)
        {
            holdingNeutralEnemy = false;
            Debug.Log("Let go of glob");

        }
        if (Input.GetKeyDown(KeyCode.E) && insideHealingArea)
        {
            health = 2;
            Debug.Log("health restored");

        }

    }

    private void FixedUpdate()
    {

        // Debug.Log(body.position.y);
        if (body.position.y < 790 && inSafetyZone)
        {
            EnemyManager.InfectedAreaRaided = true;
            inSafetyZone = false;
            camAnimator.SetTrigger("AtInfectedZone");
        }
        else if (body.position.y > 800 && !inSafetyZone)
        {
            camAnimator.SetTrigger("AtSafetyZone");
            inSafetyZone = true;
            //GAte is always opened!!

        }
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);

        // //angle
        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;





    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("player hit" + col);
        if (col.gameObject.tag == "InfectedEnemy" || col.gameObject.tag == "InitialEnemy")
        {
            // Destroy(col.gameObject);
            if (health == 2)
            {
                Debug.Log("You've been infected");
                health = health - 1;
            }
            else
            {
                Debug.Log("Game Over!!!!");
                gameoverCanvas.SetActive(true);
                Time.timeScale = 0.0f; 
            }

        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //   Debug.Log(other.name);
        if (other.name == "AmmoRefillArea")
        {
            insideRefillArea = true;
        }

        if (other.name == "NeutralContainmentArea" && holdingNeutralEnemy)
        {
            insideContainmentArea = true;


        }
        if (other.name == "TentHealArea")
        {
            insideHealingArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "AmmoRefillArea")
        {
            insideRefillArea = false;
        }
         if (other.name == "TentHealArea")
        {
            insideHealingArea = false;
        }

        if (other.name == "NeutralContainmentArea")
        {
            insideContainmentArea = false;


        }
    }


}

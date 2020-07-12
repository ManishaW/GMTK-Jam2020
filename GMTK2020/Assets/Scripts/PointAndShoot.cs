using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;
    private Vector3 target;
    public float bulletSpeed;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        // target =transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        // crosshairs.transform.position= new Vector2(target.x, target.y); 
        // //need to do some rotation stuff for player here

        // Vector3 difference = target - player.transform.position;
        // if (Input.GetMouseButtonDown(0)){
        //     //fire tranquilizer
        //     float distance = difference.magnitude;
        //     Vector2 direction = difference/distance;
        //     fireBullet(direction, 0);
        // }
    }

    void fireBullet(Vector2 direction, float rotationZ){
        // GameObject b = Instantiate(bulletPrefab) as GameObject;
        // b.transform.position = player.transform.position;
        // // b.transform.position = player.transform.position;
        // b.GetComponent<Rigidbody2D>().velocity = direction*bulletSpeed;
        // b.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);

        // GameObject bulltet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


    }
}

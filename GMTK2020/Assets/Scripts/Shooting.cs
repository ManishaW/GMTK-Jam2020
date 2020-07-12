using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 125f;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public static float ammoCount = 10; 
    //ammo text
    public static TextMeshProUGUI ammoCountText;
    public GameObject ammoCountObj;
    // Start is called before the first frame update
    void Start()
    {
        ammoCountText= ammoCountObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if ( ammoCount>0 && Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeBtwShots=startTimeBtwShots;
                ammoCount=ammoCount-1;
                ammoCountText.text=ammoCount.ToString();
            }else if (ammoCount==0){
                // ammoCountText.color= RED;
            }
        }else{
            timeBtwShots -=Time.deltaTime;
        }

    }
    public static void refillAmmo (){
        Debug.Log("refill ammo");
        ammoCount=10;
        ammoCountText.text=ammoCount.ToString();

    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


    }
}

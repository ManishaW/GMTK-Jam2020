using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator DestroyBullet()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        Destroy(this.gameObject); // destroy gameObject that script is attached to
        //trigger a cool exposion animation or something

    }
}

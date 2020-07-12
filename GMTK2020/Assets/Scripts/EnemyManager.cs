using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static bool InfectedAreaRaided = false;
    public int enemyCounter = 1;
    public int InfectedCounter = 1;
    public float percentInfected;
    public GameObject neutralEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        percentInfected = InfectedCounter/enemyCounter;
    }

    // Update is called once per frame
    void Update()
    {

        if (InfectedAreaRaided){
            Debug.Log("Infected Area Raided!! Begin spawning!!" + percentInfected);
            //start spawning
            while (enemyCounter<=10){
                Debug.Log("here, keep spawning");
                InvokeRepeating ("MySpawnFunction", 0f, 3f);
            }
        }
    }

    void MySpawnFunction(){
        var randomX = Random.Range(280,1230);
        var randomY= Random.Range(320,680);
        var position = new Vector3(randomX, randomY, 0);
        Instantiate (neutralEnemyPrefab, position, Quaternion.identity);
    }
}

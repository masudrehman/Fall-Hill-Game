using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    GameManager manager;

    float obstacleTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        // InvokeRepeating("ObstacleCreation", 0, 0.5f);
        StartCoroutine(ObstaclesCreation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ObstaclesCreation() {
        while (!manager.gameOver) {
            // float positionX = Random.RandomRange(-5f, 5.8f);
            float positionX = Random.Range(-4.40f, 4.45f);
            Instantiate(obstacle, new Vector3(positionX, 0.5f, -16.6f), Quaternion.identity);
            yield return new WaitForSeconds(obstacleTime);
        }
        
    }


    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameOver) {
            Movement();
        }
     
    }

    void Movement() {
         if (GameManager.score > 20 ) {
                speed = 7f;
            } else if (GameManager.score > 40) {
                speed = 9f;
            }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);   

     if (transform.position.z >= 19.2f) {
        Destroy(gameObject);
     }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            manager.gameOver = true;
            Debug.Log("Game Over");
        }
    }
}

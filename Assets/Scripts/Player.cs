using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    Rigidbody rb;
    GameManager manager;
    float horizontalInput;
    public float speed = 70f;
    // [SerializeField] float speedHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Restriction();
        if (!manager.gameOver) {
            horizontalInput = Input.GetAxis("Horizontal");
            rb.AddForce(Vector3.right * horizontalInput *  speed);
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                // Debug.Log("Touch position: " + touch.position);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 viewPort = Camera.main.ScreenToViewportPoint(touch.position);
                // Debug.Log("Viewport" + Camera.main.ScreenToViewportPoint(touch.position));
                // Debug.Log("World Position Pane " + GetWorldPositionOnPlane(touchPosition, -3.9212f));
                // Debug.Log(touchPosition);
                // float xPos = touchPosition.x;
                if (viewPort.x >= 0.5) {
                    rb.AddForce(Vector3.right * 0.5f *  speed);
                } else {
                    rb.AddForce(Vector3.left * 0.5f *  speed);
                }
            }
        }
    }

    void Restriction() {
         if (transform.position.x <= -3f) {
            transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
        } else if (transform.position.x >= 3f) {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }
    }

     public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
     Ray ray = Camera.main.ScreenPointToRay(screenPosition);
     Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
     float distance;
     xy.Raycast(ray, out distance);
     return ray.GetPoint(distance);
 }

    
}

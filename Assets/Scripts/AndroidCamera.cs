using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCamera : MonoBehaviour
{
    public float orthographicSize = 15;
    public float aspect = 0.6f;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                GetComponent<Camera>().nearClipPlane, GetComponent<Camera>().farClipPlane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

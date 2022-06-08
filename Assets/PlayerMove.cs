using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        const float speed = 0.01f;
        if (Input.GetKey(KeyCode.D)) pos.x += speed;
        if (Input.GetKey(KeyCode.A)) pos.x -= speed;
        if (Input.GetKey(KeyCode.W)) pos.z += speed;
        if (Input.GetKey(KeyCode.S)) pos.z -= speed;

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
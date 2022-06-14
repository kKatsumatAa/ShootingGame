using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float angleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        const float speed = 0.02f;
        if (Input.GetKey(KeyCode.D)) pos.x += speed;
        if (Input.GetKey(KeyCode.A)) pos.x -= speed;
        if (Input.GetKey(KeyCode.W)) pos.y += speed;
        if (Input.GetKey(KeyCode.S)) pos.y -= speed;

        transform.position = new Vector3(pos.x, pos.y, pos.z);

        ////‰ñ“]
        //angleSpeed = 0;
        //if (Input.GetKey(KeyCode.RightArrow)) angleSpeed += 0.01f;
        //if (Input.GetKey(KeyCode.LeftArrow)) angleSpeed += -0.01f;

        //transform.rotation = new Quaternion(transform.rotation.x,
        //    transform.rotation.y + angleSpeed, transform.rotation.z, transform.rotation.w);
    }
}

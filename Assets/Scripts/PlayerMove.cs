using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float angleSpeed;
    public int playerHp=5;
    //playerHP
    public Text textComponent2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        const float speed = 0.02f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) pos.x += speed;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) pos.x -= speed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) pos.z += speed;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) pos.z -= speed;

        transform.position = new Vector3(pos.x, pos.y, pos.z);

        ////‰ñ“]
        //angleSpeed = 0;
        //if (Input.GetKey(KeyCode.RightArrow)) angleSpeed += 0.01f;
        //if (Input.GetKey(KeyCode.LeftArrow)) angleSpeed += -0.01f;

        //transform.rotation = new Quaternion(transform.rotation.x,
        //    transform.rotation.y + angleSpeed, transform.rotation.z, transform.rotation.w);
        textComponent2.text = "HP:" + playerHp;

        if (playerHp<=0)
        {
            Debug.Log("LOSE");
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        playerHp -= 1;
        
    }
}

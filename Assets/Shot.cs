using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //インスペクターから参照する用
    public GameObject Bullet;
    private float shotCool = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//ボタンが押されたとき
        if (Input.GetKey(KeyCode.Space)&&shotCool>=0.15f)
        {
            shotCool = 0;
            //
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        shotCool+=Time.deltaTime;
    }
}

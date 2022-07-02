using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //発生させるパーティクルを設定
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            //タグが同じオブジェクトをすべて取得
            GameObject[] enemybulletObjects =
                GameObject.FindGameObjectsWithTag("EnemyBullet");

            //取得したすべてのオブジェクトを消滅
            for(int i = 0; i < enemybulletObjects.Length; i++)
            {
                Destroy(enemybulletObjects[i].gameObject);
            }

            //パーティクルを持ったオブジェクトを生成
            Instantiate(particle,Vector3.zero,Quaternion.identity);
        }
    }
}

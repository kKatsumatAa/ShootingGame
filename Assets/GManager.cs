using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //敵の数を数える
    private GameObject[] enemy;
    //パネルを登録
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクトを全て入れる
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに一体もenemyがいなくなったら
        if(enemy.Length==0)
        {
            //パネル表示
            panel.SetActive(true);
        }
    }
}

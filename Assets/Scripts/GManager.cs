using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    //敵の数を数える
    private GameObject[] enemy;
    //パネルを登録
    public GameObject panel;
    //敵残り
    public Text textComponent;
    

    //int playerHP = 5;
    int enemyNokori = 0;

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

        enemyNokori=enemy.Length;

        textComponent.text = "敵残り:" + enemyNokori;
        

        //シーンに一体もenemyがいなくなったら
        if(enemy.Length==0)
        {
            //パネル表示
            panel.SetActive(true);
        }
    }
}

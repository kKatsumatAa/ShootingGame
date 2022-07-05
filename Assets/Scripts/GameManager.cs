using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //敵の数を数える
    private GameObject[] enemy;
    private GameObject player;
    //パネルを登録(clear)
    public GameObject panel;
    //パネルを登録(reset)
    public GameObject panel2;
    //敵残り
    public Text textComponent;
    //スコア
    public Text textComponent2;
    //タイマー
    public Text textComponent3;
    //hp
    public Text textComponent4;
    //wave
    public Text textComponent5;

    private float score;

    int[] enemyLength = new int[2];

    //int playerHP = 5;
    int enemyNokori = 0;

    float timer = 0;

    int playerHP=5;

    int wave = 1;
    int num;
    public float enemyPosZ = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
        if (panel != null)
        {
            panel.SetActive(false);
        }
        if (panel2 != null)
        {
            panel2.SetActive(false);
        }
        Screen.SetResolution(1920, 1080, false);//trueだとフルスクリーン
        Application.targetFrameRate = 60;

        player = GameObject.Find("Player");
    }
    public void ChangeScene(string nextscene)
    {
        SceneManager.LoadScene(nextscene);
    }
    public void SceneReset()
    {
        string activSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        enemyLength[1] = enemyLength[0];
        //シーンに存在しているEnemyタグを持っているオブジェクトを全て入れる
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //wave
        num = 0;
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                if (enemy[i].GetComponent<Enemy>().waveNum == wave)
                {
                    num++;
                }
            }
        }

        if (enemy != null)
        {
            if (num == 0&& wave < 3)
            {
                wave++;
            }
        }
        Debug.Log(wave);

        //wave変わったら移動
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                if (enemy[i].GetComponent<Enemy>().waveNum == wave && enemy[i].transform.position.z > enemyPosZ)
                {
                    enemy[i].transform.position =
                        new Vector3(enemy[i].transform.position.x, enemy[i].transform.position.y, enemy[i].transform.position.z - 0.5f);
                }
            }
        }
        if (enemy != null)
        {
            enemyLength[0] = enemy.Length;
            enemyNokori = enemy.Length;
        }

        //ゲームオブジェクトを探して変数に控えておく
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (enemy.Length >= 1)
            {
                timer += Time.deltaTime;
            }
        }



        if (textComponent != null)
        {
            textComponent.text = "敵残り:" + enemyNokori;
        }
        if (textComponent2 != null)
        {
            textComponent2.text = "SCORE:" + (int)score;
        }
        if (textComponent3 != null)
        {
            textComponent3.text = "TIME:" + (int)timer;
        }
        if (textComponent5 != null)
        {
            textComponent5.text = "WAVE:" + wave;
        }

        

        //シーンに一体もenemyがいなくなったら
        if (enemyLength[0] == 0 && enemyLength[1] > 0)
        {
            //パネル表示
            panel.SetActive(true);
            //panel2.SetActive(true);
            if (100 - timer > 0)
            {
                score += (100 - timer) * 30;
            }
        }
        if (playerHP <= 0)
        {
            playerHP = 0;
            Debug.Log("LOSE");
            player.SetActive(false);
            //panel.SetActive(true);
            panel2.SetActive(true);
        }
        if (textComponent4 != null)
        {
            textComponent4.text = "HP:" + playerHP;
        }
    }
    public void Damage()
    {
        playerHP -= 1;

    }
    public void AddScore(int score)
    {
        this.score += score;
    }
}

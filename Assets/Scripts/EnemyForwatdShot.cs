using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwatdShot : MonoBehaviour
{
    //player
    private GameObject player;
    //弾のゲームオブジェクトを入れる
    public GameObject bullet;
    //打ち出す感覚
    public float time = 1.0f;
    //最初に打ち出すまでの時間を決める
    public const float delayTime = 0.7f;
    //現在のタイマー時間
    float nowTime = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //タイマー初期化
        nowTime = delayTime;

    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入っていなかったら
        if(player==null)
        {
            //プロジェクトのPlayerを探して情報を取得
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //タイマーを減らす
        nowTime -= Time.deltaTime;
        //もしタイマーが0以下になったら
        if(nowTime <= 0)
        {
            if (transform.position.z <= GameObject.Find("GameManager").GetComponent<GameManager>().enemyPosZ)
            {
                //弾を生成
                CreateShotObject(-transform.localEulerAngles.y);
            }//タイマー初期化
            nowTime = time;
        }
    }



    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction = player.transform.position - transform.position;
        //ベクトルのyを初期化
        direction.y = 0;
        //向きを取得
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        //弾を生成
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);
        //enemybulletのゲットコンポーネントを変数として保存
        var bulletObject=bulletClone.GetComponent<EnemyBullet>();
        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);
        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis
            (lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}

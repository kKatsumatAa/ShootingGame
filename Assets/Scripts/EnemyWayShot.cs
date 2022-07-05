using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public int bulletWayNum = 3;//打ち出す玉の数
    public float bulletWaySpace = 30;//弾同士の角度
    public float time = 1;//間隔
    public float delayTime = 1;//最初に打ち出す間隔
    float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)
        {
            //プロジェクトのplayerを取得
            player = GameObject.FindGameObjectWithTag("Player");
        }
        nowTime -= Time.deltaTime;
        if(nowTime <= 0)
        {
            float bulletWaySpaceSplit = 0;//角度調整用
            for (int i = 0; i < bulletWayNum; i++)
            {//弾生成
                if (transform.position.z <= GameObject.Find("GameManager").GetComponent<GameManager>().enemyPosZ)
                {
                    CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y); ;
                    bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
                }
            }
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
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();
        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);
        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis
            (lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}

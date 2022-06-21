using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    //球のスピード
    public float speed=10;
    //自然消滅までのタイマー
    public float time = 15;
    //進行方向
    protected Vector3 forward=new Vector3(0,0,1);
    //打ち出すときの角度
    protected Quaternion forwardAxis=Quaternion.identity;
    //rigidbody用変数
    protected Rigidbody rb;
    //enemy用変数
    protected GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (/*other.gameObject.tag=="Player"|| other.gameObject.tag == "PlayerBody"*/other.gameObject.tag!="Enemy"&&other.gameObject.tag!="EnemyBullet")
        {
            //other.GetComponent<PlayerMove>().Damage();
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //rigidbody変数を初期化
        rb = this.GetComponent<Rigidbody>();
        //生成時に進行方向を決める
        if (enemy != null) forward = enemy.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //移動量を進行方向にスピード分だけ加える
        rb.velocity = forwardAxis * forward * speed;
        //空中に浮かないようにする
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //時間制限が来たら自然消滅
        time -= Time.deltaTime;
        if (time <= 0) Destroy(gameObject);

    }

    //弾を打ち出したキャラクターの情報を受け取る
    public void SetCharacterObject(GameObject character)
    {
        //弾を打ち出したキャラクターの情報を受け取る
        this.enemy = character;
    }

    //打ち出す角度を決定するための関数
    public void SetForwardAxis(Quaternion axis)
    {
        //設定された角度を受け取る
        this.forwardAxis = axis;
    }

   

}

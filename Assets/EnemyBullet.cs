using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    //���̃X�s�[�h
    public float speed=10;
    //���R���ł܂ł̃^�C�}�[
    public float time = 15;
    //�i�s����
    protected Vector3 forward=new Vector3(0,0,1);
    //�ł��o���Ƃ��̊p�x
    protected Quaternion forwardAxis=Quaternion.identity;
    //rigidbody�p�ϐ�
    protected Rigidbody rb;
    //enemy�p�ϐ�
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
        //rigidbody�ϐ���������
        rb = this.GetComponent<Rigidbody>();
        //�������ɐi�s���������߂�
        if (enemy != null) forward = enemy.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��ʂ�i�s�����ɃX�s�[�h������������
        rb.velocity = forwardAxis * forward * speed;
        //�󒆂ɕ����Ȃ��悤�ɂ���
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //���Ԑ����������玩�R����
        time -= Time.deltaTime;
        if (time <= 0) Destroy(gameObject);

    }

    //�e��ł��o�����L�����N�^�[�̏����󂯎��
    public void SetCharacterObject(GameObject character)
    {
        //�e��ł��o�����L�����N�^�[�̏����󂯎��
        this.enemy = character;
    }

    //�ł��o���p�x�����肷�邽�߂̊֐�
    public void SetForwardAxis(Quaternion axis)
    {
        //�ݒ肳�ꂽ�p�x���󂯎��
        this.forwardAxis = axis;
    }

   

}

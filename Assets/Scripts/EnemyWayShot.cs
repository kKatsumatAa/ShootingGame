using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    private GameObject player;
    public GameObject bullet;
    public int bulletWayNum = 3;//�ł��o���ʂ̐�
    public float bulletWaySpace = 30;//�e���m�̊p�x
    public float time = 1;//�Ԋu
    public float delayTime = 1;//�ŏ��ɑł��o���Ԋu
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
            //�v���W�F�N�g��player���擾
            player = GameObject.FindGameObjectWithTag("Player");
        }
        nowTime -= Time.deltaTime;
        if(nowTime <= 0)
        {
            float bulletWaySpaceSplit = 0;//�p�x�����p
            for (int i = 0; i < bulletWayNum; i++)
            {//�e����
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
        //�x�N�g�����擾
        var direction = player.transform.position - transform.position;
        //�x�N�g����y��������
        direction.y = 0;
        //�������擾
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        //�e�𐶐�
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);
        //enemybullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();
        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);
        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAxis
            (lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}

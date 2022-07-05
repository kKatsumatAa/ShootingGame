using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwatdShot : MonoBehaviour
{
    //player
    private GameObject player;
    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;
    //�ł��o�����o
    public float time = 1.0f;
    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public const float delayTime = 0.7f;
    //���݂̃^�C�}�[����
    float nowTime = 0;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[������
        nowTime = delayTime;

    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����Ă��Ȃ�������
        if(player==null)
        {
            //�v���W�F�N�g��Player��T���ď����擾
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //�^�C�}�[�����炷
        nowTime -= Time.deltaTime;
        //�����^�C�}�[��0�ȉ��ɂȂ�����
        if(nowTime <= 0)
        {
            if (transform.position.z <= GameObject.Find("GameManager").GetComponent<GameManager>().enemyPosZ)
            {
                //�e�𐶐�
                CreateShotObject(-transform.localEulerAngles.y);
            }//�^�C�}�[������
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
        var bulletObject=bulletClone.GetComponent<EnemyBullet>();
        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);
        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAxis
            (lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}

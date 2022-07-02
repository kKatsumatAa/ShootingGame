using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //����������p�[�e�B�N����ݒ�
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
            //�^�O�������I�u�W�F�N�g�����ׂĎ擾
            GameObject[] enemybulletObjects =
                GameObject.FindGameObjectsWithTag("EnemyBullet");

            //�擾�������ׂẴI�u�W�F�N�g������
            for(int i = 0; i < enemybulletObjects.Length; i++)
            {
                Destroy(enemybulletObjects[i].gameObject);
            }

            //�p�[�e�B�N�����������I�u�W�F�N�g�𐶐�
            Instantiate(particle,Vector3.zero,Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //�G�̐��𐔂���
    private GameObject[] enemy;
    //�p�l����o�^
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //�p�l�����B��
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�V�[���ɑ��݂��Ă���Enemy�^�O�������Ă���I�u�W�F�N�g��S�ē����
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //�V�[���Ɉ�̂�enemy�����Ȃ��Ȃ�����
        if(enemy.Length==0)
        {
            //�p�l���\��
            panel.SetActive(true);
        }
    }
}

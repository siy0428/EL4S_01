//---------------------------------------------------
//
//�e�̔��ˊǗ�������
//
//---------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resporn_bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject red;        //�ԐF�̒e
    [SerializeField]
    private GameObject blue;       //�F�̒e
    [SerializeField]
    private GameObject black;      //���F�̒e

    GameObject level;               //��Փx�I�u�W�F�N�g

    int resporntime;               //�e�̔��ˎ���
    int time;                      //���݂̃^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        Resporntimer();
        time = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if (resporntime <= time)
        {
            RandomBullet();
            Resporntimer();

            level = GameObject.Find("degree of difficulty");
            level.GetComponent<level>().LevelUp();
        }
    }

    void RandomBullet() //�����_���̒e��I��
    {
        int rand = Random.Range(0, 2);

        switch (rand)
        {
            case 0:
                SetRedBullet();
                break;
            case 1:
                SetBlueBullet();
                break;
            case 2:
                SetBlackBullet();
                break;
        }
    }

    void SetRedBullet()  //�Ԃ̒e��I��
    {
        Instantiate(red, transform.position, Quaternion.identity);
        time = 0;
    }

    void SetBlueBullet() //�̒e��I��
    {
        Instantiate(blue, transform.position, Quaternion.identity);
        time = 0;
    }
    void SetBlackBullet() //���̒e��I��
    {
        Instantiate(black, transform.position, Quaternion.identity);
        time = 0;
    }

    void Resporntimer()
    {
        resporntime = 50;
        level = GameObject.Find("degree of difficulty");
        resporntime += Random.Range(0,240 - level.GetComponent<level>().GetLevel()*2);
        resporntime += Random.Range(0, 100 - level.GetComponent<level>().GetLevel()*2);
    }
}

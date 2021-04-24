//---------------------------------------------------
//
//弾の発射管理するやつ
//
//---------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resporn_bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject red;        //赤色の弾
    [SerializeField]
    private GameObject blue;       //青色の弾
    [SerializeField]
    private GameObject black;      //黒色の弾

    GameObject level;               //難易度オブジェクト

    int resporntime;               //弾の発射時間
    int time;                      //現在のタイマー

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

    void RandomBullet() //ランダムの弾を選ぶ
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

    void SetRedBullet()  //赤の弾を選ぶ
    {
        Instantiate(red, transform.position, Quaternion.identity);
        time = 0;
    }

    void SetBlueBullet() //青の弾を選ぶ
    {
        Instantiate(blue, transform.position, Quaternion.identity);
        time = 0;
    }
    void SetBlackBullet() //黒の弾を選ぶ
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

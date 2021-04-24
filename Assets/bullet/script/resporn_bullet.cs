//---------------------------------------------------
//
//’e‚Ì”­ËŠÇ—‚·‚é‚â‚Â
//
//---------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resporn_bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject red;        //ÔF‚Ì’e
    [SerializeField]
    private GameObject blue;       //ÂF‚Ì’e
    [SerializeField]
    private GameObject black;      //•F‚Ì’e

    int resporntime;               //’e‚Ì”­ËŠÔ
    int time;                      //Œ»İ‚Ìƒ^ƒCƒ}[

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
            GameObject level = GameObject.Find("degree of difficulty");
            level.GetComponent<level>().LevelUp();
        }
    }

    void RandomBullet() //ƒ‰ƒ“ƒ_ƒ€‚Ì’e‚ğ‘I‚Ô
    {
        int rand = Random.Range(0, 3);

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

    void SetRedBullet()  //Ô‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(red, transform.position, Quaternion.identity);
        time = 0;
    }

    void SetBlueBullet() //Â‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(blue, transform.position, Quaternion.identity);
        time = 0;
    }
    void SetBlackBullet() //•‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(black, transform.position, Quaternion.identity);
        time = 0;
    }

    void Resporntimer()
    {
        resporntime = 50;
        resporntime += Random.Range(0,240);
        resporntime += Random.Range(0, 100);
    }
}

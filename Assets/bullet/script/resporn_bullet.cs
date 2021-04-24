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
        resporntime = 120;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if(resporntime<=time)
        {
            RandomBullet();
        }
    }

    void RandomBullet() //ƒ‰ƒ“ƒ_ƒ€‚Ì’e‚ğ‘I‚Ô
    {
        int rand = Random.Range(0, 3);

        switch(rand)
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

    public void SetRedBullet()  //Ô‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(red, transform.position, Quaternion.identity);
        time = 0;
    }

    public void SetBlueBullet() //Â‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(blue, transform.position, Quaternion.identity);
        time = 0;
    }
    public void SetBlackBullet() //•‚Ì’e‚ğ‘I‚Ô
    {
        Instantiate(black, transform.position, Quaternion.identity);
        time =0;
    }
}

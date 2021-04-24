using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        //離した時
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DestoryBarrier();
            player.SetRed();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            DestoryBarrier();
            player.SetBlue();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            DestoryBarrier();
            player.SetBlack();
        }

        //エネルギーが0になった時     
        int red = player.GetRedEnergy();
        int blue = player.GetBlueEnergy();
        int black = player.GetBlackEnergy();

        if(red <= 0)
        {
            DestoryBarrier();
            player.SetRed();
        }
        if (blue <= 0)
        {
            DestoryBarrier();
            player.SetBlue();
        }
        if (black <= 0)
        {
            DestoryBarrier();
            player.SetBlack();
        }
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="other">当たったオブジェクト</param>
    void OnTriggerEnter(Collider other)
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //バリアが消える

        //同じ色の弾とバリアだったら弾を消す
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Destroy(other.gameObject);   //弾が消える
        }

        //バリア個数減少
        player.BarrierCountDown();
    }

    /// <summary>
    /// バリア削除処理
    /// </summary>
    void DestoryBarrier()
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //バリアが消える

        //バリア個数減少
        player.BarrierCountDown();
    }
}

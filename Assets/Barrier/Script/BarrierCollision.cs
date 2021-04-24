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
        GameObject red = GameObject.Find("BlueGauge");

        //離した時
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DestoryBarrier();
            player.SetBarrierRed(false);
            red.GetComponent<GaugeController>().SetisUseRed(false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            DestoryBarrier();
            player.SetBarrierBlue(false);
            red.GetComponent<GaugeController>().SetisUseBlue(false);
        }

        //プレイヤー追従
        this.transform.position = player.transform.position;
        this.transform.position += new Vector3(2.0f, 2.0f, 0.0f);
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

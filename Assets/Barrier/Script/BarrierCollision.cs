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
            Destroy(this.gameObject);  //バリアが消える
            //パラメータリセット
            player._Reset();

            //バリア個数減少
            player.BarrierCountDown();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Destroy(this.gameObject);  //バリアが消える
            //パラメータリセット
            player._Reset();

            //バリア個数減少
            player.BarrierCountDown();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Destroy(this.gameObject);  //バリアが消える
            //パラメータリセット
            player._Reset();

            //バリア個数減少
            player.BarrierCountDown();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //バリアが消える

        //同じ色の弾とバリアだったら弾を消す
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Destroy(other.gameObject);   //弾が消える
        }

        //パラメータリセット
        player._Reset();

        //バリア個数減少
        player.BarrierCountDown();
    }
}

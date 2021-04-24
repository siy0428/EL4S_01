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

        //��������
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

        //�v���C���[�Ǐ]
        this.transform.position = player.transform.position;
        this.transform.position += new Vector3(2.0f, 2.0f, 0.0f);
    }

    /// <summary>
    /// �����蔻��
    /// </summary>
    /// <param name="other">���������I�u�W�F�N�g</param>
    void OnTriggerEnter(Collider other)
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //�o���A��������

        //�����F�̒e�ƃo���A��������e������
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Destroy(other.gameObject);   //�e��������
        }

        //�o���A������
        player.BarrierCountDown();
    }

    /// <summary>
    /// �o���A�폜����
    /// </summary>
    void DestoryBarrier()
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //�o���A��������

        //�o���A������
        player.BarrierCountDown();
    }
}

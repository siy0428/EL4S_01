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

        //��������
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

        //�G�l���M�[��0�ɂȂ�����     
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

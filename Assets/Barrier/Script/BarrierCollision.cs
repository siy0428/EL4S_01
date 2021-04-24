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
            Destroy(this.gameObject);  //�o���A��������
            //�p�����[�^���Z�b�g
            player._Reset();

            //�o���A������
            player.BarrierCountDown();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Destroy(this.gameObject);  //�o���A��������
            //�p�����[�^���Z�b�g
            player._Reset();

            //�o���A������
            player.BarrierCountDown();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Destroy(this.gameObject);  //�o���A��������
            //�p�����[�^���Z�b�g
            player._Reset();

            //�o���A������
            player.BarrierCountDown();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        BarrierController player = FindObjectOfType<BarrierController>();

        Destroy(this.gameObject);  //�o���A��������

        //�����F�̒e�ƃo���A��������e������
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Destroy(other.gameObject);   //�e��������
        }

        //�p�����[�^���Z�b�g
        player._Reset();

        //�o���A������
        player.BarrierCountDown();
    }
}

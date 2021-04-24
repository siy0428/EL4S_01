using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    //�����Ă��邩
    private bool IsAlive = true;

    [SerializeField]
    //�c�@�̉�
    private int Life = 3;

    [SerializeField]
    //�G�l���M�[����
    private float Energy = 100.0f;

    [SerializeField]
    //�G�l���M�[�̌������x
    private float EnergySpeed = 0.5f;

    [SerializeField]
    //�W�����v����̃X�s�[�h��
    private float JumpSpeed = 10.0f;

    [SerializeField]
    //�G�l���M�[�񕜂̍ŏ���������
    private float EnergyLimitedTime = 0.25f;

    //�o���A�̐������@
    private int BarrierModel = 0;

    //�W�����v����
    private bool IsJump = false;

    //�G�l���M�[�񕜂̃^�C�}�[
    private float EnergyTimer = 0.0f;

    [SerializeField]
    //�P��o���A�𐶐�����G�l���M�[�����
    private float EnergyPerTimes = 10.0f;

    [SerializeField]
    //�G�l���M�[�񕜃X�s�[�h
    private float EnergyRecoverySpeed = 1.0f;

    [SerializeField]
    //�G�l���M�[�ő�l
    private float MaxEnergy = 100.0f;

    private Rigidbody rb;

    [SerializeField]
    private float grv = -9.81f;

    private int JumpTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        UseBarrier();
        LifeCheak();
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsJump)
        {
            IsJump = true;
        }

        if (IsJump && JumpTimes < 1)
        {
            rb.velocity = new Vector3(0.0f, JumpSpeed, 0.0f);
            JumpTimes++;         
        }

        if(rb.velocity.y == 0.0f && JumpTimes>0)
        {
            JumpTimes = 0;
            IsJump = false;
        }

        if (IsJump && JumpTimes > 0)
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y + grv * Time.deltaTime, 0.0f);
        }
    }

    void LifeCheak()
    {
        if(!IsAlive)
        {
            Life -= 1;
            if (Life < 1)
            {
                Debug.Log("���񂾁I");
               //End
            }
            IsAlive = true;
        }
    }

    void UseBarrier()
    {
        /*
        switch (BarrierModel)
        {
            case 0://������
                if(Energy >= EnergySpeed)
                {
                    UseBarrierA();
                }
                break;
            case 1://��������
                if (Energy >= EnergyPerTimes)
                {
                    UseBarrierB();
                }
                break;
        }
        */
        if(Energy < MaxEnergy)
        {
            Energy += EnergyRecoverySpeed * Time.deltaTime;
        }

        if(Energy >= MaxEnergy)
        {
            Energy = MaxEnergy;
        }
        
    }

    void UseBarrierA()
    {
        if(EnergyTimer >= EnergyLimitedTime)
        {
            Energy -= EnergySpeed;
            EnergyTimer = 0.0f;
        }
        EnergyTimer += Time.deltaTime;
    }

    void UseBarrierB()
    {
        Energy -= EnergyPerTimes;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "red" || other.gameObject.tag == "black" || other.gameObject.tag == "blue")
        {
            Debug.Log("��񎀂񂾁I");
            GameObject.Destroy(other.gameObject);
            IsAlive = false;
        }
    }
}

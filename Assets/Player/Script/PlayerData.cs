using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    //生きているか
    private bool IsAlive = true;

    [SerializeField]
    //残機の回数
    private int Life = 3;

    [SerializeField]
    //エネルギー総量
    private float Energy = 100.0f;

    [SerializeField]
    //エネルギーの減少速度
    private float EnergySpeed = 0.5f;

    [SerializeField]
    //ジャンプ操作のスピード率
    private float JumpSpeed = 10.0f;

    [SerializeField]
    //エネルギー回復の最小制限時間
    private float EnergyLimitedTime = 0.25f;

    //バリアの生成方法
    private int BarrierModel = 0;

    //ジャンプ判定
    private bool IsJump = false;

    //エネルギー回復のタイマー
    private float EnergyTimer = 0.0f;

    [SerializeField]
    //単回バリアを生成するエネルギー消費量
    private float EnergyPerTimes = 10.0f;

    [SerializeField]
    //エネルギー回復スピード
    private float EnergyRecoverySpeed = 1.0f;

    [SerializeField]
    //エネルギー最大値
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
                Debug.Log("死んだ！");
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
            case 0://押しつつ
                if(Energy >= EnergySpeed)
                {
                    UseBarrierA();
                }
                break;
            case 1://押したら
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
            Debug.Log("一回死んだ！");
            GameObject.Destroy(other.gameObject);
            IsAlive = false;
        }
    }
}

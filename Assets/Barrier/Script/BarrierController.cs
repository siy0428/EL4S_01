using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    /// <summary>
    /// �G�f�B�^�ォ��ҏW�\�ȕϐ�
    /// </summary>
    [SerializeField]
    private GameObject prefabRed;
    [SerializeField]
    private GameObject prefabBlue;
    [SerializeField]
    private GameObject prefabBlack;
    [SerializeField]
    private int MaxEnergy;
    [SerializeField]
    private float MaxBarrierCount;

    [SerializeField]
    private float DecreaseEnergy;

    /// <summary>
    /// �X�N���v�g�p�ϐ�
    /// </summary>
    private int BarrierCount;
    private int RedEnergy;
    private int BlueEnergy;
    private int BlackEnergy;
    private bool RedOn;
    private bool BlueOn;
    private bool BlackOn;

    /// <summary>
    /// �O���X�N���v�g�p���\�b�h
    /// </summary>
    public void BarrierCountUp() { BarrierCount++; }
    public void BarrierCountDown() { BarrierCount--; }
    public int GetRedEnergy() { return RedEnergy; }
    public int GetBlueEnergy() { return BlueEnergy; }
    public int GetBlackEnergy() { return BlackEnergy; }

    public void SetRed() { RedOn = false; }
    public void SetBlue() { BlueOn = false; }
    public void SetBlack() { BlackOn = false; }

    // Start is called before the first frame update
    void Start()
    {
        BarrierCount = 0;
        RedOn = false;
        BlueOn = false;
        BlackOn = false;

        RedEnergy = MaxEnergy;
        BlueEnergy = MaxEnergy;
        BlackEnergy = MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Blue:" + BlueEnergy);

        //�L�[���͂Ńo���A����
        InputBarrierCreate();

        //�o���A��������
        if (RedOn && RedEnergy > 0)
        {
            RedEnergy--;
        }
        else
        {
            RedEnergy++;
            if (MaxEnergy < RedEnergy)
            {
                RedEnergy = MaxEnergy;
            }
        }
        if (BlueOn && BlueEnergy > 0)
        {
            BlueEnergy--;
        }
        else
        {
            BlueEnergy++;
            if (MaxEnergy < BlueEnergy)
            {
                BlueEnergy = MaxEnergy;
            }
        }
        if (BlackOn && BlackEnergy > 0)
        {
            BlackEnergy--;
        }
        else
        {
            BlackEnergy++;
            if (MaxEnergy < BlackEnergy)
            {
                BlackEnergy = MaxEnergy;
            }
        }
    }

    /// <summary>
    /// �L�[���͂Ńo���A����
    /// </summary>
    void InputBarrierCreate()
    {
        //�o���A����萔�ȏゾ�����珈�����s��Ȃ�
        if (BarrierCount >= MaxBarrierCount)
        {
            return;
        }

        //�L�[����
        if (Input.GetKey(KeyCode.Q) && RedEnergy > 100)
        {
            BarrierCreate(prefabRed);
            RedOn = true;
        }
        else if (Input.GetKey(KeyCode.W) && BlueEnergy > 100)
        {
            BarrierCreate(prefabBlue);
            BlueOn = true;
        }
        else if (Input.GetKey(KeyCode.E) && BlackEnergy > 100)
        {
            BarrierCreate(prefabBlack);
            BlackOn = true;
        }
    }

    /// <summary>
    /// �o���A�̍폜
    /// </summary>
    /// <param name="prefab"></param>
    void BarrierDestroy(GameObject prefab)
    {
        Destroy(prefab);
        BarrierCountDown();
    }

    /// <summary>
    /// �o���A����
    /// </summary>
    void BarrierCreate(GameObject prefab)
    {
        //�o���A�����ʒu
        Vector3 pos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0.0f);
        // �Q�[���I�u�W�F�N�g�̐���
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.6f, 1.0f, 1.0f);

        BarrierCount++;
    }
}

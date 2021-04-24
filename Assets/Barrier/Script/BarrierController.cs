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
    [SerializeField, Range(1.0f, 16.0f)]
    private float interval;
    [SerializeField]
    private float localMinScale;
    [SerializeField]
    private float MaxBarrierCount;

    /// <summary>
    /// �X�N���v�g�p�ϐ�
    /// </summary>
    private int BarrierCount;

    /// <summary>
    /// �O���X�N���v�g�p���\�b�h
    /// </summary>
    public void BarrierCountUp() { BarrierCount++; }
    public void BarrierCountDown() { BarrierCount--; }
    public void _Reset()
    {
        //�Ԋu�̒���
        interval -= 1.0f;
        //�傫���̒���
        localMinScale -= 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        BarrierCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���͂Ńo���A����
        InputBarrierCreate();

        Debug.Log(BarrierCount);
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

        if (Input.GetKey(KeyCode.Q))
        {
            BarrierCreate(prefabRed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            BarrierCreate(prefabBlue);
        }
        if (Input.GetKey(KeyCode.E))
        {
            BarrierCreate(prefabBlack);
        }

    }

    void BarrierDestroy(GameObject prefab)
    {
        if(prefab == null)
        {
            return;
        }

        Destroy(prefab);
        _Reset();
        BarrierCountDown();
    }

    /// <summary>
    /// �o���A����
    /// </summary>
    void BarrierCreate(GameObject prefab)
    {
        //�o���A�����ʒu
        Vector3 pos = new Vector3(transform.position.x + interval + 0.5f, transform.position.y, 0.0f);
        // �Q�[���I�u�W�F�N�g�̐���
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.6f, localMinScale, 1.0f);
        //�Ԋu�̒���
        interval += 1.0f;
        //�傫���̒���
        localMinScale += 1.0f;

        BarrierCount++;
    }
}

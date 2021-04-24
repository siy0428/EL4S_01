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
    private int MaxEnergy;
    [SerializeField]
    private float MaxBarrierCount;

    /// <summary>
    /// �X�N���v�g�p�ϐ�
    /// </summary>
    private int BarrierCount;
    private bool RedOn;
    private bool BlueOn;

    /// <summary>
    /// �O���X�N���v�g�p���\�b�h
    /// </summary>
    public void BarrierCountUp() { BarrierCount++; }
    public void BarrierCountDown() { BarrierCount--; }

    public void SetBarrierRed(bool set) { RedOn = set; }
    public void SetBarrierBlue(bool set) { BlueOn = set; }
    public bool GetBarrierRed() { return RedOn; }
    public bool GetBarrierBlue() { return BlueOn; }

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
        if (Input.GetKey(KeyCode.Q))
        {
            BarrierCreate(prefabRed);
            RedOn = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            BarrierCreate(prefabBlue);
            BlueOn = true;
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
        Vector3 pos = new Vector3(transform.position.x + 2.0f, transform.position.y, 0.0f);
        // �Q�[���I�u�W�F�N�g�̐���
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.5f, 2.0f, 1.0f);

        BarrierCount++;
    }
}

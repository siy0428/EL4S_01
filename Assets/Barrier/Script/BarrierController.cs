using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    /// <summary>
    /// �G�f�B�^�ォ��ҏW�\�ȕϐ�
    /// </summary>
    [SerializeField]
    private GameObject prefabObj;
    [SerializeField, Range(1.0f, 16.0f)]
    private float interval;
    [SerializeField]
    private float localMinScale;

    /// <summary>
    /// �X�N���v�g�p�ϐ�
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        //�L�[���͂̃o���A����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            color = Color.red;
            BarrierCreate(color);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            color = Color.blue;
            BarrierCreate(color);
        }

    }

    /// <summary>
    /// �L�[���͂̃o���A����
    /// </summary>
    void BarrierCreate(Color color)
    {
        //�o���A�����ʒu
        Vector3 pos = new Vector3(transform.position.x + interval, transform.position.y, 0.0f);
        // �Q�[���I�u�W�F�N�g�̐���
        GameObject obj = Instantiate(prefabObj, pos, Quaternion.identity);
        //�F�ݒ�
        var renderer = obj.GetComponent<Renderer>();
        renderer.material.color = color;

        //�Ԋu�̒���
        interval += 1.0f;
    }
}

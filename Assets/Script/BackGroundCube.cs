using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCube : MonoBehaviour
{
    // �w�i�I�u�W�F�N�g�̑��x
    [SerializeField]
    private float velocity;

    [SerializeField]
    private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        // transform�̎擾
        Transform myTransform = this.transform;

        // ���W�X�V
        Vector3 pos = myTransform.position;
        pos.x -= velocity;

        // ���
        myTransform.position = pos;


        // ��苗���܂ōs������폜
        if(myTransform.position.x <= -40.0f)
        {
            Destroy(obj);
        }

    }
}

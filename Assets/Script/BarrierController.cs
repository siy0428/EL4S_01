using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabObj;
    [SerializeField, Range(1.0f, 16.0f)]
    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        //�o���A�����ʒu
        Vector3 pos = new Vector3(transform.position.x + interval, transform.position.y, 0.0f);
        // �Q�[���I�u�W�F�N�g�𐶐����܂��B
        GameObject obj = Instantiate(prefabObj, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

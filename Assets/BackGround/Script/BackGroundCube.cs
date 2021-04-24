using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCube : MonoBehaviour
{
    // 背景オブジェクトの速度
    [SerializeField]
    private float velocity;

    [SerializeField]
    private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
        // transformの取得
        Transform myTransform = this.transform;

        // 座標更新
        Vector3 pos = myTransform.position;
        pos.x -= velocity;

        // 代入
        myTransform.position = pos;


        // 一定距離まで行ったら削除
        if(myTransform.position.x <= -40.0f)
        {
            Destroy(obj);
        }

    }
}

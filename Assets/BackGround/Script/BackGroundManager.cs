using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private int cnt;

    [SerializeField]
    private int instance_cnt;


    //private float depth;
    private float scale;

    void Start()
    {
        cnt = 0;
        scale = 0.0f;
    }


    void Update()
    {
        cnt++;

        // 一定時間たったら背景オブジェクトを生成
        if (cnt >= instance_cnt)
        {
            scale = Random.Range(2.0f, 10.0f);
            //depth = Random.Range(10.0f, 30.0f);

            Instantiate(obj, new Vector3(60.0f, Random.Range(-10.0f, 10.0f), Random.Range(10.0f, 30.0f)), Quaternion.identity);
            obj.transform.localScale = new Vector3(scale, scale, scale);
            cnt = 0;
        }

    }
}

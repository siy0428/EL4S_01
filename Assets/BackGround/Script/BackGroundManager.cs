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

    [SerializeField]
    private float depth;

    void Start()
    {
        cnt = 0;
    }


    void Update()
    {
        cnt++;

        // 一定時間たったら背景オブジェクトを生成
        if(cnt >= instance_cnt)
        {
            Instantiate(obj, new Vector3(40.0f, Random.Range(-10.0f, 10.0f), depth), Quaternion.identity);
            obj.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            cnt = 0;
        }

    }
}

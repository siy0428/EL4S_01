using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    /// <summary>
    /// エディタ上から編集可能な変数
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
    /// スクリプト用変数
    /// </summary>
    private int BarrierCount;

    /// <summary>
    /// 外部スクリプト用メソッド
    /// </summary>
    public void BarrierCountUp() { BarrierCount++; }
    public void BarrierCountDown() { BarrierCount--; }
    public void _Reset()
    {
        //間隔の調整
        interval -= 1.0f;
        //大きさの調整
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
        //キー入力でバリア生成
        InputBarrierCreate();

        Debug.Log(BarrierCount);
    }

    /// <summary>
    /// キー入力でバリア生成
    /// </summary>
    void InputBarrierCreate()
    {
        //バリアが一定数以上だったら処理を行わない
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
    /// バリア生成
    /// </summary>
    void BarrierCreate(GameObject prefab)
    {
        //バリア生成位置
        Vector3 pos = new Vector3(transform.position.x + interval + 0.5f, transform.position.y, 0.0f);
        // ゲームオブジェクトの生成
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.6f, localMinScale, 1.0f);
        //間隔の調整
        interval += 1.0f;
        //大きさの調整
        localMinScale += 1.0f;

        BarrierCount++;
    }
}

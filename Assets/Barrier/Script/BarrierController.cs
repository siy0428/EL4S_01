using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    /// <summary>
    /// エディタ上から編集可能な変数
    /// </summary>
    [SerializeField]
    private GameObject prefabObj;
    [SerializeField, Range(1.0f, 16.0f)]
    private float interval;
    [SerializeField]
    private float localMinScale;

    /// <summary>
    /// スクリプト用変数
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        //キー入力のバリア生成
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
    /// キー入力のバリア生成
    /// </summary>
    void BarrierCreate(Color color)
    {
        //バリア生成位置
        Vector3 pos = new Vector3(transform.position.x + interval, transform.position.y, 0.0f);
        // ゲームオブジェクトの生成
        GameObject obj = Instantiate(prefabObj, pos, Quaternion.identity);
        //色設定
        var renderer = obj.GetComponent<Renderer>();
        renderer.material.color = color;

        //間隔の調整
        interval += 1.0f;
    }
}

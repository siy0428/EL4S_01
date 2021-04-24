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
    private int MaxEnergy;
    [SerializeField]
    private float MaxBarrierCount;

    /// <summary>
    /// スクリプト用変数
    /// </summary>
    private int BarrierCount;
    private bool RedOn;
    private bool BlueOn;

    /// <summary>
    /// 外部スクリプト用メソッド
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
        //キー入力でバリア生成
        InputBarrierCreate();
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

        GameObject red = GameObject.Find("BlueGauge");

        //キー入力
        if (Input.GetKey(KeyCode.Q)&& red.GetComponent<GaugeController>().GetisRed())
        {
            
            BarrierCreate(prefabRed);
            RedOn = true;
            red.GetComponent<GaugeController>().SetisUseRed(true);
        }
        else if (Input.GetKey(KeyCode.W) && red.GetComponent<GaugeController>().GetisBlue())
        {
            BarrierCreate(prefabBlue);
            BlueOn = true;
            red.GetComponent<GaugeController>().SetisUseBlue(true);
        }
    }

    /// <summary>
    /// バリアの削除
    /// </summary>
    /// <param name="prefab"></param>
    void BarrierDestroy(GameObject prefab)
    {
        Destroy(prefab);
        BarrierCountDown();
    }

    /// <summary>
    /// バリア生成
    /// </summary>
    void BarrierCreate(GameObject prefab)
    {
        //バリア生成位置
        Vector3 pos = new Vector3(transform.position.x + 2.0f, transform.position.y+2.0f, 0.0f);
        // ゲームオブジェクトの生成
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.5f, 2.0f, 1.0f);

        BarrierCount++;
    }
}

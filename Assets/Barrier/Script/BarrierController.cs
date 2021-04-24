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
    [SerializeField]
    private int MaxEnergy;
    [SerializeField]
    private float MaxBarrierCount;

    [SerializeField]
    private float DecreaseEnergy;

    /// <summary>
    /// スクリプト用変数
    /// </summary>
    private int BarrierCount;
    private int RedEnergy;
    private int BlueEnergy;
    private int BlackEnergy;
    private bool RedOn;
    private bool BlueOn;
    private bool BlackOn;

    /// <summary>
    /// 外部スクリプト用メソッド
    /// </summary>
    public void BarrierCountUp() { BarrierCount++; }
    public void BarrierCountDown() { BarrierCount--; }
    public int GetRedEnergy() { return RedEnergy; }
    public int GetBlueEnergy() { return BlueEnergy; }
    public int GetBlackEnergy() { return BlackEnergy; }

    public void SetRed() { RedOn = false; }
    public void SetBlue() { BlueOn = false; }
    public void SetBlack() { BlackOn = false; }

    // Start is called before the first frame update
    void Start()
    {
        BarrierCount = 0;
        RedOn = false;
        BlueOn = false;
        BlackOn = false;

        RedEnergy = MaxEnergy;
        BlueEnergy = MaxEnergy;
        BlackEnergy = MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Blue:" + BlueEnergy);

        //キー入力でバリア生成
        InputBarrierCreate();

        //バリア生成中は
        if (RedOn && RedEnergy > 0)
        {
            RedEnergy--;
        }
        else
        {
            RedEnergy++;
            if (MaxEnergy < RedEnergy)
            {
                RedEnergy = MaxEnergy;
            }
        }
        if (BlueOn && BlueEnergy > 0)
        {
            BlueEnergy--;
        }
        else
        {
            BlueEnergy++;
            if (MaxEnergy < BlueEnergy)
            {
                BlueEnergy = MaxEnergy;
            }
        }
        if (BlackOn && BlackEnergy > 0)
        {
            BlackEnergy--;
        }
        else
        {
            BlackEnergy++;
            if (MaxEnergy < BlackEnergy)
            {
                BlackEnergy = MaxEnergy;
            }
        }
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

        //キー入力
        if (Input.GetKey(KeyCode.Q) && RedEnergy > 100)
        {
            BarrierCreate(prefabRed);
            RedOn = true;
        }
        else if (Input.GetKey(KeyCode.W) && BlueEnergy > 100)
        {
            BarrierCreate(prefabBlue);
            BlueOn = true;
        }
        else if (Input.GetKey(KeyCode.E) && BlackEnergy > 100)
        {
            BarrierCreate(prefabBlack);
            BlackOn = true;
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
        Vector3 pos = new Vector3(transform.position.x + 0.5f, transform.position.y, 0.0f);
        // ゲームオブジェクトの生成
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(0.6f, 1.0f, 1.0f);

        BarrierCount++;
    }
}

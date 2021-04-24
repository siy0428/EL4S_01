using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private GameObject ScoreObj;
    private int Score = 0;

    void Start() {

    }

    void Update() {

        // 時間経過から進んだ距離をmにしてスコアに代入
        Time.timeScale = 5.0f;
        Score = (int)Time.time;

        Text Scoretxt = ScoreObj.GetComponent<Text>();
        Scoretxt.text = "SCORE:" + Score.ToString("D5")+"m";
    }
}

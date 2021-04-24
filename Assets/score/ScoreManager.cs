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

        // ���Ԍo�߂���i�񂾋�����m�ɂ��ăX�R�A�ɑ��
        Time.timeScale = 5.0f;
        Score = (int)Time.time;

        Text Scoretxt = ScoreObj.GetComponent<Text>();
        Scoretxt.text = "SCORE:" + Score.ToString("D5")+"m";
    }
}

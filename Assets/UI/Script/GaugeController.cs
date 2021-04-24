using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GaugeController : MonoBehaviour {

    [HideInInspector] public bool isUseBlue;
    [HideInInspector] public bool isUseRed;
    [HideInInspector] public bool isUseBlack;

    [HideInInspector] public bool isBlue;
    [HideInInspector] public bool isRed;
    [HideInInspector] public bool isBlack;

    [SerializeField] private float Blue_dur = 1.0f;
    [SerializeField] private float Red_dur = 1.0f;
    [SerializeField] private float Black_dur = 1.0f;

    [SerializeField] private float GaugeMax = 1.0f;

    [SerializeField] private Slider blue;
    [SerializeField] private Slider red;
    [SerializeField] private Slider black;


    void Start() {
        isBlue = true;
        isRed = true;
        isBlack = true;
    }

    void Update() {
        if (isUseBlue) {
            Blue_dur -= 1.0f / 90.0f;

            if (Blue_dur <= 0) {
                Blue_dur = -1.0f;
                isUseBlue = false;
            }
        }

        if (isUseRed) {
            Red_dur -= 1.0f / 90.0f;

            if (Red_dur <= 0) {
                Red_dur = -1.0f;
                isUseRed = false;
            }
        }

        if (isUseBlack) {
            Black_dur -= 1.0f / 90.0f;


            if (Black_dur <= 0) {
                Black_dur = -1.0f;
            }
        }

        if (Blue_dur <= 0) {
            isBlue = false;
        }else {
            isBlue = true;
        }

        if (Red_dur <= 0) {
            isRed = false;
        }
        else {
            isRed = true;
        }

        if (Black_dur <= 0) {
            isBlack = false;
        }
        else {
            isBlack = true;
        }

        blue.value = Blue_dur;
        red.value = Red_dur;
        black.value = Black_dur;


        Blue_dur += 1.0f / 180.0f;
        Red_dur += 1.0f / 180.0f;
        Black_dur += 1.0f / 180.0f;

        if (Blue_dur >= GaugeMax) {
            Blue_dur = GaugeMax;
        }
        if (Red_dur >= GaugeMax) {
            Red_dur = GaugeMax;
        }
        if (Black_dur >= GaugeMax) {
            Black_dur = GaugeMax;
        }

    }


    public void SetisUseBlue(bool isUse) {
        isUseBlue = isUse;
    }

    public void SetisUseRed(bool isUse) {
        isUseRed = isUse;
    }

    public void SetisUseBlack(bool isUse) {
        isUseBlack = isUse;
    }
    
    public bool GetisBlue() {
        return isBlue;
    }

    public bool GetisRed() {
        return isRed;
    }

    public bool GetisBlack() {
        return isBlack;
    }
}

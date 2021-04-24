using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakObj : MonoBehaviour {
    void Start() {
        DontDestroyOnLoad(this);
    }

    void Update() {

    }
}

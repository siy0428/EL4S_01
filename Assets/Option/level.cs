//---------------------------------------------------
//
//“ïˆÕ“x
//
//---------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    int Level;
    // Start is called before the first frame update
    void Start()
    {
        Level = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        Level += 1;
        Debug.Log("LevelUP" + Level);
    }
    public int GetLevel()
    {
        return Level;
    }
}

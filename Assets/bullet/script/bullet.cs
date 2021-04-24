//---------------------------------------------------
//
//弾のスクリプト
//
//---------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Level = GameObject.Find("degree of difficulty");
        float levelspeed= Level.GetComponent<level>().GetLevel();
        speed += levelspeed * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos;

        Pos = transform.position;

        Pos.x -= speed;

        transform.position = Pos;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "delete")
        {
            Destroy(this.gameObject);
        }
    }
}

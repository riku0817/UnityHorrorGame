using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScript : MonoBehaviour {
    [SerializeField] GameObject Chair;
  // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ログを表示する
        Chair.layer=3;
    }
}
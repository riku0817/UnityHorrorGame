using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlankEvent : MonoBehaviour
{
  [SerializeField] GameObject Object;
  [SerializeField] GameObject clicktext;
  [SerializeField] GameObject bar;
  [SerializeField] GameObject message1;
  [SerializeField] GameObject message2;
  [SerializeField] Light spotlight;
  AudioSource audioSource;
  public AudioClip plankbreakSound;


  // 当たっている時に呼ばれる関数
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "FPSController")
    {
      var outline = Object.GetComponent<Outline>();
      outline.enabled = true;
    }
  }
  async void OnCollisionStay(Collision collision)
  {
    if (collision.gameObject.name == "FPSController")
    {
      clicktext.SetActive(true);
      Debug.Log(collision.gameObject.name + "と衝突した"); // ログを表示する
      if (Input.GetMouseButton(0))
      {
        if (bar.activeSelf == false)
        {
          audioSource = GetComponent<AudioSource>();
          audioSource.PlayOneShot(plankbreakSound);
          var boxcollider = Object.GetComponent<BoxCollider>();
          boxcollider.enabled = false;
          clicktext.SetActive(false);
          Vector3 position = Object.transform.position; // ローカル変数に格納
          var outline = Object.GetComponent<Outline>();
          outline.enabled=false;
          for (float i = 0f; i < 7f; i += 0.1f)
          {
            position.y -= 0.1f; // ローカル変数に格納した値を上書き
            Object.transform.position = position; // ローカル変数を代入
            await UniTask.Delay(10);
          }
          Object.SetActive(false);
        }
        else
        {
          message1.SetActive(true);
        }

        Debug.Log("Clicked");
      }
    }

  }

  //オブジェクトが離れた時
  void OnCollisionExit(Collision collision)
  {
    var outline = Object.GetComponent<Outline>();
    clicktext.SetActive(false);
    Debug.Log("Leave"); // ログを表示する
    outline.enabled = false;
  }
}


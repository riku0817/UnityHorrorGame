using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorEvent : MonoBehaviour
{
  [SerializeField] GameObject Object;
  [SerializeField] GameObject clicktext;
  [SerializeField] GameObject message;
  AudioSource audioSource;
  public AudioClip doorSound;
  // 当たっている時に呼ばれる関数
  void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
        var outline = Object.GetComponent<Outline>();
        outline.enabled = true;
        }
    }
  void OnCollisionStay(Collision collision)
  {
    if (collision.gameObject.name == "FPSController")
    {
      clicktext.SetActive(true);
      Debug.Log(collision.gameObject.name+"と衝突した"); // ログを表示する
      if (Input.GetMouseButtonDown(0))
      {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(doorSound);
        Debug.Log("Clicked");
        message.SetActive(true);
      }
    }

  }

  //オブジェクトが離れた時
  void OnCollisionExit(Collision collision)
  {
    var outline = Object.GetComponent<Outline>();
    clicktext.SetActive(false);
    Debug.Log("Leave"); // ログを表示する
    outline.enabled=false;
  }
}


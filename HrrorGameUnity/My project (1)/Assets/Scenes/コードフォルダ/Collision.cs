using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScript : MonoBehaviour
{
  [SerializeField] GameObject Object;
  [SerializeField] GameObject clicktext;
  [SerializeField] GameObject message;
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
      Debug.Log(collision.gameObject.name + "と衝突した"); // ログを表示する
      if (Input.GetMouseButton(0))
      {
        clicktext.SetActive(false);
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
    outline.enabled = false;
  }
}

/// <summary>
/// GameObjectの拡張クラス
/// </summary>
public static class GameObjectExtension
{

  /// <summary>
  /// レイヤーを設定する
  /// </summary>
  /// <param name="needSetChildrens">子にもレイヤー設定を行うか</param>
  public static void SetLayer(this GameObject gameObject, int layerNo, bool needSetChildrens = true)
  {
    if (gameObject == null)
    {
      return;
    }
    gameObject.layer = layerNo;

    //子に設定する必要がない場合はここで終了
    if (!needSetChildrens)
    {
      return;
    }

    //子のレイヤーにも設定する
    foreach (Transform childTransform in gameObject.transform)
    {
      SetLayer(childTransform.gameObject, layerNo, needSetChildrens);
    }
  }

  /// <summary>
  /// マテリアル設定
  /// </summary>
  /// <param name="needSetChildrens">子にもマテリアル設定を行うか</param>
  public static void SetMaterial(this GameObject gameObject, Material setMaterial, bool needSetChildrens = true)
  {
    if (gameObject == null)
    {
      return;
    }

    //レンダラーがあればそのマテリアルを変更
    if (gameObject.GetComponent<Renderer>())
    {
      gameObject.GetComponent<Renderer>().material = setMaterial;
    }

    //子に設定する必要がない場合はここで終了
    if (!needSetChildrens)
    {
      return;
    }

    //子のマテリアルにも設定する
    foreach (Transform childTransform in gameObject.transform)
    {
      SetMaterial(childTransform.gameObject, setMaterial, needSetChildrens);
    }

  }


}
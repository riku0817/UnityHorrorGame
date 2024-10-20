using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ExitDoorScript : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] GameObject clicktext;
    [SerializeField] GameObject plank;
    [SerializeField] GameObject message;
    Animation anime;
    DoorAnimation dooranimationscript;
    AudioSource audioSource;
    public AudioClip doorOpenSound;
    public bool isMessageClosed2;
    public bool animationbool = true;
    // 当たっている時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController" && plank.activeSelf == false)
        {
            var outline = Object.GetComponent<Outline>();
            outline.enabled = true;
        }
    }
    async void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.name == "FPSController" && plank.activeSelf == false)
        {
            clicktext.SetActive(true);
            Debug.Log(collision.gameObject.name + "と衝突した"); // ログを表示する

            if (Input.GetMouseButton(0))
            {
                anime = this.gameObject.GetComponent<Animation>();
                audioSource = GetComponent<AudioSource>();
                Debug.Log("Clicked");
                // 暫定策：アニメーションを一回だけ再生
                if (animationbool == true)
                {
                    audioSource.PlayOneShot(doorOpenSound);
                    anime.Play();
                    animationbool = false;
                }
                message.SetActive(true);
                isMessageClosed2=false;
                await UniTask.WaitUntil(() => isMessageClosed2);
                SceneManager.LoadScene("EndingScene");
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

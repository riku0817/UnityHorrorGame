using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseDoor : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] GameObject clicktext;
    Animation anime;
    DoorAnimation dooranimationscript;

    AudioSource audioSource;
    public AudioClip doorOpenSound;

    public bool animationbool = true;
    // 当たっている時に呼ばれる関数
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            anime = this.gameObject.GetComponent<Animation>();
            audioSource = GetComponent<AudioSource>();
            clicktext.SetActive(true);
            Debug.Log(collision.gameObject.name + "と衝突した"); // ログを表示する
            Object.SetLayer(3);
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Clicked");
                // 暫定策：アニメーションを一回だけ再生
                if (animationbool == true)
                {
                    audioSource.PlayOneShot(doorOpenSound);
                    anime.Play();
                    animationbool = false;
                }
            }

        }

    }

    //オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
        clicktext.SetActive(false);
        Debug.Log("Leave"); // ログを表示する
        Object.SetLayer(0);
    }
}
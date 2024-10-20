using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;


public class Event2 : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject FPSController;
    [SerializeField] GameObject Ghost;
    [SerializeField] GameObject message;

    [SerializeField] Light spotlight;
    AudioSource audioSource;
    public AudioClip lightOffsound;
    public AudioClip impactSound;
    public AudioClip electricSound;
    public AudioClip heartbeatSound;
    public bool isEvent;
    public bool isMessageClosed;

    async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            message.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            Debug.Log("イベント発生");
            var boxCollider = eventpanel.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            // ライトオフ
            audioSource.PlayOneShot(lightOffsound);
            flashlight.SetActive(false);
            GameObject obj = GameObject.Find("Flashlight");
            var flashlightComponent = obj.GetComponent<FlashLight>();
            flashlightComponent.lightonoff = false;
            isEvent=true;
            // 操作停止
            var firstpersoncontroller = FPSController.GetComponent<FirstPersonController>();
            firstpersoncontroller.enabled = false;
            // F押下でびっくりイベント発動
            isMessageClosed=false;
            await UniTask.WaitUntil(() => isMessageClosed);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.F));
            Ghost.SetActive(true);
            audioSource.PlayOneShot(impactSound);
            audioSource.PlayOneShot(heartbeatSound);
            isEvent=false;
            firstpersoncontroller.enabled =true;
            await UniTask.Delay(1500);
            audioSource.PlayOneShot(electricSound);
            spotlight.intensity=0f;
            Ghost.SetActive(false);
            await UniTask.Delay(500);
            for(float i=0;i<21.64f;i+=0.01f)
            {
                spotlight.intensity=i;
                await UniTask.Delay(1);
            }
        }
        
    }


}

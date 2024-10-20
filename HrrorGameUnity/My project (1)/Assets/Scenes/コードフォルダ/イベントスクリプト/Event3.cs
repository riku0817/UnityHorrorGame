using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    [SerializeField] GameObject Ghost;
    public AudioClip creepySound;
    AudioSource audioSource;
    async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            audioSource = GetComponent<AudioSource>();
            Debug.Log("イベント発生");
            var eventScript = eventpanel.GetComponent<BoxCollider>();
            eventScript.enabled = false;
            audioSource.PlayOneShot(creepySound);
            Vector3 position = Ghost.transform.position; // ローカル変数に格納
            for(float i=0f;i<1f;i+=0.1f)
            {position.x += 0.1f; // ローカル変数に格納した値を上書き
            Ghost.transform.position = position; // ローカル変数を代入
            await UniTask.Delay(10);
            }
            Ghost.SetActive(false);
        }
    }
}

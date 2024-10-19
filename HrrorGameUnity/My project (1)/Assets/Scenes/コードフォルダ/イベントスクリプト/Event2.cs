using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    [SerializeField] GameObject eventpanel;
    [SerializeField] GameObject flashlight;
    AudioSource audioSource;
    public AudioClip lightOffsound;
    [SerializeField] GameObject message;

    void OnCollisionEnter(Collision collision)
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
        }
    }

}

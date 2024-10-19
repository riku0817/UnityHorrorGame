using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    [SerializeField] BreakableWindow[] BreakableObjects;
    [SerializeField] GameObject eventpanel;
    public AudioClip heartbeat;
    AudioSource audioSource;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            foreach(var BreakObjects in BreakableObjects)
            {
                if(!BreakObjects.isBroken)
                {
                    BreakObjects.breakWindow();
                }
            }
            audioSource = GetComponent<AudioSource>();
            Debug.Log("イベント発生");
            var eventScript = eventpanel.GetComponent<BoxCollider>();
            eventScript.enabled = false;
            audioSource.PlayOneShot(heartbeat);
        }
    }
}

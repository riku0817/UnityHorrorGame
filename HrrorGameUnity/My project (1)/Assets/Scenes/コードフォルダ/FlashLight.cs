using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    public AudioClip lightOnsound;
    public AudioClip lightOffsound;
    AudioSource audioSource;
    

    public bool lightonoff = true;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //ライトオフ
        if (Input.GetKeyDown(KeyCode.F) && lightonoff == true)
        {
            audioSource.PlayOneShot(lightOffsound);
            lightonoff = false;
            flashlight.SetActive(false);
        }
        //ライトオン
        else if (Input.GetKeyDown(KeyCode.F) && lightonoff == false)
        {
            audioSource.PlayOneShot(lightOnsound);
            lightonoff = true;
            flashlight.SetActive(true);
        }
    }
}

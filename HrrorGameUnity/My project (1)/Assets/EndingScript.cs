using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        await UniTask.Delay(10000);
        SceneManager.LoadScene("MenuScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Option;
    public void StartButton()
    {
        SceneManager.LoadScene("HospitalScene");
    }
    public void ShowOption()
    {
        Option.SetActive(true);
    }
      public void HideOption()
    {
        Option.SetActive(false);
    }
}
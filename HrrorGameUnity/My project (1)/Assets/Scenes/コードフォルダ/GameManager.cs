using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool optionbool = false;
    [SerializeField] GameObject Option;
    public void StartButton()
    {
        SceneManager.LoadScene("HospitalScene");
    }

    public void ReturnMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
        Option.SetActive(false);
        optionbool = false;
    }
        public void GameExitButton()
    {
       Application.Quit();
    }
    public void ShowOption()
    {
        Option.SetActive(true);
        optionbool = true;
    }
    public void HideOption()
    {
        Option.SetActive(false);
        optionbool = false;
    }

    //ESCオプション画面表示
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionbool == false)
            {
                Option.SetActive(true);
                optionbool = true;
            }
            else if (optionbool == true)
            {
                Option.SetActive(false);
                optionbool = false;
            }


        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    bool optionbool = false;
    [SerializeField] GameObject Option;
    [SerializeField] GameObject FPSController;
    [SerializeField] GameObject Reticle;
    [SerializeField] GameObject FirstPersonCharacter;

    public void StartButton()
    {
        // ゲームスタートボタン
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("HospitalScene");

    }

    public void ReturnMenuButton()
    {
        //メニュー画面に戻るボタン
        SceneManager.LoadScene("MenuScene");
        Option.SetActive(false);
        optionbool = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GameExitButton()
    {
        //ゲーム終了ボタン
        Application.Quit();
    }
    public void ShowOption()
    {
        //オプション表示ボタン
        Option.SetActive(true);
        optionbool = true;
    }
    public void HideOption()
    {
        //オプション非表示メゾット
        Option.SetActive(false);
        optionbool = false;
    }

    public void InGameShowOption()
    {
        //ゲーム内オプション表示メソッド
        var firstpersoncontroller = FPSController.GetComponent<FirstPersonController>();
        var capsulecollider = FirstPersonCharacter.GetComponent<CapsuleCollider>();
        Option.SetActive(true);
        optionbool = true;
        firstpersoncontroller.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Reticle.SetActive(false);
        capsulecollider.isTrigger=true;
    }
    public void InGameHideOption()
    {
        //ゲーム内オプション非表示メソッド
        var firstpersoncontroller = FPSController.GetComponent<FirstPersonController>();
        var capsulecollider = FirstPersonCharacter.GetComponent<CapsuleCollider>();
        Option.SetActive(false);
        optionbool = false;
        firstpersoncontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Reticle.SetActive(true);
        capsulecollider.isTrigger=false;
    }



    //ゲーム内で常にループしてるメソッド
    void Update()
    {
        //ESCオプション画面表示 ※メニュー画面以外のシーンで有効
        if (SceneManager.GetActiveScene().name != "MenuScene" && Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionbool == false)
            {
                InGameShowOption();
            }
            else if (optionbool == true)
            {
                InGameHideOption();
            }


        }
    }

}
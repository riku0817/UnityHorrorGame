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
        Option.SetActive(true);
        optionbool = true;
        firstpersoncontroller.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Reticle.SetActive(false);
    }
    public void InGameHideOption()
    {
        //ゲーム内オプション非表示メソッド
        var firstpersoncontroller = FPSController.GetComponent<FirstPersonController>();
        Option.SetActive(false);
        optionbool = false;
        firstpersoncontroller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Reticle.SetActive(true);
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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {

        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
    }

}
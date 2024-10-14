using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] GameObject SelectedItem;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 当たったオブジェクトをログに出力する
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
    }
}

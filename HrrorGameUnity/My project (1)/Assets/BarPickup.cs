using UnityEngine;

public class BarPickup : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    // バールを取得した時の処理
                    Pickup();
                }
            }
        }
    }

    void Pickup()
    {
        Debug.Log("バールを取得しました！");
        // バールを非表示にする場合
        gameObject.SetActive(false);
        // 他の処理（例えば、インベントリに追加）をここに追加
    }
}

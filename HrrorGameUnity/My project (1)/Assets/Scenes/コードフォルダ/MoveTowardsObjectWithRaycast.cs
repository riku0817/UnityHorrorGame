using UnityEngine;

public class MoveTowardsObjectWithRaycast : MonoBehaviour
{
    public GameObject currentDrawer;
    public Transform objectA; // オブジェクトAのTransform
    public Transform objectB; // オブジェクトBのTransform
    public float raycastDistance = 10f; // Raycastの長さ
    void switchLayer(GameObject obj, string layerName)
    {
        obj.layer = LayerMask.NameToLayer(layerName);
    }

    private void Update()
    {
        // オブジェクトAからオブジェクトBへRaycastを発射
        RaycastHit hit;
        Vector3 direction = (objectB.position - objectA.position).normalized;
        if (Physics.Raycast(objectA.position, direction, out hit, raycastDistance))
        {
            if (hit.transform == objectB)
            {
                // オブジェクトBを検知した場合、y軸の正の方向に移動
                switchLayer(currentDrawer, "Outline");
            }
            if (hit.transform != objectB)
            {
                // オブジェクトBを検知した場合、y軸の正の方向に移動
                switchLayer(currentDrawer, "Default");
            }
        }
        if (hit.transform != objectB)
        {
            // オブジェクトBを検知した場合、y軸の正の方向に移動
            switchLayer(currentDrawer, "Default");
        }
    }
}

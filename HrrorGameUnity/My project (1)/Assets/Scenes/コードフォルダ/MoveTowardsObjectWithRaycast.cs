using UnityEngine;

public class MoveTowardsObjectWithRaycast : MonoBehaviour
{
    public GameObject currentDrawer;
    public Transform objectA; // �I�u�W�F�N�gA��Transform
    public Transform objectB; // �I�u�W�F�N�gB��Transform
    public float raycastDistance = 10f; // Raycast�̒���
    void switchLayer(GameObject obj, string layerName)
    {
        obj.layer = LayerMask.NameToLayer(layerName);
    }

    private void Update()
    {
        // �I�u�W�F�N�gA����I�u�W�F�N�gB��Raycast�𔭎�
        RaycastHit hit;
        Vector3 direction = (objectB.position - objectA.position).normalized;
        if (Physics.Raycast(objectA.position, direction, out hit, raycastDistance))
        {
            if (hit.transform == objectB)
            {
                // �I�u�W�F�N�gB�����m�����ꍇ�Ay���̐��̕����Ɉړ�
                switchLayer(currentDrawer, "Outline");
            }
            if (hit.transform != objectB)
            {
                // �I�u�W�F�N�gB�����m�����ꍇ�Ay���̐��̕����Ɉړ�
                switchLayer(currentDrawer, "Default");
            }
        }
        if (hit.transform != objectB)
        {
            // �I�u�W�F�N�gB�����m�����ꍇ�Ay���̐��̕����Ɉړ�
            switchLayer(currentDrawer, "Default");
        }
    }
}

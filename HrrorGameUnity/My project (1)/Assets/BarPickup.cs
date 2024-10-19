using UnityEngine;

public class BarPickup : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    // �o�[�����擾�������̏���
                    Pickup();
                }
            }
        }
    }

    void Pickup()
    {
        Debug.Log("�o�[�����擾���܂����I");
        // �o�[�����\���ɂ���ꍇ
        gameObject.SetActive(false);
        // ���̏����i�Ⴆ�΁A�C���x���g���ɒǉ��j�������ɒǉ�
    }
}

using UnityEngine;

public class BarPickup : MonoBehaviour
{
    [SerializeField] GameObject clicktext;
    [SerializeField] GameObject eventTrigger1;
    [SerializeField] GameObject message;
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
                    message.SetActive(true);
                }
            }
        }
    }

    void Pickup()
    {
        eventTrigger1.SetActive(true);
        clicktext.SetActive(false);
        Debug.Log("�o�[�����擾���܂����I");
        // �o�[�����\���ɂ���ꍇ
        gameObject.SetActive(false);
        // ���̏����i�Ⴆ�΁A�C���x���g���ɒǉ��j�������ɒǉ�
    }
}

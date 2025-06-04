using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;         // ���� ��� (�÷��̾�)
    private Vector3 offset;          // �ʱ� ��� ��ġ (ī�޶� - �÷��̾�)

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("FollowCamera: Ÿ���� �������� �ʾҽ��ϴ�.");
            return;
        }

        offset = transform.position - target.position; // ���� ��ġ������ ��� �Ÿ� ����
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            // ȸ���� ������ ���¸� ���� (�ʱ� ȸ�� ����)
        }
    }
}

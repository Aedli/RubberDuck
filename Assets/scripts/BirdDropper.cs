using UnityEngine;

public class BirdDropper : MonoBehaviour
{
    public GameObject branchPrefab;//����߸� ������
    public float flySpeed = 5f;

    private float dropX;//����߸� X��ǥ
    private bool hasDropped = false;

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.right);
        //���� ��ǥ ���� ����
        dropX = Random.Range(-4f, 4f);
    }

    void Update()
    {
        //���������� �̵�
        transform.position += transform.forward * flySpeed * Time.deltaTime;

        if(!hasDropped && transform.position.x >= dropX)
        {
            DropBranch();
            hasDropped = true;
        }

        //ȭ�� ����� �ı�
        if(transform.position.x > 15f)
        {
            Destroy(gameObject);
        }
    }

    void DropBranch()
    {
        Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(branchPrefab, dropPosition, Quaternion.identity);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleFloat : MonoBehaviour
{
    public Vector3 flowDirection = new Vector3(0, 0, -1); // �帣�� ����
    public float flowSpeed = 2f;

    private Rigidbody rb;
    public PlayerController player;
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // �߷� ��Ȱ��ȭ (���� �� �ִ� ���¶� ����)
    }

    void FixedUpdate()
    {
        // ������ �ӵ��� �̵�
        rb.linearVelocity = flowDirection.normalized * flowSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player = collision.gameObject.GetComponent<PlayerController>();
            player.Lives[player.hp - 1].SetActive(false);
            player.hp -= 1;
            player.isNodamage = true;
        }
    }
}

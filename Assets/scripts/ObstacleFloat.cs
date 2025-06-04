using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleFloat : MonoBehaviour
{
    public Vector3 flowDirection = new Vector3(0, 0, -1); // 흐르는 방향
    public float flowSpeed = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // 중력 비활성화 (물에 떠 있는 상태라 가정)
    }

    void FixedUpdate()
    {
        // 일정한 속도로 이동
        rb.velocity = flowDirection.normalized * flowSpeed;
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
        }
    }
}

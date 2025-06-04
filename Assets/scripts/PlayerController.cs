using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed = 5f; // �ִ� �ӵ� ����

    private Rigidbody rb;
    private Vector3 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveInput = new Vector3(h, 0, v).normalized;
    }

    private void FixedUpdate()
    {
        // ���� �༭ �̵�
        rb.AddForce(moveInput * moveSpeed, ForceMode.Force);

        // ���� ����: ���� �̵� �ӵ��� ����
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
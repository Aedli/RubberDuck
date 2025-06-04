using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxSpeed = 5f; // 최대 속도 제한

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
        // 힘을 줘서 이동
        rb.AddForce(moveInput * moveSpeed, ForceMode.Force);

        // 가속 방지: 수평 이동 속도만 제한
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
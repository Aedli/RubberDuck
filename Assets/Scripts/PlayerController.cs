using UnityEngine;

public class PLayerController : MonoBehaviour
{

    public int hp = 3;
    public float NodamageTime = 1.0f; //무적시간
    public bool isNodamage = false;        //충돌 판단
                                           // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 5f;
    public float maxSpeed = 5f; // 최대 속도 제한

    private Rigidbody rb;
    private Vector3 moveInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isNodamage)
        {
            NodamageTime -= Time.deltaTime;
        }
        if(NodamageTime < 0.0f)
        {
            isNodamage = false;
            NodamageTime = 1.0f;
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && isNodamage == false)      //무적시간 이후 맞았을시
        {
            Debug.Log("꿱");
            hp -= 1;
            isNodamage = true;                               //무적 시간 on
        }
    }
}

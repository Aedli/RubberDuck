using UnityEngine;

public class PLayerController : MonoBehaviour
{

    public int hp = 3;
    public float NodamageTime = 1.0f; //�����ð�
    public bool isNodamage = false;        //�浹 �Ǵ�
                                           
    public GameObject[] Lives = new GameObject[3];  //생명 이미지 갯수따라서
    
    public float moveSpeed = 5f;
    public float maxSpeed = 5f; // �ִ� �ӵ� ����

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
        // ���� �༭ �̵�
        rb.AddForce(moveInput * moveSpeed, ForceMode.Force);

        // ���� ����: ���� �̵� �ӵ��� ����
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && isNodamage == false)      //�����ð� ���� �¾�����
        {
            Debug.Log("��");
            Lives[hp-1].SetActive(false);                    //맞을때마다 하나씩 목숨 이미지 제거
            hp -= 1;                        
            isNodamage = true;                               //���� �ð� on
            
        }
    }
}

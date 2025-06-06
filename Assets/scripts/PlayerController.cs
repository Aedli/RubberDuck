using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int hp = 3;
    public float NodamageTime = 1.0f; //�����ð�
    public bool isNodamage = false;        //�浹 �Ǵ�
                                           
    public GameObject[] Lives = new GameObject[3];  //생명 이미지 갯수따라서
    public TimeController timeController;

    public float moveSpeed = 5f;
    public float maxSpeed = 5f; // �ִ� �ӵ� ����
    private float originalMaxSpeed;

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
       
        if(other.tag == "Goal")
        {
            timeController.isGoal = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            StartCoroutine(SpeedBoost());
            Destroy(col.gameObject);
        }
    }
    IEnumerator SpeedBoost()
    {
        maxSpeed = 10f;

        //현재 속도를 바로 10으로 올림
        Vector3 boostDirection = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).normalized;
        rb.linearVelocity = boostDirection * maxSpeed + new Vector3(0, rb.linearVelocity.y, 0);

        yield return new WaitForSeconds(5f);

        maxSpeed = moveSpeed;

        Vector3 slowDirection = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).normalized;
        rb.linearVelocity = slowDirection * maxSpeed + new Vector3(0, rb.linearVelocity.y, 0);
    }
}

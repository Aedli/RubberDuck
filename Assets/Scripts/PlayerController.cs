using UnityEngine;

public class PLayerController : MonoBehaviour
{

    public int hp = 3;
    public float NodamageTime = 1.0f; //�����ð�
    public bool isNodamage = false;        //�浹 �Ǵ�
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && isNodamage == false)      //�����ð� ���� �¾�����
        {
            Debug.Log("��");
            hp -= 1;
            isNodamage = true;                               //���� �ð� on
        }
    }
}

using UnityEngine;

public class PLayerController : MonoBehaviour
{

    public int hp = 3;
    public float NodamageTime = 1.0f; //무적시간
    public bool isNodamage = false;        //충돌 판단
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
        if(other.tag == "Enemy" && isNodamage == false)      //무적시간 이후 맞았을시
        {
            Debug.Log("꿱");
            hp -= 1;
            isNodamage = true;                               //무적 시간 on
        }
    }
}

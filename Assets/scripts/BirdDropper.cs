using UnityEngine;

public class BirdDropper : MonoBehaviour
{
    public GameObject branchPrefab;//¶³¾î¶ß¸± ÇÁ¸®Æé
    public float flySpeed = 5f;

    private float dropX;//¶³¾î¶ß¸± XÁÂÇ¥
    private bool hasDropped = false;

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.right);
        //¶³±¼ ÁÂÇ¥ ·£´ý ¼±ÅÃ
        dropX = Random.Range(-4f, 4f);
    }

    void Update()
    {
        //¿À¸¥ÂÊÀ¸·Î ÀÌµ¿
        transform.position += transform.forward * flySpeed * Time.deltaTime;

        if(!hasDropped && transform.position.x >= dropX)
        {
            DropBranch();
            hasDropped = true;
        }

        //È­¸é ¹þ¾î³ª¸é ÆÄ±«
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

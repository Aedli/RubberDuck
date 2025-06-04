using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public Vector3 flowDirection = new Vector3(0, 0, -1); // -Z πÊ«‚
    public float flowStrength = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(flowDirection.normalized * flowStrength, ForceMode.Force);
    }
}

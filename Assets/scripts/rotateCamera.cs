using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 100f;
    

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(Vector3.zero, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}

using UnityEngine;

public class SpinBob : MonoBehaviour
{
    public float rotationSpeed; 
    public float bobSpeed; 
    public float bobHeight; 

    private float rotationDirection; 
    private float yMovementDirection = 1f;
    float upperBound;
    float lowerBound;
    void Start()
    {
        // left or right direction
        rotationDirection = Random.Range(0, 2) == 0 ? -1f : 1f;

        upperBound = transform.position.y + bobHeight;
        lowerBound = transform.position.y - bobHeight;
    }

    void Update()
    {
        //rotates left right
        transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);

        // bobs up and down
        transform.Translate(Vector3.up * Time.deltaTime * bobSpeed * yMovementDirection);

        // invert up-down movement 
        if (transform.position.y > upperBound || transform.position.y < lowerBound)
        {
            yMovementDirection = -yMovementDirection;
        }
    }
}

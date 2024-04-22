using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public GameObject focalPoint;
    private Rigidbody rb;
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        manager.Fall_Det_Reset(transform);
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = Camera.main.transform.forward * moveSpeed * verticalInput;
        rb.AddForce(movement, ForceMode.Impulse);



    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col detected...");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy collison adding force: ");
            Vector3 impactDir = Vector3.Reflect(collision.transform.position - rb.transform.position, collision.contacts[0].normal).normalized;
            // gets impactforce 
            float impactForce = collision.gameObject.GetComponent<EnemyStats>().impactForce;
            rb.AddForce(impactDir * impactForce, ForceMode.Impulse);
        }    
    }
}

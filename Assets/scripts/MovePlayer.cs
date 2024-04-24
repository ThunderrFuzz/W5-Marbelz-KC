using UnityEngine;

public class PlayerMove : PickupManager
{
    public float moveSpeed;
    float boostSpeed;
    public GameObject focalPoint;
    Rigidbody rb;
    GameManager manager;
   

    void Start()
    {
       
        manager = FindObjectOfType<GameManager>();
        
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        boostSpeed = speedBoost ?  5f : 1;
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = Camera.main.transform.forward *( moveSpeed * boostSpeed )* verticalInput;
        rb.AddForce(movement, ForceMode.Impulse);
        manager.Fall_Det_Reset(transform);
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Vector3 impactDir = Vector3.Reflect(collision.transform.position - rb.transform.position, collision.contacts[0].normal).normalized;
            // gets impactforce 
            float impactForce = collision.gameObject.GetComponent<EnemyStats>().impactForce;
            healthManager.TakeDamage(5);
            score.TakeScore(5);
            rb.AddForce(impactDir * impactForce, ForceMode.Impulse);
        }    
    }
}

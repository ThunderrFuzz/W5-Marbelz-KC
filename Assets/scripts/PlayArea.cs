using UnityEngine;

public class PlayArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Despawner"))
        {
            
            Destroy(gameObject);
        }
    }
}

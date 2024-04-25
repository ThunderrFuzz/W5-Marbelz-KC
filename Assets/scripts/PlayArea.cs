using UnityEngine;

public class PlayArea : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "Player" || col.tag == "Projectile" || col.tag == "Enemy") && col.tag == "Despawner")
        {
            Destroy(col.gameObject);
            
        }

    }
}


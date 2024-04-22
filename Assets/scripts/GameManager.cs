using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    private Vector3 initialPlayerPosition; 
    protected int deathCount = 0; 

    void Start()
    {
        initialPlayerPosition = Vector3.zero;
    }

    public void Fall_Det_Reset(Transform playerTransform)
    {
        if (playerTransform.position.y < -5f)
        {
            RecordDeath();
            ResetPlayer(playerTransform);
        }
    }

    
    private void RecordDeath()
    {
        deathCount++;
        Debug.Log("Player died! Deaths: " + deathCount);
    }

    
    private void ResetPlayer(Transform playerTransform)
    {
        // if no positon then spawn in deafault
        if (spawnPoints.Length == 0)
        {
            playerTransform.position = initialPlayerPosition;
        }
        else
        {
            // select a random spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            playerTransform.position = randomSpawnPoint.position;
        }
    }

    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

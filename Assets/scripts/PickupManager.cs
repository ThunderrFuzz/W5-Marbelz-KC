using System.Collections;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DoubleFire":
                ActivateDoubleFire();
                break;
            case "HealthPot":
                AddHealth();
                break;
            case "ScoreMulti":
                ActivateScoreMultiplier();
                break;
            case "GemCollectable":
                AddGemScore();
                break;
            case "Fire":
                ActivateFireEffect();
                break;
            case "Money":
                AddMoney();
                break;
            case "Nuke":
                ExplodeEnemies();
                break;
            case "Speedup":
                ActivateSpeedup();
                break;
            case "Secret":
                ActivateSecret();
                break;
            default:
                // if tag does nothing, do nothing....
                break;
        }
    }


    void ActivateDoubleFire()
    {
        // Implement DoubleFire effect
        Debug.Log("DoubleFire activated: Shoot 2 times projectiles at once for 30 seconds");
    }

    void AddHealth()
    {
        // Implement HealthPot effect
        Debug.Log("HealthPot collected: +3 lives");
    }

    void ActivateScoreMultiplier()
    {
        // Implement ScoreMulti effect
        Debug.Log("ScoreMultiplier activated: Double score for 30 seconds");
    }

    void AddGemScore()
    {
        // Implement GemCollectable effect
        Debug.Log("GemCollectable collected: +250 score");
    }

    void ActivateFireEffect()
    {
        // Implement Fire effect
        Debug.Log("Fire collected: Adds damage over time to enemies");
    }

    void AddMoney()
    {
        // Implement Money effect
        Debug.Log("Money collected: +500 Money");
    }

    void ExplodeEnemies()
    {
        // Implement Nuke effect
        Debug.Log("Nuke collected: Explodes!!! Adds force to every enemy");
    }

    void ActivateSpeedup()
    {
        // Implement Speedup effect
        Debug.Log("Speedup collected: Doubles movement speed for 5 seconds");
    }

    void ActivateSecret()
    {
        // Implement Secret effect
        Debug.Log("Secret collected: Doubles final score");
    }
    
}


/*
 tags & effect 
ScoreMulti : doubles score for 30 seconds
DoubleFire  : shoot 2  times projectiles at once  30 seconds
Fire  :  adds damage over time to enemies 
HealthPot : gives 3 more lives 
Speedup : doubles movement speed for 5 seconds



GemCollectable : +250 score 
Money : adds 500 Money 
Nuke : explodes!!! this needs to add force to every enemy  
Secret  :  doubles final score - is a bool 
 
 
 */

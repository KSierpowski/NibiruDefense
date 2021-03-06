using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int healthPoints = 10;
    [SerializeField] GameObject hitVFX;
  

    GameObject parentGameObject;
    ScoreBoard scoreBoard;




    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
     
        if (healthPoints < 1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()    
    {
    
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameObject.transform;     //klony zrobione wyzej (vfx) zamiast za?mieca? hierarchy s? wrzucany do pustego gameobject "parent"  
        scoreBoard.IncreaseScore(scorePerHit);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        healthPoints--;
        
    }



}

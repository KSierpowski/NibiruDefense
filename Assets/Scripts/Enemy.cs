using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
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
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;     //klony zrobione wyzej (vfx) zamiast zaœmiecaæ hierarchy s¹ wrzucany do pustego gameobject "parent"  
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        healthPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
        
    }



}

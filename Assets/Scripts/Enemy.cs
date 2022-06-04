using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int healthPoints = 10;


     ScoreBoard scoreBoard;


     void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    

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
        vfx.transform.parent = parent;     //klony zrobione wyzej (vfx) zamiast zaœmiecaæ hierarchy s¹ wrzucany do pustego gameobject "parent"  
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        healthPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
        
    }



}

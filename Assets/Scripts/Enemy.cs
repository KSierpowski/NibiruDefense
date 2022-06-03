using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Transform parent;
   

    void OnParticleCollision(GameObject other)
    {
       GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;     //klony zrobione wyzej (vfx) zamiast zaœmiecaæ hierarchy s¹ wrzucany do pustego gameobject "parent"
        Destroy(gameObject);
    }

   



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "--Collision--" + other.gameObject.name);
    }
    private void OnTriggerEnter (Collider other)

    {
        Debug.Log($"{this.name} --Trigger-- {other.gameObject.name}");
    }








}

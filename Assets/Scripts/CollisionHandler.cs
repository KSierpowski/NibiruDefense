using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]   float loadDelay = 2f;

    [SerializeField] ParticleSystem explosionVFX;

    void OnTriggerEnter(Collider other)

    {
        StartCrashSeqence();
    }

    private void StartCrashSeqence()
    {
        explosionVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }


    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
}
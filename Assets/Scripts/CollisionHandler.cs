using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float delay = 1.2f;
   [SerializeField] AudioClip successClip;
   [SerializeField] AudioClip deathClip;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
   AudioSource audioSource;
   bool isTransitioning;
    void Start()
    {
        isTransitioning = false;
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        string variableToCompare = other.gameObject.tag;
        if(isTransitioning) return;
        switch(variableToCompare) {
            case "Friendly": Debug.Log("Touched the friendly object");
            break; 
            case "Finish": StartNextLevelSequence(delay);
            break;
           
            default:
            Debug.Log("You died");
            StartCrashSequence(delay);
            break;
        }
    }
    void StartCrashSequence(float delay) {
        isTransitioning = true;
        audioSource.PlayOneShot(deathClip);
        deathParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Respawn", delay);
        
    }
    void Respawn() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadNextLevel() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(0);
        } 
        else
        SceneManager.LoadScene(currentScene+1);
    }
    void StartNextLevelSequence(float delay) {
        isTransitioning = true;
       successParticles.Play();
        audioSource.PlayOneShot(successClip);
        GetComponent<Movement>().enabled = false;
       
        Invoke("LoadNextLevel", delay);
        
    }
}

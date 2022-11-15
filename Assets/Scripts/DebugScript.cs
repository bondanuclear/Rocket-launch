using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugScript : MonoBehaviour
{
    bool colliderOFF = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
        DisableCollisions();
        } else if (Input.GetKeyDown(KeyCode.L))
        {
        LoadNextLevelCompulsory();
        }
    }
    void DisableCollisions() 
    {
       
            
            colliderOFF = !colliderOFF;
            GetComponent<BoxCollider>().enabled = colliderOFF;
        
    }
    void LoadNextLevelCompulsory() {
       
            Debug.Log("works");
            GetComponent<CollisionHandler>().LoadNextLevel();
        
    }
}

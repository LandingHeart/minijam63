using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{   
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = gameObject.scene;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){  // reload scene
            SceneManager.LoadScene(scene.name);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Debug.Log("Win. Next Level.");
            SceneManagerScript sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
            sceneManagerScript.nextLevel();
        }
    }
}

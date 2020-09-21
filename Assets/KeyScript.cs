using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator playerAnim;
    public GameObject nextLvlUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            playerAnim.SetTrigger("LevelUp");
            
            StartCoroutine(GoToNextLevel());
        }
    }


    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(2f);
        nextLvlUI.SetActive(true);
        Debug.Log("Win. Next Level.");
        //SceneManagerScript sceneManagerScript = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();
        //sceneManagerScript.nextLevel();
    }
}
        


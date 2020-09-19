using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] seeds;
    public GameObject[] trees;
    public bool on = false;
    bool is_Tree = false;
    GameObject player;
    public Animator[] treeAnimators;
    public Animator[] seedAnimators;
    public GameObject nowPlatform;
    public GameObject futurePlatform;
    bool inCooldown = false;

    void Start(){
        player = GameObject.Find("Player");
        //treeAnimator.SetTrigger("GrowSmall");

    }
    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    if(!inCooldown){
                        foreach (GameObject seed in seeds){
                            seed.SetActive(false);
                        }
                        foreach (GameObject tree in trees){
                            tree.SetActive(true);
                        }
                        
                        nowPlatform.SetActive(false);
                        futurePlatform.SetActive(true);

                        foreach (Animator treeAnimator in treeAnimators){
                            treeAnimator.SetTrigger("Grow");
                        }
                        
                        is_Tree = true;
                        on = false;
                        inCooldown = true;
                        StartCoroutine(cooldownQ());
                    }
                }
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    if(!inCooldown){
                        foreach (GameObject seed in seeds){
                            seed.SetActive(true);
                        }
                        
                        foreach (Animator treeAnimator in treeAnimators){
                            treeAnimator.SetTrigger("GrowSmall");
                        }
                        StartCoroutine(setToFalseInSeconds());
                        nowPlatform.SetActive(true);
                        futurePlatform.SetActive(false);
                        
                        is_Tree = false;
                        on = true;
                        inCooldown = true;
                        StartCoroutine(cooldownQ());
                    }
                }
            }
        }
    }
    IEnumerator setToFalseInSeconds()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject tree in trees){
            tree.SetActive(false);
        }
    }

    IEnumerator cooldownQ(){
        yield return new WaitForSeconds(1.5f);
        inCooldown = false;
    }

    public bool isTree(){
        return is_Tree;
    }
}

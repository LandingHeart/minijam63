using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] seeds;
    public GameObject[] trees;
    public Animator[] treeAnimators;
    public GameObject[] special_seeds;
    public GameObject[] special_trees;
    public Animator[] special_treeAnimators;

    bool on = true;
    bool is_Tree = false;
    GameObject player;
    public GameObject nowPlatform;
    public GameObject futurePlatform;
    public Animator[] nowAnimators;
    public Animator[] futureAnimators;
    bool inCooldown = false;
    public GameObject debris;
    public ParticleSystem particle;

    public GameObject nowBackground;
    public GameObject futureBackground;

    void Start(){
        player = GameObject.Find("Player");
        //treeAnimator.SetTrigger("GrowSmall");

    }
    // Update is called once per frame
    void Update()
    {
        if (on)  // toggle to Future, everything in Now shall collaspe
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                if (player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    if(!inCooldown){
                        futureBackground.SetActive(true);
                        nowBackground.SetActive(false);
                        if(debris != null)
                        {
                            debris.SetActive(true);
                            particle.Play();

                        }

                        if(!player.GetComponent<PlayerMovement>().isHoldingSpecialItem()){
                            foreach (GameObject special_seed in special_seeds){
                                special_seed.SetActive(false);
                                // Debug.Log(special_seed.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld());
                            }
                            foreach (GameObject special_tree in special_trees){
                                special_tree.SetActive(true);
                            }
                            foreach (Animator special_treeAnimator in special_treeAnimators){
                                special_treeAnimator.SetTrigger("Grow");
                            }
                        }
                        if(player.GetComponent<PlayerMovement>().isHoldingSpecialItem()){
                            foreach (GameObject special_seed in special_seeds){
                                if(!special_seed.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                                    special_seed.SetActive(false);
                            }
                            foreach (GameObject special_tree in special_trees){
                                if(!special_tree.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                                    special_tree.SetActive(true);
                            }
                            foreach (Animator special_treeAnimator in special_treeAnimators){
                                if(!special_treeAnimator.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                                    special_treeAnimator.SetTrigger("Grow");
                            }
                        }
                        foreach (GameObject seed in seeds){
                            if(seed != null)
                                seed.SetActive(false);
                        }
                        foreach (GameObject tree in trees){
                            if(tree != null)
                                tree.SetActive(true);
                        }
                        if(futurePlatform) futurePlatform.SetActive(true);

                        foreach (Animator treeAnimator in treeAnimators){
                            if(treeAnimator != null)
                                treeAnimator.SetTrigger("Grow");
                        }

                        foreach (Animator nowAnimator in nowAnimators){
                            if(nowAnimator != null)
                                nowAnimator.SetTrigger("Shrink");
                        }
                        foreach (Animator futureAnimators in futureAnimators){
                            if(futureAnimators != null)
                                futureAnimators.SetTrigger("Grow");
                        }

                        StartCoroutine("setBuildingsToFalseInSeconds", nowPlatform);
                        
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

                        futureBackground.SetActive(false);
                        nowBackground.SetActive(true);
                        //particle.Stop();
                        if(debris != null)
                        {
                            debris.SetActive(false);
                        }
                        if(!player.GetComponent<PlayerMovement>().isHoldingSpecialItem()){
                            foreach (GameObject special_seed in special_seeds){
                                special_seed.SetActive(true);
                            }
                            foreach (Animator special_treeAnimator in special_treeAnimators){
                                special_treeAnimator.SetTrigger("GrowSmall");
                            }
                            StartCoroutine(setSpecialTreeToFalseInSeconds());
                        }

                        if(player.GetComponent<PlayerMovement>().isHoldingSpecialItem()){
                            foreach (GameObject special_seed in special_seeds){
                                if(!special_seed.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                                    special_seed.SetActive(true);
                            }
                            foreach (Animator special_treeAnimator in special_treeAnimators){
                                if(!special_treeAnimator.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                                    special_treeAnimator.SetTrigger("GrowSmall");
                            }
                            StartCoroutine(setSpecialTreeToFalseInSeconds2());
                        }
                        foreach (GameObject seed in seeds){
                            if(seed != null)
                                seed.SetActive(true);
                        }
                        
                        foreach (Animator treeAnimator in treeAnimators){
                            if(treeAnimator != null)
                                treeAnimator.SetTrigger("GrowSmall");
                        }
                        StartCoroutine(setToFalseInSeconds());
                        if(nowPlatform) nowPlatform.SetActive(true);


                        foreach (Animator nowAnimator in nowAnimators){
                            if(nowAnimator != null)
                                nowAnimator.SetTrigger("Grow");
                        }
                        foreach (Animator futureAnimator in futureAnimators){
                            if(futureAnimator != null)
                                futureAnimator.SetTrigger("Shrink");
                        }
                        
                        StartCoroutine("setBuildingsToFalseInSeconds", futurePlatform);
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
            if(tree != null)
                tree.SetActive(false);
        }
    }

    IEnumerator setSpecialTreeToFalseInSeconds()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject special_tree in special_trees){
            if(special_tree != null)
                special_tree.SetActive(false);
        }
    }


    IEnumerator setSpecialTreeToFalseInSeconds2()
    {
        yield return new WaitForSeconds(1f);

        foreach (GameObject special_tree in special_trees){
            if(special_tree != null)
                if(!special_tree.transform.parent.GetComponent<SpecialPlantScript>().isGettingHeld())  // if not getting held
                    special_tree.SetActive(false);
        }
    }
    IEnumerator setBuildingsToFalseInSeconds(GameObject platform)
    {
        yield return new WaitForSeconds(1f);
        if(platform) platform.SetActive(false);
    }

    IEnumerator cooldownQ(){
        yield return new WaitForSeconds(1.5f);
        inCooldown = false;
    }

    public bool isTree(){
        return is_Tree;
    }
}

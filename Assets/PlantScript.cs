using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seed;
    public GameObject tree;
    public bool on = false;
    bool is_Tree = false;
    GameObject player;
    public Animator treeAnimator;
    public Animator seedAnimator;

    void Start(){
        player = GameObject.Find("Player");
        //treeAnimator.SetTrigger("GrowSmall");
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
                    seed.SetActive(false);
                    tree.SetActive(true);
                    treeAnimator.SetTrigger("Grow");

                    is_Tree = true;
                    on = false;
                }
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    seed.SetActive(true);
                    treeAnimator.SetTrigger("GrowSmall");

                    
                    StartCoroutine(setToFalseInSeconds());

                    is_Tree = false;
                    on = true;
                }
            }
        }
    }
    IEnumerator setToFalseInSeconds()
    {
        yield return new WaitForSeconds(1f);
        tree.SetActive(false);
    }

    public bool isTree(){
        return is_Tree;
    }
}

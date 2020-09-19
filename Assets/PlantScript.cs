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

    void Start(){
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    seed.SetActive(false);
                    tree.SetActive(true);
                    is_Tree = true;
                    on = false;
                }
            }
           
        }else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(player && !player.GetComponent<PlayerMovement>().isHoldingItem()){
                    seed.SetActive(true);
                    tree.SetActive(false);
                    is_Tree = false;
                    on = true;
                }
            }
        }
    }

    public bool isTree(){
        return is_Tree;
    }
}

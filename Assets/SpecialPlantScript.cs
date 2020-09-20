using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlantScript : MonoBehaviour
{
    bool isPlantGettingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHolding(bool value){
        isPlantGettingHeld = value;
    }

    public bool isGettingHeld(){
        return isPlantGettingHeld;
    }
}

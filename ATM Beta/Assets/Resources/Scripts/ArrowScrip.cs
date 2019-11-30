using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScrip : MonoBehaviour{
 

    void OnMouseDown() {
        if(GameManager.currentPlant!=null || GameManager.shovelenabled)
        {

            GameManager.currentPlant = null;
            GameManager.currentSeed = null;
            GameManager.shovelenabled = false;

        }
        
    }
}


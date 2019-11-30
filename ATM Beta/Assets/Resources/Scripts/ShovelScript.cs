using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {
    public AudioSource sound; 
    void OnMouseDown(){

        if(GameManager.currentPlant==null && !GameManager.shovelenabled){
            GameManager.shovelenabled = true;
            sound.Play();
            //Eta kumaha sia kodingan kok gapaham, banyak serching geh tentang typof ama GameObject
            Instantiate(Resources.Load("Prefabs/Sprite", typeof(GameObject)) as GameObject,
                        transform.position, Quaternion.identity);
        }
    }
}

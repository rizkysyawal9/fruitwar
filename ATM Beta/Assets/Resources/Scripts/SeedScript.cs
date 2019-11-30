using UnityEngine;
using System.Collections;

public class SeedScript : MonoBehaviour
{
    public GameObject prefabPlant;
    private GameObject prefabSprite;
    public AudioSource[] sounds;
    private bool canPlant = true;

    //Planting the seeds 
    void OnMouseDown()
    {
       //Masih gapaham ini eta kuanaon sia
         var spr = Resources.Load("Prefabs/Sprite", typeof(GameObject)) as GameObject;
        //Kalau misalnya dia shovelnya nggak diaktifin, kotaknya bisa di tanam plants, dan uangnya mencukupi
        if (canPlant && !GameManager.shovelenabled && GameManager.currentPlant == null
        && GameManager.cash >= prefabPlant.GetComponent<Properties>().price)
        {
            //Suara lagi di plant akan bunyi, dan tempat yang kosong bisa ditaro tanaman
            sounds[0].Play();
            prefabSprite = Instantiate(spr, transform.position, Quaternion.identity) as GameObject;
            GameManager.currentSeed = gameObject;
            GameManager.currentPlant = prefabPlant;
        }
        else if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties>().price)
        {
            sounds[1].Play();

        }
    }
    // Update is called once per frame
    //Keadaan Seednya
    void Update()
    {
        if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties>().price)
            GetComponent<SpriteRenderer>().material.color = Color.gray;
        else
            GetComponent<SpriteRenderer>().material.color = Color.white; 
    }

    public void startRecharge()
    {
        canPlant = false;
        Destroy(prefabSprite);
        GameManager.currentSeed = null;
        StartCoroutine("waitTime"); 
    }


    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(prefabPlant.GetComponent<Properties>().timeRecharge);
        canPlant = true; 
    }

}

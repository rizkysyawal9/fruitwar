using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSprite : MonoBehaviour
{
     // Start is called before the first frame update
        void Start()
        {
            //Fungsi ini bakal manggil shovel dan mousenya akan drag shovelnya
            if (GameManager.currentPlant == null)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/General/Shovel", 
                                                                        typeof(Sprite)) as Sprite;
            }
            else
                //Fungsi ini bakal ngedrag spritenya
                GetComponent<SpriteRenderer>().sprite = GameManager.currentPlant.GetComponent<SpriteRenderer>().sprite;
        }

        // Update is called once per frame
        void Update()
        {
            //Fungsi Mouse ngikutin Sprite
            var mouseP = Input.mousePosition;
            mouseP.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(mouseP);

            if (GameManager.currentPlant == null && !GameManager.shovelenabled)
            {

                Destroy(gameObject);
            }
        }
   }

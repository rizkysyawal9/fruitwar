using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public float life, vel;
    private bool canEat, canWalk;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource sound;
    private SpriteRenderer sp;


    // Start is called before the first frame update
    void Start()
    {
        canEat = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        CheckPlant();
        CheckDies();
    }

    void FixedUpdate() { 
   
        rb.velocity = canWalk ? new Vector2 (-vel *Time.deltaTime,0) : Vector2.zero;   
    }

    void CheckDeath()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            GameManager.KecwaDie += 1;
        }
    }

    void CheckPlant()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right,0.3f, LayerMask.GetMask("Plants"));
        //Kalau misalnya collider boxnya kena collider lain, zombie akan berhenti berjalan dan mulai makan 
        if(hit.collider != null)
        {
            anim.SetBool("isEating", true);
            canWalk = false;
            if(canEat)
            StartCoroutine(Eating(hit.collider));
            if (!sound.isPlaying) sound.Play();

        } else
        {
            sound.Stop();
            StopCoroutine("Eating");
            canWalk = canEat = true;
            anim.SetBool("isEating", false);
        }
    }

   void CheckDies()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Holo"));
        if (hit.collider != null)
        {

            canWalk = false;
            GameManager.gameover = true; 
        }
    }

    IEnumerator Eating(Collider2D col)
    {
        canEat = false;
        yield return new WaitForSeconds(2);
        canEat = true;
        if (col != null)
        {
            col.gameObject.GetComponent<Properties>().life--;
        }
    }

    public void WalkSlow()
    {
        StopCoroutine("WalkFast");
        sp.material.color = Color.magenta;
        vel = 3;
        StartCoroutine("WalkFast");
    }

    IEnumerator WalkFast()
    {
        yield return new WaitForSeconds(10);
        sp.material.color = Color.white;
        vel = 6;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float vel, damageHit;
    public bool isIce;
    public AudioClip clip;

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!sp.isVisible)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel * Time.deltaTime, 0);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Zombie"))
        {
            if (isIce)
                col.GetComponent<ZombieScript>().WalkSlow();
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            col.gameObject.GetComponent<ZombieScript>().life -= damageHit;
            Destroy(gameObject);
        }
    }
}

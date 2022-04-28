using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public float velocidad  = 5;
    public float salto = 30;
    public GameObject rightBullet1;
    public GameObject leftBullet1;

    public GameObject rightBullet2;
    public GameObject leftBullet2;

    public GameObject rightBullet3;
    public GameObject leftBullet3;
    public float tiempo = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Estado", 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y); 
            sr.flipX = false;
            animator.SetInteger("Estado",1); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y); 
            sr.flipX = true; 
            animator.SetInteger("Estado",1); 
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            animator.SetInteger("Estado",2); 
        }   
        if (Input.GetKey(KeyCode.X)){
            tiempo += Time.deltaTime;
            sr.enabled = !sr.enabled;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetInteger("Estado",3); 
            
            if (tiempo < 3)
            {
                var bullet = sr.flipX ? leftBullet1 : rightBullet1;
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotation = rightBullet1.transform.rotation;
                Instantiate(bullet, position, rotation);
            }else
            {
                if (tiempo < 5)
                {
                var bullet = sr.flipX ? leftBullet2 : rightBullet2;
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotation = rightBullet2.transform.rotation;
                Instantiate(bullet, position, rotation);
                }else
                {
                    var bullet = sr.flipX ? leftBullet3 : rightBullet3;
                    var position = new Vector2(transform.position.x, transform.position.y);
                    var rotation = rightBullet3.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
            }
            sr.enabled = true;
            tiempo = 0;
            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator Anime;
    public bool isMoving = false;
    public bool isDead = true;
    private SpriteRenderer sr;
    [SerializeField] public GameObject Goal;
    [SerializeField] public GameObject marker;
    public static Player instance;
    void Start()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        FlipSprite();
        AnimePlayer();
        SetMarker();
    }

    void Move()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed,Input.GetAxisRaw("Vertical") * speed);
        isMoving = (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") !=0);
        if (isMoving)
        {
            WalkSFX.instance.walk_sfx();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayArea"))
        {
            Audiomaneger.instance.audioFall();
            GamePlay.instance.LoseHP();
        }
    }

    void FlipSprite()
    {
        bool flip = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (flip)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    private void AnimePlayer()
    {
        Anime.SetBool("isWalk", isMoving);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Goal)
        {
            this.speed = 0;
            GamePlay.instance.Goal();

        }
    }
    private void SetMarker()
    {
        marker.gameObject.transform.position = new Vector3(this.transform.position.x+76, this.transform.position.y );
    }


}

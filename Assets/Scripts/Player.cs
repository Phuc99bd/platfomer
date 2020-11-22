using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 40f, maxspeed = 3, jumpPow = 220f;
    public bool grounded = true , faceRight = true;
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public int ourHealth = 5;
    public int maxHealth = 5;
    public bool isKnock = false;
    public int level = 1;
    public int maxLevel = 10;
    public int expUpLevel = 200;
    public int currentExp = 0;
    public Text namePlayer;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        namePlayer = GetComponentInChildren<Text>();
        namePlayer.text = "Trùm cuối";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnock)
        {
            animator.SetBool("Grounded", grounded);
            animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grounded)
                {
                    grounded = false;
                    rigidbody2D.AddForce(Vector2.up * jumpPow);
                }
            }
        }
        if(level * 200 <= currentExp)
        {
            currentExp -= level * 200;
            level += 1;
        }
    }
    void FixedUpdate()
    {
        if(ourHealth == 0)
        {
            Death();
        }
        if (isKnock)
        {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        rigidbody2D.AddForce(Vector2.right * speed * h);

        // lọt hố chết
        if (rigidbody2D.position.y <= -5)
        {
            Death();
        }

        if (rigidbody2D.velocity.x > maxspeed)
        {
            rigidbody2D.velocity = new Vector2(maxspeed, rigidbody2D.velocity.y);
        }
        if(rigidbody2D.velocity.x < -maxspeed)
        {
            rigidbody2D.velocity = new Vector2(-maxspeed, rigidbody2D.velocity.y);
        }

        if(h>0 && !faceRight)
        {
            Flip();
        }
        if (h < 0 && faceRight)
        {
            Flip();
        }

        if (grounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * 0.7f, rigidbody2D.velocity.y);
        }
    }

    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
        namePlayer.transform.localScale = scale;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void knock(float knockPow ,Vector2 knockPos , int dame)
    {
        isKnock = true;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(knockPos.x * (faceRight && Input.GetAxis("Horizontal")>0 ? -knockPow : knockPow), knockPow/2 + knockPos.y));
        ourHealth -= dame;
        gameObject.GetComponent<Animation>().Play("knock");
        isKnock = false;
    }

    public void upExp(int exp)
    {
        currentExp += exp;
    }
}

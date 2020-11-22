using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentAI : MonoBehaviour
{
    public int curHealth = 100;
    public float disTance;
    public float wakeRange;
    public float shootInterVal;
    public float bulletSpeed = 5;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointL, shootPointR;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);

        RangeCheck();
        if(target.transform.position.x > this.transform.position.x)
        {
            lookingRight = true;
        }

        if(target.transform.position.x < this.transform.position.x)
        {
            lookingRight = false;
        }

        if(curHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    void RangeCheck()
    {
        disTance = Vector2.Distance(transform.position, target.transform.position);

        if(disTance < wakeRange)
        {
            awake = true;
        }
        else{
            awake = false;
        }
    }

    public void Attack(bool attackRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterVal)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (attackRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet , shootPointR.transform.position , shootPointR.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }
        }
    }
}

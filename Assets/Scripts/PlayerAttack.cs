using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attachDelay = 0.5f;
    public bool attacking = false;

    public Animator animation;

    public Collider2D trigger;

    private void Awake()
    {
        animation = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attachDelay = 0.5f - 0.05f;
            if(attachDelay < 0)
            {
                attachDelay = 0.5f;
            }
        }
        if (attacking)
        {
            if(attachDelay > 0)
            {
                attachDelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        animation.SetBool("Attack", attacking);
    }
}

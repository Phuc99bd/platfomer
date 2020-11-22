using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlat : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 move;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        move = this.transform.position;
        pauseMenu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.isPause)
        {
            move.x += speed;
            this.transform.position = move;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}

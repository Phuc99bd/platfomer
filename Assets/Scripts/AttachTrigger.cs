using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTrigger : MonoBehaviour
{
    public int damage = 20;
    public Player player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.isTrigger && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", damage * (1 + player.level / 10));
        }
    }
}

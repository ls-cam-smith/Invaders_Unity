using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Enemy parent = GetComponentInParent<Enemy>();
            parent.ChangeDirection();
        }
    }

}

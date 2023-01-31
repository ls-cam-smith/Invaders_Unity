using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float animationState = 0.5f;
    public FleetController fleetController;
    private int animationCounter;

    public void ChangeDirection()
    {
        Debug.Log("Changing direction!");
        fleetController.UpdateDirection();
    }

    private void FixedUpdate()
    {
        animationCounter++;
        if (animationCounter >= 24) {
            transform.position = new Vector3(
                transform.position.x + fleetController.direction.x,
                transform.position.y + fleetController.direction.y,
                0.0f
            );

            animationCounter = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlayerBullet":
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

}

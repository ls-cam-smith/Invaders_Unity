using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FleetController fleetController;
    private int animationCounter;

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

    public void UpdateDirection()
    {
        Debug.Log("Changing direction!");
        fleetController.UpdateDirection();
    }

    // The Enemy prefab has two sensors out one unit to the left, and one unit
    // to the right, so we will detect a collision with the wall two steps
    // before it would happen
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

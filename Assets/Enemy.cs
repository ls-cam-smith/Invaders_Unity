using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float animationState = 0.5f;
    public FleetController fleetController;
    private int animationCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            default:
                break;

            case "PlayerBullet":
                Destroy(this.gameObject);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            default:
                break;
            case "FleetArea":
                fleetController.UpdateDirection();
                break;
        }
    }
}

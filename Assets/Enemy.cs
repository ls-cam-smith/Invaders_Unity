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

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exiting a 2d trigger");
        switch (collision.tag)
        {
            case "FleetArea":
                Debug.Log("FleetArea departed");
                fleetController.UpdateDirection();
                break;
            default:
                break;
        }
    }

}

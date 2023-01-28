using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 force = new Vector2(0.0f, speed);
        body.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Destroy(this.gameObject);
                break;

            case "Wall":
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}

using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            var pos = new Vector3(
                transform.position.x,
                transform.position.y + (transform.localScale.y / 2),
                0.0f
            );

            // var bullet = Instantiate(bulletPrefab, position: transform.position, transform.rotation);
            var bullet = Instantiate(bulletPrefab, position: pos, transform.rotation);
            bullet.tag = "PlayerBullet";
        }

        
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        Vector2 force = new Vector2(movement, 0.0f);
        body.AddForce(force);
    }
}

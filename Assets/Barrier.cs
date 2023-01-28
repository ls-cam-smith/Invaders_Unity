using UnityEngine;

public class Barrier : MonoBehaviour
{

    public int maxHitPoints = 5;
    public int currentHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            default:
                break;

            case "PlayerBullet":
                RegisterHit();
                break;
            case "EnemyBullet":
                RegisterHit();
                break;
        }
    }

    void RegisterHit()
    {
        currentHitPoints -= 1;
        if (currentHitPoints <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}

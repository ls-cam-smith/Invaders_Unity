using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


// I kind of want this class to keep track of which way the fleet is moving,
// playing the original, the whole fleet will move to the right until any one
// ship hits the edge, then the whole fleet advances one line and start moving
// back in the other direction
public class FleetController : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    // Not sure about the type here, just going off what worked for Snake...
    public Enemy enemyShipPrefab;
    private List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var new_x in Enumerable.Range(-6, 8).Where(i => Math.Abs(i) % 1 == 0))
        {
            var position = new Vector3((float) new_x, 4f, 0f);
            Enemy newChildEnemy = Instantiate(
                enemyShipPrefab,
                position,
                Quaternion.identity
            );
            newChildEnemy.fleetController = this;

            enemies.Add(newChildEnemy);

        }
    }

    public void UpdateDirection()
    {
        Debug.Log("Updating Fleet direction");
        Debug.Log(enemies.Count);
        var nextDirection = -direction;
        direction = Vector2.zero;
        //direction = -direction;

        foreach (var e in enemies)
        {
            e.transform.Translate(0.0f, -0.5f, 0.0f);
        }

        Task.Delay(500).ContinueWith(
            tag => direction = nextDirection
        );
    }
}

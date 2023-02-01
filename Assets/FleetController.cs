using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using static Enemy;


// I kind of want this class to keep track of which way the fleet is moving,
// playing the original, the whole fleet will move to the right until any one
// ship hits the edge, then the whole fleet advances one line and start moving
// back in the other direction
public class FleetController : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    // Not sure about the type here, just going off what worked for Snake...
    public Enemy enemyShipPrefab;

    // Start is called before the first frame update
    void Start()
    {

        foreach (var new_x in Enumerable.Range(-6, 14).Where(i => Math.Abs(i) % 2 == 0))
        {
            var position = new Vector3((float) new_x, 4f, 0f);
            Enemy newChildEnemy = Instantiate(
                enemyShipPrefab,
                position,
                Quaternion.identity
            );
            newChildEnemy.fleetController = this;

        }
    }

    public void UpdateDirection()
    {
        Debug.Log("Updating Fleet direction");
        direction = -direction;
        direction += Vector2.down;
        Task.Delay(250).ContinueWith(
            t => ResetYAxis()
        );
    }

    private void ResetYAxis()
    {
        direction.y = 0f;
    }
}

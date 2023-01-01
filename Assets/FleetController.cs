using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// I kind of want this class to keep track of which way the fleet is moving,
// playing the original, the whole fleet will move to the right until any one
// ship hits the edge, then the whole fleet advances one line and start moving
// back in the other direction
public class FleetController : MonoBehaviour
{
    public Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDirection()
    {
        direction = -direction;
    }
}

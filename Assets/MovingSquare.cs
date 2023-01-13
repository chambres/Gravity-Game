using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSquare : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public float speed;
    private int pointindex = 0;

    void Start()
    {
            transform.position = waypoints[pointindex].transform.position;
            foreach(Transform waypoint in waypoints)
            {
                waypoint.gameObject.SetActive(false);
            }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[pointindex].transform.position, speed * Time.deltaTime);
        if(transform.position == waypoints[pointindex].transform.position)
        {
            pointindex++;
        }
        if (waypoints.Length == pointindex)
        {
            pointindex = 0;
        }
    }
}

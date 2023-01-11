using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
public class Chaser : MonoBehaviour {

    public Transform target;

    void Start(){
        target = GameObject.Find("Triangle").transform;
    }

    private const float ForcePower = 10f;

    public new Rigidbody2D rigidbody;

    public float speed = 10f;
    public float force = 10f;

    private Vector2 direction;

    public Camerta cam;

    public void MoveTo (Vector2 direction) {
        this.direction = direction;
    }

    public void Stop() {
        MoveTo(Vector2.zero);
    }

    private void FixedUpdate() {
        var desiredVelocity = direction * speed;
        var deltaVelocity = desiredVelocity - rigidbody.velocity;
        Vector3 moveForce = deltaVelocity * (force * ForcePower * Time.fixedDeltaTime);
        rigidbody.AddForce(moveForce);
    }

    private void Update() {
        var directionTowardsTarget = (target.position - this.transform.position).normalized;
        MoveTo(directionTowardsTarget);

        float dist = Vector3.Distance(target.position, this.transform.position);
        cam.Intensity(-.1535f * dist +.894f);
    
        
        if(dist<3)
            StartCoroutine(cam.Shake(.01f, -1.666666f * dist + 5f));
    }
}
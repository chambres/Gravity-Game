using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate (0,50*Time.deltaTime, 550*Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}

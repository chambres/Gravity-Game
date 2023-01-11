using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attached : MonoBehaviour
{

    public int gamestate = 0; //white

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        this.transform.position = mousePosition;

    }

    public void dropPiece(string a)
    {
        Debug.Log(a);
    }
}

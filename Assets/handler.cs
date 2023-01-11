using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handler : MonoBehaviour
{

    public GameObject att;
    attached a;
    // Start is called before the first frame update
    void Start()
    {
        a = att.GetComponent<attached>();
        GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(a.gamestate == 0)
        {//red
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (a.gamestate == 1)
        {//yellow
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    void OnMouseOver() { 
        GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        Debug.Log("hi");
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseDown()
    {
        GameObject a = Instantiate(this.gameObject);
        a.GetComponent<SpriteRenderer>().enabled = true;
        a.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    

}

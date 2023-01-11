using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    public Player p;

    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Triangle").GetComponent<Player>();       
    }

    // Update is called once per frame
    void Update()
    {
        a.GetComponent<UnityEngine.UI.Text>().text = "Deaths: " + p.deaths + "\n\nTime: " + p.levelTimer;
    }
}

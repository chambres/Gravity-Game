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
        int deaths;
        deaths = Player.deaths;
        a.GetComponent<UnityEngine.UI.Text>().text = "Deaths: " + deaths;
    }
}

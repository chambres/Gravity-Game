using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class Player : MonoBehaviour
{
    public enum GravityDirection { Down, Left, Up, Right };
    public GravityDirection m_GravityDirection;


    public float levelTimer=0f;
    float finalTimer=0f;

    public bool updateTimer;

    public static int deaths = 0;

    float grav = 4.9f;

    Rigidbody2D rb;

    void Awake() {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1){
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }



    void Start()
    {
        updateTimer = true;
        rb = GetComponent<Rigidbody2D>();
        m_GravityDirection = GravityDirection.Down;
    }

    bool flipped = false;
    private KeyCode[] keyCodes = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };

    void Update()
    {
        if (updateTimer)
            finalTimer += Time.deltaTime;
        if (flipped)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                m_GravityDirection = GravityDirection.Right;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                m_GravityDirection = GravityDirection.Left;

            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                m_GravityDirection = GravityDirection.Down;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                m_GravityDirection = GravityDirection.Up;
                transform.rotation = new Quaternion(0, 0, 180, 0);

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                m_GravityDirection = GravityDirection.Left;
                Debug.Log("hji");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                m_GravityDirection = GravityDirection.Right;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                m_GravityDirection = GravityDirection.Up;
                transform.rotation = new Quaternion(0, 0, 180, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                m_GravityDirection = GravityDirection.Down;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        for (int i = 0; i < keyCodes.Length; ++i)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                Debug.Log(i);
                SceneManager.LoadScene(i - 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(0);
                deaths = 0;
            }
        }
    }


    void reset(){
            Start();
            flipped = false;
            this.transform.position = GameObject.Find("start").transform.position;
            rb.velocity = Vector3.zero;
    }

    

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "exit"){
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("s:" + SceneManager.GetActiveScene().buildIndex);

            if(SceneManager.GetActiveScene().buildIndex == 4 && updateTimer==true){
                Debug.Log("stop");
                levelTimer = Mathf.Round(finalTimer);
                updateTimer=false;  
            }
            reset();
            
        }

        if(other.gameObject.name == "flipp"){
            flipped = !flipped;
        }

        if(other.gameObject.name == "spikes"){
            deaths++;
            reset();
            this.transform.position = GameObject.Find("start").transform.position;
        }

        if(other.gameObject.name == "massup"){
            rb.mass += .50f;
        }
        if(other.gameObject.name == "massdown"){
            rb.mass -= .50f;
        }

        if(other.gameObject.name == "key")
        {
            Destroy(other.gameObject);
            eraseDoor();
        }

        
    }

    bool key = false;

    void FixedUpdate()
    {
        changeDir();
    }

    
    void eraseDoor()
    {
        Tilemap tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        Vector3Int position = new Vector3Int(5, -2, 0);
        tilemap.SetTile(position, null);
        position = new Vector3Int(5, -3, 0);
        tilemap.SetTile(position, null);
        position = new Vector3Int(5, -4, 0);
        tilemap.SetTile(position, null);
    }


    void changeDir(){
        
        switch (m_GravityDirection)
        {
            case GravityDirection.Down:
                //Change the gravity to be in a downward direction (default)
                Physics2D.gravity = new Vector2(0, -grav);
                //Press the space key to switch to the left direction

                break;

            case GravityDirection.Left:
                //Change the gravity to go to the left
                Physics2D.gravity = new Vector2(-grav, 0);
                //Press the space key to change the direction of gravity
                break;

            case GravityDirection.Up:
                //Change the gravity to be in a upward direction
                Physics2D.gravity = new Vector2(0, grav);

                break;

            case GravityDirection.Right:
                //Change the gravity to go in the right direction
                Physics2D.gravity = new Vector2(grav, 0);

                break;
        }
    }
}

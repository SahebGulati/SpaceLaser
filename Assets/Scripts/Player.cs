/* Header comments
 * Saheb Gulati
 * Player
 * AsteroidSpawner, Bullet, Asteroids
 * Define controls and keys for player movement, interaction with other objects
 */

using UnityEngine;

public class Player : MonoBehaviour
{
    //define bullet prefab
    public Bullet bulletPrefab;
    // set speed of player thrust
    public float thrustSpeed = 1.0f;
    //set speed at which player changes orientation (turning speed)
    public float turnSpeed = 1.0f;
    // game is alive, true or false
    public bool alive;
    // you lose endscreen
    GameObject[] endscreen;

    // rigidbody physics
    private Rigidbody2D _rigidbody;

    // is thrust button pressed, true or false
    private bool _thrusting;

    //direction of turn
    private float _turnDirection;

    //beginning awake function
    private void Awake()
    {
        //get rigidbody2d physics
        _rigidbody = GetComponent<Rigidbody2D>();
        //game continues, alive
        alive = true;
        //finish tag for endscreen
        endscreen = GameObject.FindGameObjectsWithTag("Finish");
    }
    // updates every frame
    private void Update()
    {
        //input w for thrust
        _thrusting = (Input.GetKey(KeyCode.W) ||/
            Input.GetKey(KeyCode.UpArrow));
        //input a for turn direction left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
#set        //float turn direction to 1
            _turnDirection = 1.0f;
        }
        // input d for turn direction negative (right)
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // float turn direction set to -1
            _turnDirection = -1.0f;
        }
            // if no button pressed, turn direction is 0 (at rest)
        else
        {
            _turnDirection = 0.0f;
        }
        // space key, mouse button trigger shoot "bullet" feature
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //call of shoot function
            Shoot();
        }

        //shuts down function of objects in game for ending
        foreach (GameObject g in endscreen)
        {
            //if object is alive...
            if (alive)
            {
                //makes it not alive
                g.SetActive(false);
            }
        }
    }
    //function updates at fixed rate (not per frame)
    private void FixedUpdate()
    {
        //if ship is thrusting
        if (_thrusting)
        {
            // add force of thrusting
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }
        //if turn direction is non zero (the ship is turning)
        if (_turnDirection != 0.0f)
        {
            // turn at x turn speed
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }
    //shoot function
    private void Shoot()
    {
        //instantiate bullet position, prefab, rotation
        Bullet bullet = Instantiate(this.bulletPrefab, /
            this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    //on collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if object collision with layer 8 (asteroid)
        if (collision.gameObject.layer == 8)
        {
            //plyer gone
            alive = false;
            //game ending loop
            foreach (GameObject g in endscreen)
            {
                g.SetActive(true);
            }
            //destroy player
            Destroy(this.gameObject);
        }
    }
}
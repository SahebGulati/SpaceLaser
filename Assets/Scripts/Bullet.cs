/* Header comments
 * Saheb Gulati
 * Bullet
 * AsteroidsSpawner, Asteroids, Player
 * To define parameters and characteristics/behavior of bullets
 * Collisions with other objects
 */

using UnityEngine;

public class Bullet : MonoBehaviour
{
    //set bullet speed
    public float speed = 500.0f;
    //set lifetime of bullet before it is destroyed
    public float maxLifetime = 10.0f;
    // rigidbody physics
    private Rigidbody2D _rigidbody;

    // beginning awake function
    private void Awake()
    {
        // get rigidbody physics
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //  function for direction

    public void Project(Vector2 direction)
    {
        //add force in direction of shot with x speed
        _rigidbody.AddForce(direction * this.speed);
        // destroy bullet after max lifetime
        Destroy(this.gameObject, this.maxLifetime);
    }

    // on collison with certain objects, self-destruct
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy bullet

        Destroy(this.gameObject);

    }
}
/* Header comments
 * Saheb Gulati
 * Asteroids
 * AsteroidSpawner, Bullet, Player
 * To define parameters and characteristics/behavior of asteroids
 */

using UnityEngine;
//public class
public class Asteroids : MonoBehaviour
{
    //private class
    private SpriteRenderer _spriteRenderer;

    public Sprite[] sprites;

    //add rigidbody
    private Rigidbody2D _rigidbody;

    //variable for size
    public float size = 1.0f;
    //variable for minimum size in size range
    public float minSize = 0.5f;
    //variable for max size in size range
    public float maxSize = 1.5f;
    //float variable for speed
    public float speed = 10.0f;
    //lifetime of asteroid before it disappears
    public float maxLifetime = 30.0f;

    //initial awake
    private void Awake()
    {
        //get sprite renderer
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //get rigidbody for physics
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    //start function
    private void Start()
    {
        //random sprite chooser for asteroids
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

    //euler angles
     this.transform.eulerAngles = new Vector3(0.0f, 0.0f,
         Random.value * 360.0f);
     this.transform.localScale = Vector3.one * this.size;

        //set mass proportional to size
        _rigidbody.mass = this.size * 5.0f;
    }
    //path of asteroid from spawn location
    public void SetTrajectory(Vector2 direction)
    {
        ///movement in this speed direction
        _rigidbody.AddForce(direction * this.speed);
        //destroy asteroid after lifetime
        Destroy(this.gameObject, this.maxLifetime);
    }
    //collision --> destroy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

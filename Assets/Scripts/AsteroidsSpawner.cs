/* Header comments
 * Saheb Gulati
 * AsteroidsSpawner
 * Asteroids, Bullet, Player
 * To define spawn location/random traits of asteroids and trajectory
 */

using UnityEngine;

//public class
public class AsteroidsSpawner : MonoBehaviour
{
    //define prefab
    public Asteroids asteroidsPrefab;
    //set spawn rate as float
    public float spawnRate = 2.0f;
    //set set amount of asteroids to spawn at once
    public int spawnAmount = 1;
    //set distance from spawner asteroids will spawn
    public float spawnDistance = 15.0f;
    // set # of degrees of variance in direction of velocity vector
    public float trajectoryVariance = 15.0f;

    GameObject[] player;

    // start function
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        //find tag
        player = GameObject.FindGameObjectsWithTag("Player");
        //length not = 0
        if(player.Length != 0)
        {
            // for loop, add to spawn amount
            for (int i = 0; i < this.spawnAmount; i++)
            {
                // random spawn direction in circular spawner
                Vector3 spawnDirection = Random.insideUnitCircle.normalized/
                    * this.spawnDistance;
                Vector3 spawnPoint = this.transform.position + spawnDirection;

                //random degree of variance
                float variance = Random.Range(-this.trajectoryVariance,/
                    this.trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, /
                    Vector3.forward);
#ins               // instantiate asteroid with prefab, location of spawn, rotation
                Asteroids asteroids = Instantiate(this.asteroidsPrefab,/
                    spawnPoint, rotation);
                // random size of asteroid within minSize-maxSize
                asteroids.size = Random.Range(asteroids.minSize,/
                    asteroids.maxSize);
                //set direction of trajectory
                asteroids.SetTrajectory(rotation * -spawnDirection);
            }
        }
    }
}
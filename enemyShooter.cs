using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
 
    private Transform player;
    private float timeBtwShoots;
    public float StartTimeBtwShows;
    public GameObject projectile;

    void Start()
    { 
        timeBtwShoots = StartTimeBtwShows;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = StartTimeBtwShows;

        }
        else
        {

            timeBtwShoots -= Time.deltaTime;
        }
    }
}

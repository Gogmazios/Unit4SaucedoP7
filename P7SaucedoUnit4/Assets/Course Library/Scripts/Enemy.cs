using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody ERB;
    // ERB = enemyRB
    private GameObject player; 
    
    public bool isBoss = false;
    public float spawnInterval;
    private float nextSpawn;
    public int miniEnemySpawnCount;
    private SpawnManager SM; 
   // spawnManager = SM





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ERB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (isBoss)
        {
            SM = FindObjectOfType<SpawnManager>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        ERB.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject); 
        }

        if(isBoss)
        {
            if(Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnInterval;
                SM.SpawnMiniEnemy(miniEnemySpawnCount); 
            }
        }
    }








}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody ERB;
    // ERB = enemyRB
    private GameObject player; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ERB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        ERB.AddForce(lookDirection * speed);

    }
}

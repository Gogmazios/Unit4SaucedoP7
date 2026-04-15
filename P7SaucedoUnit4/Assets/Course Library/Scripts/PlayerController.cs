using UnityEngine;
using System.Collections; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject focalPoint; 
    //player Rb = RB 
    public float speed = 5.0f;
    public bool hasPowerup;
    public float powerupStrength = 15.0f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
       // float 
        RB.AddForce(focalPoint.transform.forward * speed * forwardInput); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine()); 
        }


    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody ERB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); 


            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            ERB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); 
        }




    }
}

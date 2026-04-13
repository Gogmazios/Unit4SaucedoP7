using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody RB;
    private GameObject focalPoint; 
    //player Rb = RB 
    public float speed = 5.0f; 

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
        RB.AddForce(focalPoint.transform.forward * speed * forwardInput); 
    }
}

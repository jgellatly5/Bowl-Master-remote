using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private AudioSource audioSource;
    private Rigidbody rb;
    private Vector3 ballStartPos;
    

	// Initializes ball position, rigidbody, and audio
	void Start ()
    {
        ballStartPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        audioSource = GetComponent<AudioSource>();
    }

    //sets launch velocity of ball, takes in public variable
    public void Launch(Vector3 launchVelocity)
    {
        inPlay = true;
        rb.useGravity = true;
        rb.velocity = launchVelocity;
        audioSource.Play();
    }

    //resets the ball position after launch
    public void Reset()
    {
        transform.rotation = Quaternion.identity;
        transform.position = ballStartPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        inPlay = false;
    }
}

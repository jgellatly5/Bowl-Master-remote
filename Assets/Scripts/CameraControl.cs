using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

	// calculate offset of camera
	void Start () {
        offset = transform.position - ball.transform.position;
	}
	
	// follow ball until it reaches the headpin
	void Update () {
        if(ball.transform.position.z <= 1829f)
        {
            transform.position = ball.transform.position + offset;
        }

    }
}

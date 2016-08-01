using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

    }

    //checks to see if pin is still upright
    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        //raise standing pins only by DistanceToRaise
        
            if (IsStanding() == true)
            {
                rb.useGravity = false;
                transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
                transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void Lower()
    {
        //lower standing pins only by DistanceToRaise
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rb.useGravity = true;
    }
}

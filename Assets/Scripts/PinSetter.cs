using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;
 
    private Animator animator;
    private PinCounter pinCounter;

	// intialize ball
	void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }
	
	// Update text of standing count
	void Update () {
        
	}

    public void RaisePins()
    {
        //raise standing pins only by DistanceToRaise
        Pin[] pinArray = FindObjectsOfType<Pin>();
        foreach (Pin pin in pinArray)
        {
            pin.RaiseIfStanding();
        }
    }

    public void Lower()
    {
        //lower standing pins only by DistanceToRaise
        Pin[] pinArray = FindObjectsOfType<Pin>();
        foreach (Pin pin in pinArray)
        {
            pin.Lower();
        }
    }

    //renew pins for reset
    public void Renew()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    public void PerformAction(ActionMasterOld.Action action)
    {
        if (action == ActionMasterOld.Action.Tidy)
        {
            animator.SetTrigger("TidyTrigger");
        }
        else if (action == ActionMasterOld.Action.EndTurn)
        {
            animator.SetTrigger("ResetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMasterOld.Action.Reset)
        {
            animator.SetTrigger("ResetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMasterOld.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }
}

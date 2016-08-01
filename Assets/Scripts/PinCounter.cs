using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private bool ballLeftBox = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballLeftBox)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<Ball>())
        {
            ballLeftBox = true;
        }
    }

    void UpdateStandingCountAndSettle()
    {
        // update the last standing count
        // call pins have settled when they have
        int currentstanding = CountStanding();
        if (currentstanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentstanding;
            return;
        }
        float settleTime = 3f; // how long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) // if last change >3s ago
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; // indicates pins have settled , and ball not back in box;
        ballLeftBox = false;
        standingDisplay.color = Color.green;
    }

    // updates the standing count
    int CountStanding()
    {
        int count = 0;
        Pin[] pinArray = FindObjectsOfType<Pin>();
        foreach (Pin pin in pinArray)
        {
            if (pin.IsStanding() == true)
            {
                count++;
            }
        }
        return count;
    }
}

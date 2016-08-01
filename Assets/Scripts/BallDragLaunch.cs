using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void DragStart()
        //capture time and position of drag start
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
        // launch the ball
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            // calculate difference in dragtime
            float dragDuration = endTime - startTime;

            // calculate speed; distance divided by time
            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            // talk to ball script to launch ball with new drag velocity
            Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(launchVelocity);
        }
    }

    // moves the ball to the right or left at the start
    public void MoveStart(float amount)
    {
        if(ball.inPlay == false)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}

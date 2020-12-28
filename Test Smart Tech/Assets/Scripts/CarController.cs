using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController: MonoBehaviour
{
    [SerializeField]
    private Point currentPoint; 
    private Point nextPoint;
    public float speed = 3f;

    public bool canMove = true;
    public bool pointReached = false;


    void Awake()
    {
        transform.position = currentPoint.transform.position;   // Works as a start point of our car
    }

    void Update()
    {
        if (nextPoint == null)
        {
            nextPoint = currentPoint.GetRandomPoint();          // Makes sure that the point always has a next point
        }

        if (!canMove)
        {
            return;                                             // If we have red light - it will jump out of current frame and recheck in the next one
        }
        if (nextPoint != null)
        {
            CarMovingLogic();
        }

    }
    private void CarMovingLogic()
    {
        transform.position += ((nextPoint.transform.position - currentPoint.transform.position).normalized * (speed * Time.deltaTime));  // movement logic
        transform.LookAt(nextPoint.transform.position, Vector3.up);   // rotation logic (turns around y axis)

        var startVectorMagnituded = (currentPoint.transform.position - nextPoint.transform.position).magnitude;   // storable data of a distance from start point to next point
        var playerVectorMagnituded = (currentPoint.transform.position - transform.position).magnitude;            // storable data of a distance from start point to player current position

        CheckingIfPointReached(startVectorMagnituded, playerVectorMagnituded);
    }

    private void CheckingIfPointReached(float prognosedPosition,float currentlyIsPosition)
    {
        if (prognosedPosition <= currentlyIsPosition)           // allows to define if we have reached next point or maybe even passed it
        {
            currentPoint = nextPoint;                                  // sets previously reached next point to current point
            nextPoint = currentPoint.GetRandomPoint();                  // sets new next point
            pointReached = true;
        }
    }

}

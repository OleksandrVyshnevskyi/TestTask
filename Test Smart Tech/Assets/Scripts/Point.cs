using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point: MonoBehaviour
{
    [SerializeField]
    private List<Point> nextPoints;        // Stores info about points places after current point (next point(s)) 

    public Point GetRandomPoint()          // Randomly chooses 1 point from avaliable points (even if it's a single one)
    {
        return nextPoints[Random.Range(0,nextPoints.Count)];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    private Queue<CarController> cars = new Queue<CarController>();
    [SerializeField]
    public bool colorRed = false;
    private float nextActionTime = 0.0f;
    private float period = 5f;
    private float timerForDequeue = 0.1f;

    private void Update()
    {
        Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            var otherCar = other.transform.gameObject.GetComponent<CarController>();
            otherCar.canMove = false;

            if (!colorRed)
            {
                StartCoroutine(TrafficLights(other.transform.gameObject, timerForDequeue));
            }
            else
            {
                cars.Enqueue(otherCar);
            }
        } 
    }

    private void Timer()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            colorRed = !colorRed;
            if (!colorRed)
            {
                while (cars.Count > 0)
                {
                    var otherCar = cars.Dequeue();
                    otherCar.canMove = true;
                }
            }
        }
    }

    public IEnumerator TrafficLights(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.GetComponent<CarController>().canMove = true; 
    }

}

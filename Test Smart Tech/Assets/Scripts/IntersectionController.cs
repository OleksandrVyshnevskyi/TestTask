using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    private Queue<GameObject> cars;
    [SerializeField]
    public bool colorRed = false;
    private float nextActionTime = 0.0f;
    private float period = 5f;
    private float timerForDequeue = 0.2f;


    private void Awake()
    {
        cars = new Queue<GameObject>();
    }

    private void Update()
    {
        Timer();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            cars.Enqueue(other.transform.gameObject);
            other.transform.gameObject.GetComponent<CarController>().canMove = false;
            if (colorRed == false)
            {
                foreach (var car in cars)
                {
                    StartCoroutine(TrafficLights(other.transform.gameObject, timerForDequeue));
                }
            }
            else if (colorRed == true)
            {
                StartCoroutine(ForRedLightAction(other.transform.gameObject, period - timerForDequeue * 2));
            }
        } 
    }

    private void Timer()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            colorRed = !colorRed;
        }
    }

    

    public IEnumerator TrafficLights(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (cars != null)
        {
            cars.Dequeue();
            obj.GetComponent<CarController>().canMove = true;
        } 
    }

    public IEnumerator ForRedLightAction(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (cars != null)
        {
            foreach (var car in cars)
            {
                cars.Dequeue();
                obj.GetComponent<CarController>().canMove = true;
            }
        }
            
    }
}

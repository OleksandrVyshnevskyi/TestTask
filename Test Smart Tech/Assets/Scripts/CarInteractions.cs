using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Car")
        {
            if (other.transform.gameObject.GetComponent<CarController>().canMove == false)
            {
                transform.gameObject.GetComponent<CarController>().canMove = false;
                StartCoroutine(Hong(other.transform.gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == "Car")
        {
            if (other.transform.gameObject.GetComponent<CarController>().canMove == true)
            {
                transform.gameObject.GetComponent<CarController>().canMove = true;
            }
        }
    }

    private IEnumerator Hong(GameObject car)
    {
        yield return new WaitForSeconds(4.5f);
        car.GetComponent<CarController>().canMove = true;
    }
}

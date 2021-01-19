using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject sphere;
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;
    [SerializeField]
    private IntersectionController intersectionController;
    private bool isRed;


    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        isRed = intersectionController.colorRed;
        if (isRed == true)
        {
            sphere.GetComponent<Renderer>().material = red;
        }
        else
        {
            sphere.GetComponent<Renderer>().material = green;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHumansAccordingly : MonoBehaviour
{
    private Renderer Color;
    private Transform Humans;
    private int humansCount;
    // Start is called before the first frame update
    void Start()
    {
        Color = GetComponentInParent<RandomColor>().GetComponent<Renderer>();
        Material RandomMaterial = Color.material;
        Humans = GetComponent<Transform>();
        Humans.GetComponent<Renderer>().material = RandomMaterial;
        humansCount = 3;

        RandomColorChangeSomeHumans();
    }

    private void RandomColorChangeSomeHumans()
    {
        int whichColor = UnityEngine.Random.Range(0, humansCount);
        if (whichColor == 0)
        {
            Humans.GetComponent<MeshRenderer>().material = GetComponentInParent<RandomColor>().Materials[UnityEngine.Random.Range(0, 7)];
        }
        else
        {
            return;
        }
    }
}
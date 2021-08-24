using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public List<Material> Materials;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = Materials[Random.Range(0, Materials.ToArray().Length-1)];
    }
}
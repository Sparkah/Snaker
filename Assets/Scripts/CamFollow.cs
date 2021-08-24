using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject SnakeHead;
    private float x;

    private void Start()
    {
        x = SnakeHead.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(SnakeHead.transform.position.x-x, transform.position.y, transform.position.z);
    }
}

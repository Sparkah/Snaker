using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Snake;

    [SerializeField]
    private GameObject Ground;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Snake.transform.position, transform.position) >= 80)
        {
            transform.position = Snake.transform.position;
            Instantiate(Ground, new Vector3(transform.position.x + 80f, Random.Range(-0.45f,-0.55f), 0), Quaternion.identity);
            GameObject[] GroundBehind = GameObject.FindGameObjectsWithTag("Ground");
            for (int i = 0; i < GroundBehind.Length; i++)
            {
                GameObject Ground = GroundBehind[i];
                if (Vector3.Distance(transform.position, Ground.transform.position) > 350)
                {
                    Destroy(Ground);
                }
            }
        }
    }
}
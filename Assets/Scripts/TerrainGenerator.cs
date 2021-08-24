using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Snake;

    [SerializeField]
    private List<GameObject> Terrain;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Snake.transform.position, transform.position) >= 40)
        {
            transform.position = Snake.transform.position;
            Instantiate(Terrain[Random.Range(0, Terrain.ToArray().Length)], new Vector3(transform.position.x + 70f, 0, 0), Quaternion.identity);
            GameObject[] TerrainBehind = GameObject.FindGameObjectsWithTag("Terrain");
            for (int i = 0; i < TerrainBehind.Length; i++)
            {
                GameObject Ground = TerrainBehind[i];
                if (Vector3.Distance(transform.position, Ground.transform.position) > 350)
                {
                    Destroy(Ground);
                }
            }
        }
    }
}
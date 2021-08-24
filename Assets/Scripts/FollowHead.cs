using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    [SerializeField]
    private float followSharpness = 0.5f;
    private GameObject SnakeHead;
    private GameObject[] TaleLength;
    int taleNum;


    private void Start()
    {
        SnakeHead = GameObject.FindGameObjectWithTag("Player");
        TaleLength = GameObject.FindGameObjectsWithTag("Tale");
        taleNum = TaleLength.Length;
        for(int i = 0; i<taleNum;i++)
        {
            Debug.Log(TaleLength[i].transform.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (taleNum == 1)
        {
            transform.position += (SnakeHead.transform.position - transform.position + new Vector3(-taleNum * 2, 0, 0)) * followSharpness;
        }
        if(taleNum>1)
        {
            transform.position += (TaleLength[0].transform.position - transform.position + new Vector3(-taleNum,0,0)) * followSharpness;
        }
    }
}
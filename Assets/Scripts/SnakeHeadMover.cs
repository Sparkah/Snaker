using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeHeadMover : MonoBehaviour
{
    private Transform SnakeHead;
    [SerializeField]
    private float snakeMoveSpeed;
    private List<int> snakeTale;
    [SerializeField]
    private GameObject snakeTaleObject;
    [SerializeField]
    private Text CrystalScore;
    private int screen;
    [SerializeField]
    private float snakeDashSpeed;
    private int screenDevider;

    // Start is called before the first frame update
    void Start()
    {
        SnakeHead = GetComponent<Transform>();
        snakeDashSpeed = 0.15f;
        snakeTale = new List<int>();
        CrystalScore.text = "Кристалов: 0";
        screen = Screen.width / 2;

        screenDevider = Screen.width / 9;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SnakeHead.transform.position = new Vector3(transform.position.x+snakeMoveSpeed,0,transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x / screenDevider - 4 < SnakeHead.transform.position.z)
            {
                SnakeHead.transform.position = Vector3.MoveTowards(SnakeHead.transform.position, new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, -(touch.position.x / screenDevider -4)), snakeDashSpeed);
            }
            if (touch.position.x / screenDevider - 4 > SnakeHead.transform.position.z)
            {
                SnakeHead.transform.position = Vector3.MoveTowards(SnakeHead.transform.position, new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, -(touch.position.x / screenDevider -4)), snakeDashSpeed);
            }

            if (SnakeHead.transform.position.z > 4)
            {
                SnakeHead.transform.position = new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, 4);
            }
            if (SnakeHead.transform.position.z < -4)
            {
                SnakeHead.transform.position = new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, -4);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChanger"))
        {
            Material Color = other.GetComponent<MeshRenderer>().material;
            ColorChange(Color);
        }

        if (other.CompareTag("Apple") && gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            snakeTale.Add(1);
            CrystalScore.text = "Кристалов: " + snakeTale.ToArray().Length;
            if (snakeTale.ToArray().Length < 3)
            {
                Instantiate(snakeTaleObject, new Vector3(SnakeHead.position.x - 1.5f * snakeTale.ToArray().Length,
                    SnakeHead.position.y, SnakeHead.position.z), Quaternion.identity);//, SnakeHead);
            }
            else
            {
                SnakeHead.tag = "Rage";
                StartCoroutine(RageMode());
            }
        }

        if(other.CompareTag("HumanGroup") && gameObject.CompareTag("Player"))
        {
            if(gameObject.GetComponent<MeshRenderer>().material.name == other.GetComponent<MeshRenderer>().material.name)
            {
                Destroy(other.gameObject);
            }
            if(gameObject.GetComponent<MeshRenderer>().material.name != other.GetComponent<MeshRenderer>().material.name)
            {
                SceneManager.LoadScene(0);
            }
            
        }
        if(other.CompareTag("Bomb") && !gameObject.CompareTag("Rage"))
        {
            SceneManager.LoadScene(0);
        }

        if(gameObject.CompareTag("Rage") && !other.CompareTag("ColorChanger"))
        {
            Destroy(other.gameObject);
        }
    }

    private void ColorChange(Material Color)
    {
        SnakeHead.GetComponent<MeshRenderer>().material = Color;
    }

    IEnumerator RageMode()
    {
        snakeMoveSpeed *= 3;
        yield return new WaitForSeconds(5f);
        snakeTale.Clear();
        GameObject[] SnakeTale = GameObject.FindGameObjectsWithTag("Tale");
        foreach(GameObject Tale in SnakeTale)
        {
            Destroy(Tale);
        }
        snakeMoveSpeed /= 3;
        SnakeHead.tag = "Player";
        CrystalScore.text = "Кристалов: " + snakeTale.ToArray().Length;
    }
}
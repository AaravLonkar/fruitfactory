using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float t = 5f;
    UnityEngine.Object pPrefab;

    GameObject pipe1u;
    GameObject pipe2u;
    GameObject pipe3u;
    GameObject pipe4u;
    GameObject pipe5u;
    GameObject pipe6u;
    GameObject fruitLayer;
    // Start is called before the first frame update
    void Start()
    {
        pipe1u = GameObject.Find("pipe1u");
        pipe2u = GameObject.Find("pipe2u");
        pipe3u = GameObject.Find("pipe3u");
        pipe4u = GameObject.Find("pipe4u");
        pipe5u = GameObject.Find("pipe5u");
        pipe6u = GameObject.Find("pipe6u");

        fruitLayer = GameObject.Find("fruitLayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else
        if (t <= 0)
        {
            generateFruit();
            t = 5f;
        }
    }
    void generateFruit()
    {

        switch (Random.Range(0, 6) + 1)
        {
            case 1:
                pPrefab = Resources.Load("banana");
                break;
            case 2:
                pPrefab = Resources.Load("apple");
                break;
            case 3:
                pPrefab = Resources.Load("green apple");
                break;
            case 4:
                pPrefab = Resources.Load("grape");
                break;
            case 5:
                pPrefab = Resources.Load("strawberry");
                break;
            case 6:
                pPrefab = Resources.Load("mango");
                break;
        }

        GameObject fruit = (GameObject)GameObject.Instantiate(pPrefab, new Vector2(0f, 0f), Quaternion.identity);

        fruit.transform.SetParent(fruitLayer.transform, false);
        switch (Random.Range(0, 6) + 1)
        {
            case 1:
                fruit.transform.position = pipe1u.transform.position;
                break;
            case 2:
                fruit.transform.position = pipe2u.transform.position;
                //  fruit.GetComponent<Fruit>().pipe = 2;
                break;
            case 3:
                fruit.transform.position = pipe3u.transform.position;
                //  fruit.GetComponent<Fruit>().pipe = 3;
                break;
            case 4:
                fruit.transform.position = pipe4u.transform.position;
                //  fruit.GetComponent<Fruit>().pipe = 4;
                break;
            case 5:
                fruit.transform.position = pipe5u.transform.position;
                //   fruit.GetComponent<Fruit>().pipe = 5;
                break;
            case 6:
                fruit.transform.position = pipe6u.transform.position;
                //   fruit.GetComponent<Fruit>().pipe = 6;
                break;
        }


    }


}

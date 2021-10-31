using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    float t = 2f;
    public bool fire = false;
    int ctr = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fire)
        {
            if (t > 0)
            {
                t -= Time.deltaTime;
            }
            else
            {
                UnityEngine.Object pPrefab = Resources.Load("bullet");
                GameObject bullet = (GameObject)GameObject.Instantiate(pPrefab, new Vector2(0f, 0f), Quaternion.identity);
                GameObject canvas = GameObject.Find("Canvas");
                bullet.transform.SetParent(canvas.transform, false);
                bullet.transform.position = transform.position;
                t = 0.02f;
                ctr++;
            }

            if (ctr >= 40)
            {
                fire = false;
                ctr = 0;
                t = 0.02f;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    float t = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t>0)
        {
            t -= Time.deltaTime;
        }
        else
        if(t<=0)
        {
            t = 1f;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valve : MonoBehaviour
{
    
    int ctr = 0;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ctr++;
        //there is no score...
        if(ctr>=2)
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
            ctr = 0;
        }
    }
}

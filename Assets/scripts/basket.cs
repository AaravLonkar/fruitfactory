using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float basketx = Mathf.Clamp(Input.mousePosition.x, 100f, 1180f);
        transform.position = new Vector2(basketx, transform.position.y);
    }
}

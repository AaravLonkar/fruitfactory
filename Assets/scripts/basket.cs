using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    GameObject basket2;
    float t = -1f;
    GameObject bas;
    public GameObject caught;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name=="b-back")
        {
            basket2 = GameObject.Find("uselessthing");
            bas=GameObject.Find("b-front");
            basket2.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "b-back")
        {
            if (Input.GetMouseButtonDown(0))
            {
                basket2.SetActive(true);
               bas.SetActive(false);
                t = 0f;

                if (GetComponent<PolygonCollider2D>())
                {
                    if (transform.childCount > 0)
                    {
                        transform.GetChild(0).SetParent(GameObject.Find("fruitLayer").transform);
                    }
                    GetComponent<PolygonCollider2D>().isTrigger = true;
                    caught = null;
                }
            }
            if (t >= 0f && t < 1f)
            {
                t += Time.deltaTime;
            }
            else
            if (t >= 1f)
            {
                basket2.SetActive(false);
                bas.SetActive(true);
                t = -1f;
            }

        }


        float basketX = Mathf.Clamp(Input.mousePosition.x, 50f, 1230f);
        transform.position = new Vector2(basketX, transform.position.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}

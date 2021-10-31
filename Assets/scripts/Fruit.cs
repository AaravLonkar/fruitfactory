using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    public int pipe = 1;

    public bool matched = false;
    Rigidbody2D r2d;

    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (r2d.velocity.magnitude <= 1.0f && transform.position.y <= 300)// the movement has stoped..
        {
            for (int i = 0; i < 6; i++)
            {
                if (transform.position.x >= GameObject.Find("pipe" + (i + 1)).transform.position.x - 75 &&
                    transform.position.x <= GameObject.Find("pipe" + (i + 1)).transform.position.x + 75)
                {
                    pipe = i + 1;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    break;
                }
            }
        }
        transform.GetComponentInChildren<Text>().text = "" + pipe;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == gameObject.name)
        {
            matched = true;

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -30000f));
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -30009f));

            GameObject.Find("pipe" + pipe).GetComponentInChildren<CircleCollider2D>().isTrigger = true;
            print("pipe" + pipe);
        }
        else
        if (collision.gameObject.name == "boxFE")
        {
            // transform.SetParent(collision.gameObject.transform);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (collision.gameObject.GetComponent<basket>().caught == null)
            {
                collision.gameObject.GetComponent<basket>().caught = gameObject;
            }
        }
        else
        if (collision.gameObject.GetComponent<Fruit>())
        {
            matched = false;
            collision.gameObject.GetComponent<Fruit>().matched = false;

            GameObject.Find("pipe" + pipe + "u").GetComponent<gun>().fire = true;

        }
        else
        if (collision.gameObject.name == "bullet(Clone)" && !matched)
        {
            health -= 10;
            if (health <= 0)
            {
                UnityEngine.Object pPrefab = Resources.Load("explode");
                GameObject explode = (GameObject)GameObject.Instantiate(pPrefab, new Vector2(0f, 0f), Quaternion.identity);
                GameObject fruitLayer = GameObject.Find("fruitLayer");

                explode.transform.SetParent(fruitLayer.transform, false);
                explode.transform.position = gameObject.transform.position;

                UnityEngine.Object pPrefab1 = Resources.Load("explode");
                GameObject explode1 = (GameObject)GameObject.Instantiate(pPrefab, new Vector2(0f, 0f), Quaternion.identity);

                explode1.transform.SetParent(fruitLayer.transform, false);
                explode1.transform.position = collision.gameObject.transform.position;

                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }

    }

}

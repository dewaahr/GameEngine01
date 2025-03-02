using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody2D rd;
    private int scoreBlue = 0;
    private int scoreRed = 0;

    public GameObject textBlue;
    public GameObject textRed;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rd.AddForce(arah * ballSpeed);
    }

    void ResetBall(float arah)
    {
        transform.localPosition = new Vector2(0, 0);
        rd.velocity = Vector2.zero;
        Vector2 arah2 = new Vector2(arah, 0).normalized;
        rd.AddForce(arah2 * ballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "leftB")
        {
            scoreRed++;
            textRed.GetComponent<TMPro.TextMeshProUGUI>().text = scoreRed.ToString();
            ResetBall(1);
        }   
        else if (other.collider.name == "rightB")
        {
            scoreBlue++;
            textBlue.GetComponent<TMPro.TextMeshProUGUI>().text = scoreBlue.ToString();
            ResetBall(-1);
        }
        else if (other.collider.name == "Bar1" || other.collider.name == "Bar2")
        {
            float sudut = (transform.position.y - other.collider.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rd.velocity.x, sudut).normalized;
            rd.velocity = Vector2.zero;
            rd.AddForce(arah * ballSpeed * 2);
        }
        
    }
}

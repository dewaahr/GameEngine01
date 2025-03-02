using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float speed;
    public string axis;
    private float Yup = 3.18f;
    private float Ydown = -3.18f;

    void Update()
    {
        float move = Input.GetAxis(axis) * Time.deltaTime * speed;
        float newY = Mathf.Clamp(transform.position.y + move, Ydown, Yup);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

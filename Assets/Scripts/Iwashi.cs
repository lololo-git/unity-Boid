using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwashi : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Start");

        // init speed
        float ang = Random.Range(0, 359);
        float spd = 3;

        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * ang) * spd;
        v.y = Mathf.Sin(Mathf.Deg2Rad * ang) * spd;
        GetComponent<Rigidbody2D>().velocity = v;
    }

    private void Update()
    {
        // Debug.Log("Update");
        fixDirection();

        //Click and show speeds for debug
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            Debug.Log($"Iwashi_velocity x:{v.x} y:{v.y}");
        }
    }

    // Flop Image by speed for x-axies
    private void fixDirection()
    {
        Vector3 scale = transform.localScale;
        float sx = transform.localScale.x;
        float vx = GetComponent<Rigidbody2D>().velocity.x;

        if (vx * sx < 0)
        {
            return;
        }

        //Change Direction
        scale.x = sx * -1;
        transform.localScale = scale;
    }

    public void onClickIwashi()
    {
        Debug.Log("OnClickIwashi");
        Destroy(this.gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sardine : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomizeSpeed();
    }

    private void FixedUpdate()
    {
        Vector3 sxf = GetStrongXForce();
        rb.AddForce(sxf);

        Vector3 ksf = GetKeepSpeedForce();
        rb.AddForce(ksf);

        fixDirection();
    }

    public void randomizeSpeed()
    {
        // init speed
        float ang = Random.Range(0, 359);
        float spd = ParamsSO.Entity.sardineSpeed;

        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * ang) * spd;
        v.y = Mathf.Sin(Mathf.Deg2Rad * ang) * spd;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = v;
    }

    private Vector3 GetStrongXForce()
    {
        Vector3 v = rb.velocity;
        if (v.x < v.y * 2)
        {
            Debug.Log("fix x speed " + v);
            float xs = ParamsSO.Entity.sardineSpeed / 3 * this.GetDirectionX();
            v = new Vector3(xs, 0, 0);
            Debug.Log(v);
        }
        return v;
    }

    private Vector3 GetKeepSpeedForce()
    {
        Vector3 v = this.rb.velocity;
        float rat = ParamsSO.Entity.sardineSpeed - v.magnitude;

        return v * rat;
    }

    // Flip Image by speed for x-axies
    private void fixDirection()
    {
        Vector3 scale = transform.localScale;
        float sx = transform.localScale.x;
        float vx = this.rb.velocity.x;

        // ignore small speed to avoid flipping chain
        if (Mathf.Abs(vx) < 0.001)
            return;

        if (vx * sx < 0)
            return;

        //Change Direction
        scale.x = sx * -1;
        transform.localScale = scale;
    }

    private float GetDirectionX()
    {
        //want 1 from "0"
        float f = Mathf.Sign(this.rb.velocity.x);
        if (f == 0)
            return 1f;
        return f;
    }
}
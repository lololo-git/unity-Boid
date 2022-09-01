using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sardine : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        randomizeSpeed();
    }

    private void FixedUpdate()
    {
        var rb = GetRigidbody2D();

        Vector3 sxf = GetStrongXForce();
        rb.AddForce(sxf);

        Vector3 ksf = GetKeepSpeedForce();
        rb.AddForce(ksf);

        fixDirection();
    }

    private Rigidbody2D GetRigidbody2D()
    {
        if (this._rigidbody2D == null)
            this._rigidbody2D = GetComponent<Rigidbody2D>();
        return this._rigidbody2D;
    }

    public void randomizeSpeed(bool useForce = true)
    {
        // init speed
        float ang = Random.Range(0, 359);
        float spd = ParamsSO.Entity.sardineSpeed;

        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * ang) * spd;
        v.y = Mathf.Sin(Mathf.Deg2Rad * ang) * spd;

        if (useForce)
            GetRigidbody2D().AddForce(v);
        else
            GetRigidbody2D().velocity = v;
    }

    private Vector3 GetStrongXForce()
    {
        var rb = GetRigidbody2D();
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
        var rb = GetRigidbody2D();
        Vector3 v = rb.velocity;
        float rat = ParamsSO.Entity.sardineSpeed - v.magnitude;

        return v * rat;
    }

    // Flip Image by speed for x-axies
    private void fixDirection()
    {
        var rb = GetRigidbody2D();
        Vector3 scale = transform.localScale;
        float sx = transform.localScale.x;
        float vx = rb.velocity.x;

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
        var rb = GetRigidbody2D();
        //want 1 from "0"
        float f = Mathf.Sign(rb.velocity.x);
        if (f == 0)
            return 1f;
        return f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    float default_scale_x = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        // init speed
        float ang = Random.Range(0, 359);
        float spd = 3;

        Vector2 v;
        v.x = Mathf.Cos(Mathf.Deg2Rad * ang) * spd;
        v.y = Mathf.Sin(Mathf.Deg2Rad * ang) * spd;
        GetComponent<Rigidbody2D>().velocity = v;

        // Get default scale
        Vector3 scale = transform.localScale;
        default_scale_x = scale.x;

        Debug.Log($"scale :{default_scale_x}");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        fixDirection();
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

    public void onClickFish()
    {
        Debug.Log("OnClickFish");
        Destroy(this.gameObject);
    }
}

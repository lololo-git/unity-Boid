using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwashi : MonoBehaviour
{

    BoidSettings settings;

    private float default_scale_x = 1;

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
    }

    void Update()
    {
        //Debug.Log("Update");
        fixDirection();

        //���N���b�N����������
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("�N���b�N���ꂽ��I");
        }

        //���N���b�N��b������
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("�N���b�N�����I");
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

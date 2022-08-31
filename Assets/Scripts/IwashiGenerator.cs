using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiGenerator : MonoBehaviour
{
    [SerializeField] private GameObject iwashiPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        //左クリックを押した時
        if (Input.GetMouseButtonDown(0))
        {
            // GetObject with Beam(from mouse)
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit)
            {
                Debug.Log("RaycastHit2D: Clicked！" + hit.collider.gameObject.name);
            }
        }
    }

    public IEnumerator Spawn(int num)
    {
        Debug.Log(num);
        Vector2 pos;
        for (int i = 0; i < num; i++)
        {
            pos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            Instantiate(iwashiPrefab, pos, transform.rotation);

            yield return new WaitForSeconds(1f);
        }
    }
}
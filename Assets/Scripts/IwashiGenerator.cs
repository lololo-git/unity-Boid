using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiGenerator : MonoBehaviour
{
    private BoidSettings settings;
    public const int IWASHI_NUM = 10;

    [SerializeField] private GameObject iwashiPrefab;
    private GameObject[] iwashis = new GameObject[IWASHI_NUM];

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Generator());

        // Test to load from ParamsSO
        Debug.Log($"Score: {ParamsSO.Entity.score}");
    }

    // Update is called once per frame
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

    private IEnumerator Generator()
    {
        Vector2 pos;
        for (int i = 0; i < IWASHI_NUM; i++)
        {
            pos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            iwashis[i] = Instantiate(iwashiPrefab, pos, transform.rotation);

            yield return new WaitForSeconds(1f);
        }
    }
}
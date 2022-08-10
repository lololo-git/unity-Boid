using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiGenerator : MonoBehaviour
{
    BoidSettings settings;
    public const int IWASHI_NUM = 10;

    [SerializeField] private GameObject iwashiPrefab;
    private GameObject[] iwashis = new GameObject[IWASHI_NUM];


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generator()
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

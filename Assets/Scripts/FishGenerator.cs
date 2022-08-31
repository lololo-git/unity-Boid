using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sardinePrefab;

    public IEnumerator Spawn(int num)
    {
        Vector2 pos;
        for (int i = 0; i < num; i++)
        {
            pos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            Instantiate(sardinePrefab, pos, transform.rotation);

            yield return new WaitForSeconds(1f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sardinePrefab;
    private List<Sardine> sardines = new List<Sardine>();

    public IEnumerator Spawn(int num)
    {
        Vector2 pos;
        for (int i = 0; i < num; i++)
        {
            pos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            GameObject obj = Instantiate(sardinePrefab, pos, transform.rotation);
            Sardine ins = obj.GetComponent<Sardine>();

            sardines.Add(ins);
            ins.SetSardineList(sardines);

            yield return new WaitForSeconds(1f);
        }
    }

    public List<Sardine> GetSardineList()
    {
        return sardines;
    }
}
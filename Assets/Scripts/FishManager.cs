using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    [SerializeField] private GameObject sardinePrefab;

    private List<Sardine> sardineList = new List<Sardine>();
    private Dictionary<string, float> distanceCache = new Dictionary<string, float>();

    private void FixedUpdate()
    {
        flushDistanceCache();
    }

    public IEnumerator Spawn(int num)
    {
        Vector2 pos;
        for (int i = 0; i < num; i++)
        {
            pos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            GameObject obj = Instantiate(sardinePrefab, pos, transform.rotation);
            Sardine sardine = obj.GetComponent<Sardine>();

            sardineList.Add(sardine);
            sardine.SetID(i);
            sardine.SetSardineList(sardineList);
            sardine.SetFishManager(this);

            yield return new WaitForSeconds(1f);
        }
    }

    public List<Sardine> GetSardinesByRange(Sardine sardine, float range)
    {
        List<Sardine> result = new List<Sardine>();
        foreach (Sardine target in sardineList)
        {
            if (sardine.GetID() == target.GetID())
                continue;
            if (GetDistance(sardine, target) < range)
                result.Add(target);
        }
        return result;
    }

    public float GetDistance(Sardine s1, Sardine s2)
    {
        if (s1 == s2)
        {
            Debug.LogError("Distance between same Object");
            return 0;
        }

        string key = GetCacheKey(s1.GetID(), s2.GetID());
        if (distanceCache.ContainsKey(key))
            return distanceCache[key];

        float distance = Vector2.Distance(s1.transform.position,
                                          s2.transform.position);
        distanceCache[key] = distance;
        return distance;
    }

    private string GetCacheKey(int id1, int id2)
    {
        if (id1 < id2)
            return $"{id1}-{id2}";
        return $"{id2}-{id1}";
    }

    private void flushDistanceCache()
    {
        distanceCache = new Dictionary<string, float>();
    }
}
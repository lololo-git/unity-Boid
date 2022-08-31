using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private FishGenerator fishGenerator = default;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(fishGenerator.Spawn(ParamsSO.Entity.sardineNum));
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
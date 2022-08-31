using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private IwashiGenerator iwashiGenerator = default;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(iwashiGenerator.Spawn(ParamsSO.Entity.iwashiNum));
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
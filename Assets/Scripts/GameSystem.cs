using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private FishManager fishManager = default;

    private void Start()
    {
        StartCoroutine(fishManager.Spawn(ParamsSO.Entity.sardineNum));
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnDragBegin();
        }
    }

    private void OnDragBegin()
    {
        Sardine sardine = GetPointedSardine();
        if (sardine)
        {
            sardine.RandomizeSpeed();
        }
    }

    private Sardine GetPointedSardine()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (!hit)
            return null;
        Sardine sardine = hit.collider.GetComponent<Sardine>();
        return sardine ? sardine : null;
    }
}
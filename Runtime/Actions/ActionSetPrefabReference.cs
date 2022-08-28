using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSetPrefabReference : MonoBehaviour
{
    [SerializeField]
    PrefabReference reference;

    [SerializeField]
    GameObject prefab;

    public void Action_SetPrefab()
    {
        reference.Prefab = prefab;
    }

    public void Action_SetPrefab(GameObject prefab)
    {
        reference.Prefab = prefab;
    }
}

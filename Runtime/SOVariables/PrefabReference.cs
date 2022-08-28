using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="prefab", menuName = "DataObjects/Prefab")]
public class PrefabReference : ValueObject
{
    public GameObject Prefab;
}

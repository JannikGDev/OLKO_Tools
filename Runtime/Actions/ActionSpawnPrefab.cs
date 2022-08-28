using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSpawnPrefab : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    PrefabReference reference;

    [SerializeField]
    Vector3 position = Vector3.zero;

    [SerializeField]
    Quaternion rotation = Quaternion.identity;

    [SerializeField]
    bool SpawnRelativeToCreator = true;

    [SerializeField]
    Transform parent = null;

    public void Action_SpawnPrefab()
    {
        if(prefab == null && reference.Prefab != null)
            Action_SpawnPrefab(reference.Prefab);
        else if(prefab != null)
            Action_SpawnPrefab(prefab);
    }

    public void Action_SpawnPrefab(GameObject prefab)
    {
        if(parent != null)
        {
            if (SpawnRelativeToCreator)
                Instantiate(prefab, position + this.transform.position, rotation, parent);
            else
                Instantiate(prefab, position, rotation, parent);
        }

        if(SpawnRelativeToCreator)
            Instantiate(prefab, position + this.transform.position, rotation);
        else
            Instantiate(prefab, position, rotation);
    }
}

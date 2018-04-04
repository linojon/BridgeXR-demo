using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class assetLoader : MonoBehaviour
{
    public BxrPrefab prefab;

    void Start()
    {
        Instantiate(prefab.PrefabObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectFactory : ScriptableObject
{
    protected T InstantiateObject<T>(T prefab, Transform parent = null) where T : MonoBehaviour
    {
        return Instantiate(prefab, parent);
    }
}

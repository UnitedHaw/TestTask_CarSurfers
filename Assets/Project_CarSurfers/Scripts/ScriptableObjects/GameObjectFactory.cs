using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectFactory", menuName = "Factory")]
public class GameObjectFactory : ScriptableObject
{
    public T InstantiateObject<T>(T prefab, Transform parent = null) where T : MonoBehaviour
    {
        return Instantiate(prefab, parent);
    }
}

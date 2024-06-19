using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPieceView : MonoBehaviour
{
    [SerializeField] private Transform _view;
    public float Width => _view.localScale.x;
    public float Height => _view.localScale.y;
    public float Length => _view.localScale.z;
    public Vector3 StartPoint => transform.position - new Vector3(Width/2, 0, 0);

    public void Enable(bool value)
    {
        gameObject.SetActive(value);
    }
}

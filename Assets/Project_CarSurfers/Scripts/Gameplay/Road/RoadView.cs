using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadView : MonoBehaviour
{
    [SerializeField] private Transform _view;
    public float Width => _view.localScale.x;
    public float Height => _view.localScale.y;
    public float Length => _view.localScale.z;
    public void Enable(bool value)
    {
        gameObject.SetActive(value);
    }
}

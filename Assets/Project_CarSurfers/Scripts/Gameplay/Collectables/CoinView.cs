using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PrometeoCarController controller))
        {
            Enable(false);
        }
    }

    public void Enable(bool enable)
    {
        if(enable)
            transform.localScale = Vector3.one;
        else
            transform.DOScale(0, .5f);
    }
}

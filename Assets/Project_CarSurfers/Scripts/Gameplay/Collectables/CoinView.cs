using Assets.Project_CarSurfers.Scripts.Controllers;
using Assets.Project_CarSurfers.Scripts.Interfaces;
using DG.Tweening;
using Reflex.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            Enable(false);
            player.AddCoin();
        }
    }

    public void Enable(bool enable)
    {
        if (enable)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.DOScale(0, .5f);
            VFXController.Instance.PlayParticle(VfxType.Coin, transform.position);
        }    
    }
}

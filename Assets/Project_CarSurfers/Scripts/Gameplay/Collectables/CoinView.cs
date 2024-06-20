using Assets.Project_CarSurfers.Scripts.Gameplay;
using DG.Tweening;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
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

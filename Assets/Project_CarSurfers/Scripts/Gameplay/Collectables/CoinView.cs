using Assets.Project_CarSurfers.Scripts.Gameplay;
using DG.Tweening;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Enable(false);
            player.AddCoin();
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    public void Enable(bool enable)
    {
        if (enable)
        {
            transform.localScale = Vector3.one;
            transform.eulerAngles = Vector3.zero;   
        }
        else
        {
            transform.DOScale(0, .5f);
            VFXController.Instance.PlayParticle(VfxType.Coin, transform.position);
        }    
    }
}

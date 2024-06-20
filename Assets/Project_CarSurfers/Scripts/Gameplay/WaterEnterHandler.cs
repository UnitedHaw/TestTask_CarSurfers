using Assets.Project_CarSurfers.Scripts.Gameplay;
using Reflex.Attributes;
using UnityEngine;

public class WaterEnterHandler : MonoBehaviour
{
    [Inject] private IGameStateController _gameState;
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Fail();
        }
    }
}

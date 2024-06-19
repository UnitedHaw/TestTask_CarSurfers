using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : WorldSpawner
{
    [Inject] private CoinSpawner _coinSpawner;
    protected override void GetAction(WorldPieceView road)
    {
        base.GetAction(road);
        //_coinSpawner.SpawnCoins(road);
    }

    protected override void ReleaseAction(WorldPieceView road)
    {
        //_coinSpawner.RemoveCoins(road);
    }
}

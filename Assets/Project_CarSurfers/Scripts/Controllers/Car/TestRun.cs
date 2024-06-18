using Assets.Project_CarSurfers.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRun : MonoBehaviour
{
    [SerializeField] private JoystickCarController _car;

    private void Update()
    {
        _car.TurnByAxis(-.2f);
    }
}

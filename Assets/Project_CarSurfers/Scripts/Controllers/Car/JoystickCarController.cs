﻿using System;
using UnityEngine;

namespace Assets.Project_CarSurfers.Scripts
{
    public class JoystickCarController : PrometeoCarController
    {
        [SerializeField, Range(0, .9f)] private float _minAxisThreshold;

        public void TurnByAxis(float axis)
        {
            if (Mathf.Abs(axis) < _minAxisThreshold) return;

            if (axis < 0)
            {
                steeringAxis = steeringAxis - (Time.deltaTime * 10f * steeringSpeed);
                if (steeringAxis < -1f)
                {
                    steeringAxis = -1f;
                }
            }else
            {
                steeringAxis = steeringAxis + (Time.deltaTime * 10f * steeringSpeed);
                if (steeringAxis > 1f)
                {
                    steeringAxis = 1f;
                }
            }

            var steeringAngle = steeringAxis * Math.Abs(axis) * maxSteeringAngle;
            frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);
            frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
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

            Debug.Log("Steering axis: " +  steeringAxis);

            var steeringAngle = steeringAxis * Math.Abs(axis) * maxSteeringAngle;
            frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);
            frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
            Debug.Log("steeringAngle: " + steeringAngle);
        }
    }
}

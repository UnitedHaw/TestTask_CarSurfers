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
        public void TurnByAxis(float axis)
        {
            Debug.Log("Turn Axis: " + axis);

            if (axis == 0) return;

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

            var steeringAngle = steeringAxis * maxSteeringAngle;
            frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);
            frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
        }

        public void MoveForwardByAxis(float axis)
        {
            Debug.Log("Move axis: " + axis);
            GoForward();
        }
    }
}

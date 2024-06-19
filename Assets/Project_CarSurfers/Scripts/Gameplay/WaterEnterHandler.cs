using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnterHandler : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PrometeoCarController controller))
        {
            controller.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

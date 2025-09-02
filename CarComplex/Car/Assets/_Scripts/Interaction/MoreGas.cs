using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreGas : MonoBehaviour
{
    public float refillAmount = 30f; // cuánta gasolina da este objeto

    private void OnTriggerEnter(Collider other)
    {
        GasMechanic gas = other.GetComponent<GasMechanic>();
        if (gas != null)
        {
            gas.Refuel(refillAmount);
            Destroy(gameObject); // desaparece el bidón
        }
    }
}

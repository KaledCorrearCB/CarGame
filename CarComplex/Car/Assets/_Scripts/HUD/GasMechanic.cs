using System;
using UnityEngine;

public class GasMechanic : MonoBehaviour
{
    public float fuel;

    public void UpdateTachymeter(Rigidbody rb)
    {
        // Si el carro se está moviendo, baja el nivel de la gasolina y se aplica el método del HUD.
        if (rb.velocity.magnitude > 0.1)
        {
            fuel -= Time.deltaTime;
            HUDManager.Instance.NeedleRotation(fuel);
        }
        //Debug.Log(fuel);
    }

    public void Refuel(float amount)
    {
        fuel = Mathf.Min(fuel + amount, HUDManager.Instance.maxFuel);
        HUDManager.Instance.NeedleRotation(fuel); // actualizar HUD
        Debug.Log("Gasolina recargada: " + fuel);
    }

}

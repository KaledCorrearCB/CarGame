using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPill : MonoBehaviour
{
    [Header("Speed pill")]
    public float multiplier = 1.5f;   // Factor de multiplicación de velocidad
    public float duration = 5f;     // Duración del efecto

    private static bool isBoostActive = false;  // Protección contra stacking
    private static Coroutine activeCoroutine;   // Referencia a la corutina en curso

    private void OnTriggerEnter(Collider car)
    {
        CarMovement carMovement = car.GetComponent<CarMovement>();
        if (carMovement == null) return;

        CarSO carSO = carMovement.car;

        // Si ya hay un boost en curso, reiniciamos la corutina (extiende duración)
        if (isBoostActive && activeCoroutine != null)
        {
            carMovement.StopCoroutine(activeCoroutine);
            carSO.speed = carMovement.OriginalSpeed; // aseguro resetear antes de reaplicar
        }

        // Arrancamos la nueva corutina
        activeCoroutine = carMovement.StartCoroutine(SpeedUpdate(carSO, carMovement));
        Destroy(gameObject);
    }

    IEnumerator SpeedUpdate(CarSO carSO, CarMovement carMovement)
    {
        isBoostActive = true;

        // Guardamos el original si aún no estaba guardado
        if (carMovement.OriginalSpeed == 0)
            carMovement.OriginalSpeed = carSO.speed;

        // Aplicamos boost
        carSO.speed = carMovement.OriginalSpeed * multiplier;

        // Esperamos duración
        yield return new WaitForSeconds(duration);

        // Restauramos
        carSO.speed = carMovement.OriginalSpeed;
        isBoostActive = false;
        activeCoroutine = null;
    }

}

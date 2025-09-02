using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPill : MonoBehaviour
{
    [Header("Speed pill")]
    public float newSpeed = 30f;      // velocidad que tomará el carro 
    public float duration = 5f;       // cuánto dura el efecto en segundos

    private void OnTriggerEnter(Collider car)
    {
        CarSO carSO = car.gameObject.GetComponent<CarMovement>().car;
        float originalSpeed = carSO.speed;
        StartCoroutine(SpeedUpdate(carSO, originalSpeed));

        Destroy(gameObject);
    }

    IEnumerator SpeedUpdate(CarSO carSo, float originalSpeed)
    {
        carSo.speed *= 6;
        yield return new WaitForSeconds(duration);
        carSo.speed = originalSpeed;
    }

}

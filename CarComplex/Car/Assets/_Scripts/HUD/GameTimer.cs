using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Tiempo de partida (segundos)")]
    public float startTime = 60f; // tiempo inicial en segundos
    private float currentTime;
    private bool isGameOver = false;

    private void Start()
    {
        currentTime = startTime;
        HUDManager.Instance.UpdateTimerUI(currentTime); // mostrar el tiempo inicial en el HUD
    }

    private void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        HUDManager.Instance.UpdateTimerUI(currentTime); // actualizar HUD cada frame
    }

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("Juego terminado"); // 👈 de momento solo esto
    }
}

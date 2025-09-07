using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;
    
    [Header("Kilometers")]
    public TextMeshProUGUI kmText;
    public float maxFuel;
    public GameObject gasNeedle;

    [Header("Gas")] 
    public float minRotation = -70f;
    public float maxRotation = 70f;
    // Se pone  una variable nueva con la cual se pueda guardar el texto
    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Método para escribir en el HUD los Km/h. Para ello se multiplica la velocidad por 3.6,
    public void KmByHour(float value)
    {
        var kmByHour = value * 3.6f;
        kmText.text = kmByHour.ToString("####") + " Km/h";
    }
    
    public void NeedleRotation(float fuel)
    {
        // Rota la aguja dependiendo del nivel de gasolina que tenga el carro.
        float fuelPercent = fuel / maxFuel;
        float angle = Mathf.Lerp(minRotation, maxRotation, fuelPercent);
        gasNeedle.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    // se crea el metodo que escribe el puntaje
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Puntos: " + newScore;
    }

}

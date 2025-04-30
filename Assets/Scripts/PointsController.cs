using UnityEngine;
using UnityEngine.UI;
public class PointsController : MonoBehaviour
{
    public static PointsController instance; // Instância única do controlador de pontos
    public Text pointsText; // Referência ao componente de texto
    private int points = 0; // Variável para armazenar os pontos

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetPoints(); // Atualiza o texto inicial dos pontos
    }

    public void AddPoints(int amount)
    {
        points += amount; // Adiciona pontos
        UpdatePointsText(); // Atualiza o texto dos pontos
    }

    public void ResetPoints()
    {
        points = 0; // Reseta os pontos
        UpdatePointsText(); // Atualiza o texto dos pontos
    }

    private void UpdatePointsText()
    {
        pointsText.text = points.ToString(); // Atualiza o texto com a quantidade de pontos
    }
}

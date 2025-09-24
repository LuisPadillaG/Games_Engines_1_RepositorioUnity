using UnityEngine;
using UnityEngine.UI;

public class ManejadorUI : MonoBehaviour
{
    public GameObject ObjetoMonedas;
    Text componenteMonedas;
    int monedas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        componenteMonedas = ObjetoMonedas.GetComponent<Text>();
        monedas = 0;
    }

    // Update is called once per frame
    public void SumarMoneda()
    {
        monedas++;
        componenteMonedas.text = "Monedas: " + monedas;

    }
}

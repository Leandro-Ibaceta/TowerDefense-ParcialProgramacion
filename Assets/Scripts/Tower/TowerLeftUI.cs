using TMPro;
using UnityEngine;

public class TowerLeftUI : MonoBehaviour
{
    [SerializeField] private TowerPlacement towerPlacement;
    private TextMeshProUGUI towerUI;

    private void Awake()
    {
        towerUI = GetComponent<TextMeshProUGUI>();
        towerPlacement.OnTowerPlaced += UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        towerUI.text = "Pilares restantes: " + towerPlacement.TowersLeft.ToString();
    }

}

using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerBase playerBase;
    private TextMeshProUGUI healthUI;

    private void Awake()
    {
        healthUI = GetComponent<TextMeshProUGUI>();
        playerBase.OnBaseHit += UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthUI.text = "Vidas: " + GameManager.instance.PlayerHealth.ToString();
    }

}

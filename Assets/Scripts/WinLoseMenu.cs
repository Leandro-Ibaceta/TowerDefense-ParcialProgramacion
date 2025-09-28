using UnityEngine;

public class WinLoseMenu : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject GameUI;


    public void SetWinPanel(bool state)
    {
        winPanel.SetActive(state);
        TurnOnGameUI();
    }

    public void SetLosePanel(bool state)
    {
        losePanel.SetActive(state);
        TurnOffGameUI();
    }

    public void TurnOnGameUI()
    {
        GameUI.gameObject.SetActive(true);
    }

    public void TurnOffGameUI() 
    {
        GameUI.gameObject.SetActive(false);
    }
}

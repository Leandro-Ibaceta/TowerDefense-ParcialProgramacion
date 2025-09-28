using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject startGamePanel;
    private int playerHealth = 5;
    private int enemyKilled = 0;
    public int EnemyKilled { get => enemyKilled; set => enemyKilled = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public Transform[] waypoint;
    public Transform startPoint, endPoint;
    private WinLoseMenu menu;
    private TowerPlacement towerPlacement;
    private EnemySpawner enemySpawner;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        menu = GetComponent<WinLoseMenu>();
        towerPlacement = GetComponent<TowerPlacement>();
        enemySpawner = GetComponentInChildren<EnemySpawner>();
    }
    
    
    private void Start()
    {
        menu.SetLosePanel(false);
        menu.SetWinPanel(false);
        menu.TurnOffGameUI();
        SetTowerPlacementSystem(false);

        startPoint = waypoint[0];
        endPoint = waypoint[waypoint.Length - 1];
    }
    private void Update()
    {
        if (enemyKilled == enemySpawner.EnemiesAlive)
        {
            YouWin();
        }
    }

    public void SetTowerPlacementSystem(bool state)
    {
        towerPlacement.enabled = state;
    }
    public void StartGame() 
    {
        if(startGamePanel.activeSelf == true)
            startGamePanel.SetActive(false);


        menu.SetLosePanel(false);
        menu.SetWinPanel(false);
        menu.TurnOnGameUI();
        SetTowerPlacementSystem(true);
    }
    public void YouWin()
    {
        menu.SetWinPanel(true);
        menu.TurnOffGameUI();
        SetTowerPlacementSystem(false);
    }

    public void YouLose()
    {
        menu.SetLosePanel(true);
        menu.TurnOffGameUI();
        SetTowerPlacementSystem(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}

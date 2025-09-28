using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private int towersLeft = 3;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap validTileMap;
    [SerializeField] private Tile buildableTile;

    public event Action OnTowerPlaced;

    public int TowersLeft => towersLeft;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3Int cellPosition = grid.WorldToCell(mousePosition);
        
        if(Input.GetMouseButtonDown(0))
        {
            if(validTileMap.GetTile(cellPosition) == buildableTile && IsTowersLeft())
            {
                Vector3 towerPosition = grid.WorldToCell(cellPosition) + grid.cellSize / 2;
                placeTower(towerPosition);
                validTileMap.SetTile(cellPosition, null);
                OnTowerPlaced?.Invoke();
            }

        }
    }

    public void placeTower(Vector3 position)
    {
        towersLeft--;
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    private bool IsTowersLeft()
    {
        return towersLeft > 0;
    }
    
}

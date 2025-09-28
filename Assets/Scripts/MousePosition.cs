using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private TowerPlacement towerPlacement;
    private Camera mainCamera;
    private Vector3 lastPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3Int mouseToCell = grid.WorldToCell(mousePosition);
        
        transform.position = grid.GetCellCenterLocal(mouseToCell);
    }

    public Vector3 GetLastPosition()
    {
        return lastPosition;
    }
}

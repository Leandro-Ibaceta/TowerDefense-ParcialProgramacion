using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform[] waypoint;
    public Vector3 startPoint, endPoint;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        startPoint = waypoint[0].position;
        endPoint = waypoint[waypoint.Length - 1].position;
    }
}

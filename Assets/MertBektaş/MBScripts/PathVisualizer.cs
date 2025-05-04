using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathVisualizer : MonoBehaviour
{
    [Header("Path Settings")]
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] private Transform[] gateOnePositions;
    [SerializeField] private Transform[] gateTwoPositions;
    [SerializeField] private Transform[] gateThreePositions;
    [SerializeField] private Transform[] callShipPositions;
    
    private LineRenderer lineRenderer;
    private Transform[] activePath;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetActivePath(pathPoints); // Varsayılan yol
    }

    public void SetActivePath(Transform[] newPath)
    {
        activePath = newPath;
        UpdateLineRenderer();
    }

    public void UseGateOnePath()
    {
        SetActivePath(gateOnePositions);

    }

    public void UseGateTwoPath()
    {
        SetActivePath(gateTwoPositions);
    }

    public void UseGateThreePath()
    {
        SetActivePath(gateThreePositions);
    }

    public void CallShip()
    {
        SetActivePath(callShipPositions);
    }

    private void UpdateLineRenderer()
    
    {
        if (activePath == null || activePath.Length == 0) return;

        lineRenderer.positionCount = activePath.Length;
        for (int i = 0; i < activePath.Length; i++)
        {
            if (activePath[i] != null)
            {
                lineRenderer.SetPosition(i, activePath[i].position);
            }
        }
    }

    public Transform[] GetActivePath()
    {
        return activePath;
    }
}
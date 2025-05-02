using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathVisualizer : MonoBehaviour
{
    [SerializeField] private Transform[] pathPoints;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = pathPoints.Length;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            line.SetPosition(i, pathPoints[i].position);
        }
    }
}
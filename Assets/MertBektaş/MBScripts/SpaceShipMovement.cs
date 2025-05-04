using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField] private float arrivalThreshold = 0.1f;

    [Header("References")]
    [SerializeField] private PathVisualizer pathVisualizer;

    private Transform[] currentPath;
    private int currentPointIndex = 0;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving || currentPath == null || currentPointIndex >= currentPath.Length) 
            return;

        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        Vector3 targetPosition = currentPath[currentPointIndex].position;
        
        // Hareket
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Rotasyon
        RotateTowardsTarget(targetPosition);

        // Hedefe ulaşma kontrolü
        if (Vector3.Distance(transform.position, targetPosition) < arrivalThreshold)
        {
            currentPointIndex++;
            if (currentPointIndex >= currentPath.Length)
            {
                StopMovement();
                Debug.Log("Hedefe ulaşıldı!");
            }
        }
    }

    private void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    public void StartMovement()
    {
        if (pathVisualizer == null) return;
        
        currentPath = pathVisualizer.GetActivePath();
        if (currentPath == null || currentPath.Length == 0)
        {
            Debug.LogWarning("Aktif yol tanımlı değil!");
            return;
        }

        currentPointIndex = 0;
        isMoving = true;
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    public void ResetMovement()
    {
        currentPointIndex = 0;
        isMoving = false;
    }
}


//iyice kayboldum içinde amaaaan
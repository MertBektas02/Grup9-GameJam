using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] private LineRenderer path;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 3f;
    private int currentPoint = 0;
    private bool isMoving = true;

    void Update()
    {
        if (!isMoving || path == null || currentPoint >= path.positionCount) return;

        // Hedef noktayı al
        Vector3 targetPos = path.GetPosition(currentPoint);
        
        // Hareket
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // Rotasyon (yumuşak dönüş)
        Vector3 direction = (targetPos - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Sonraki noktaya geç
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            currentPoint++;
            
            // Son noktada dur
            if (currentPoint >= path.positionCount)
            {
                isMoving = false;
                Debug.Log("Yolculuk tamamlandı!");
            }
        }
    }
}
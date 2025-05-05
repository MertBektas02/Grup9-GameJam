using UnityEngine;
using UnityEngine.Events;

public class PathVisualizer2 : MonoBehaviour
{
    [Header("Path Settings")]
    [SerializeField] private Transform[] pathPoints; // Inspector'dan atanacak noktalar
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 3f;

    [Header("Events")]
    public UnityEvent OnPathStarted;
    public UnityEvent OnPathCompleted;

    private bool isMoving = false;
    private int currentPointIndex = 0; // Şu anki hedef noktanın indeksi

    void Update()
    {
        if (!isMoving || pathPoints == null || currentPointIndex >= pathPoints.Length) 
            return;

        // Mevcut hedef noktanın pozisyonunu al
        Vector3 targetPos = pathPoints[currentPointIndex].position;

        // Hareket ve rotasyon
        transform.position = Vector3.MoveTowards(
            transform.position, 
            targetPos, 
            moveSpeed * Time.deltaTime
        );

        // Yumuşak dönüş
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

        // Hedefe ulaşıldığında sonraki noktaya geç
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            currentPointIndex++;

            // Tüm noktalar tamamlandıysa dur
            if (currentPointIndex >= pathPoints.Length)
            {
                isMoving = false;
                OnPathCompleted.Invoke();
                Debug.Log("Yolculuk tamamlandı!");
            }
        }
    }

    // BUTONLA ÇAĞRILACAK FONKSİYON
    public void StartPath()
    {
        if (pathPoints == null || pathPoints.Length == 0)
        {
            Debug.LogError("PathPoints dizisi boş veya atanmamış!");
            return;
        }

        // Başlangıçta ilk noktaya gitmek için ayarla
        currentPointIndex = 0;
        isMoving = true;
        OnPathStarted.Invoke();
        Debug.Log("Yolculuk başladı! İlk hedef: " + pathPoints[0].name);
    }
}
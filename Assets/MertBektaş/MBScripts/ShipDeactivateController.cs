using UnityEngine;
using System.Collections;

public class ShipDeactivateController : MonoBehaviour
{
    [Header("Ship Ayarları")]
    [SerializeField] private GameObject shipPrefab;  // Inspector’dan atanacak
    [SerializeField] private Transform spawnPoint;    // Opsiyonel spawn noktası (yoksa (0,0,0))

    private GameObject ship;
    private bool shipInTrigger = false;
    private bool waitingToSpawn = false;

    private void Update()
    {
        // Eğer sahnede bir PathVisualizer varsa, ship arama
        if (FindFirstObjectByType<PathVisualizer>() != null)
            return;

        // Sahnede aktif "Ship" etiketi taşıyan bir obje yoksa spawn başlat
        if (!waitingToSpawn && GameObject.FindGameObjectWithTag("Ship") == null)
        {
            StartCoroutine(SpawnShipWithDelay(5f));
        }
    }

    private IEnumerator SpawnShipWithDelay(float delay)
    {
        waitingToSpawn = true;
        yield return new WaitForSeconds(delay);

        // Delay süresince başka biri ship spawn etti mi?
        if (GameObject.FindGameObjectWithTag("Ship") == null)
        {
            InstantiateNewShip();
        }
        else
        {
            Debug.Log("Gemi zaten sahnede, yeni gemi oluşturulmadı.");
        }

        waitingToSpawn = false;
    }

    private void InstantiateNewShip()
    {
        if (shipPrefab == null)
        {
            Debug.LogWarning("Ship prefab atanmadı!");
            return;
        }

        // Yine de kontrol et (güvenlik açısından)
        if (GameObject.FindGameObjectWithTag("Ship") != null)
        {
            Debug.Log("Sahnede zaten aktif bir ship var, yeni gemi oluşturulmadı.");
            return;
        }

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : Vector3.zero;
        Quaternion spawnRot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

        ship = Instantiate(shipPrefab, spawnPos, spawnRot);
        ship.tag = "Ship"; // Etiketini tekrar ata
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            Debug.Log("ship içeri girdi");
            shipInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            Debug.Log("ship dışarı çıktı");
            shipInTrigger = false;
        }
    }

    // Bu metodu UI Button üzerinden çağıracaksın
public void DeactivateShip()
{
    if (shipInTrigger)
    {
        GameObject currentShip = GameObject.FindGameObjectWithTag("Ship");
        if (currentShip != null)
        {
            // SpaceShipMovement scriptini kapat
            SpaceShipMovement movement = currentShip.GetComponent<SpaceShipMovement>();
            if (movement != null)
            {
                movement.enabled = false;
            }

            // Ship tag'ini değiştir
            currentShip.tag = "empty";

            // Ship objesini deaktif et
            currentShip.SetActive(false);

            ship = null;
            Debug.Log("Ship devre dışı bırakıldı ve etiketi değiştirildi.");
            return;
        }
    }

    Debug.Log("Ship trigger alanında değil veya ship bulunamadı.");
}
}

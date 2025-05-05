using UnityEngine;

public class TriggerDestroyer : MonoBehaviour
{
    [Header("Spawn Ayarları")]
    [SerializeField] private GameObject shipPrefab;      // Inspector'dan atanacak prefab
    [SerializeField] private Transform spawnPoint;        // İsteğe bağlı spawn pozisyonu

    private GameObject objectInTrigger;
    private bool isObjectInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        objectInTrigger = other.gameObject;
        isObjectInTrigger = true;
        Debug.Log($"{objectInTrigger.name} trigger alanına girdi.");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectInTrigger)
        {
            Debug.Log($"{objectInTrigger.name} trigger alanından çıktı.");
            objectInTrigger = null;
            isObjectInTrigger = false;
        }
    }

    // Bu metodu UI butonundan çağır
    public void DestroyObjectInTrigger()
    {
        if (isObjectInTrigger && objectInTrigger != null)
        {
            Debug.Log($"{objectInTrigger.name} yok ediliyor.");
            Destroy(objectInTrigger);
            objectInTrigger = null;
            isObjectInTrigger = false;

            InstantiateNewShip();
        }
        else
        {
            Debug.Log("Nesne trigger alanında değil veya null.");
        }
    }

    private void InstantiateNewShip()
    {
        if (shipPrefab == null)
        {
            Debug.LogWarning("Ship prefab atanmadı!");
            return;
        }

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : Vector3.zero;
        Quaternion spawnRot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

        GameObject newShip = Instantiate(shipPrefab, spawnPos, spawnRot);
        Debug.Log("Yeni ship instantiate edildi: " + newShip.name);
    }
}

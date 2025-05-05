using UnityEngine;
using System.Collections;

public class ShipSceneManager : MonoBehaviour
{
    [Header("Ayarlar")]
    public string targetTag = "Ship"; // Kontrol edilecek nesne tagı
    public float initialDelay = 10f; // Başlangıç bekleme süresi
    public float exitCheckDelay = 10f; // Çıkış sonrası bekleme süresi
    public GameObject objectToInstantiate; // Üretilecek nesne prefabı

    private GameObject currentObjectInTrigger;
    private Coroutine checkRoutine;
    private bool isChecking = false;

    void Start()
    {
        // Başlangıçta 10 saniye bekle
        StartCoroutine(InitialDelayCoroutine());
    }

    IEnumerator InitialDelayCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);
        StartTriggerChecking();
    }

    void StartTriggerChecking()
    {
        if (!isChecking)
        {
            isChecking = true;
            checkRoutine = StartCoroutine(TriggerCheckRoutine());
        }
    }

    IEnumerator TriggerCheckRoutine()
    {
        while (isChecking)
        {
            // Trigger'da nesne var mı kontrol et
            if (currentObjectInTrigger == null)
            {
                Debug.Log("Trigger'da nesne yok, yeni nesne üretiliyor...");
                InstantiateNewObject();
            }
            else
            {
                Debug.Log("Trigger'da nesne mevcut: " + currentObjectInTrigger.name);
            }

            yield return new WaitForSeconds(1f); // Her saniye kontrol et
        }
    }

    void InstantiateNewObject()
    {
        if (objectToInstantiate != null)
        {
            GameObject newObj = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            newObj.tag = targetTag; // Yeni nesneye tag ata
            Debug.Log("Yeni nesne oluşturuldu: " + newObj.name);
        }
        else
        {
            Debug.LogWarning("Üretilecek nesne prefabı atanmamış!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log(targetTag + " trigger'a girdi");
            currentObjectInTrigger = other.gameObject;
            
            // Çıkış kontrol coroutine'ini durdur (varsa)
            StopAllCoroutines();
            StartTriggerChecking();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && other.gameObject == currentObjectInTrigger)
        {
            Debug.Log(targetTag + " trigger'dan çıktı, 10 saniye geri sayım başladı");
            currentObjectInTrigger = null;
            
            // Çıkış sonrası kontrolü başlat
            StartCoroutine(ExitDelayCoroutine());
        }
    }

    IEnumerator ExitDelayCoroutine()
    {
        yield return new WaitForSeconds(exitCheckDelay);
        
        // 10 saniye sonra hala trigger'da nesne yoksa yenisini üret
        if (currentObjectInTrigger == null)
        {
            InstantiateNewObject();
        }
    }

    void OnDisable()
    {
        // Script devre dışı kalırsa coroutine'leri durdur
        StopAllCoroutines();
        isChecking = false;
    }





    //DESTROY İŞLEMİNDEN SONRA INSTANTIATE İŞLEMİ YAPMAK ÇOK ZAHMETLİ VE KARIŞIK BİR HAL ALDI. oNUN YERİNE NESNEYİ SADECE DEACTIVE YAPACAĞIM.
    // [SerializeField] private GameObject ship;
    // [SerializeField] private GameObject[] shipPrefabs; 
    // [SerializeField] private GameObject spawnPos; 
    // private bool isAlive = false;

    // void Start()
    // {
    //     CheckisShipAlive();
    // }

    // void Update()
    // {
    //     CheckisShipAlive();
    // }

    // void CheckisShipAlive()
    // {
    //     if (ship == null && isAlive == true)
    //     {
    //         isAlive = false;
    //         SpawnNewShip();
    //     }
        
    //     if (ship != null && isAlive == false)
    //     {
    //         isAlive = true;
    //     }
    // }

    // void SpawnNewShip()
    // {
  
    //      if (shipPrefabs == null || shipPrefabs.Length == 0)
    //      {
    //          return;
    //      }

    
    //      if (spawnPos == null)
    //      {
    //          return;
    //      }


    //     int randomIndex = Random.Range(0, shipPrefabs.Length);
    //     GameObject selectedPrefab = shipPrefabs[randomIndex];

        
    //     ship = Instantiate(selectedPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
        
    //     Debug.Log("New ship spawned: " + selectedPrefab.name);
    // }
}
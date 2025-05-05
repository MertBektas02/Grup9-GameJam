using UnityEngine;

public class TeleportShip : MonoBehaviour
{
  public Animator animator;          
    public string triggerName = "TeleportShip"; 

          
     public void PlayAnimation()
    {
        // Animator null ise sahnedeki ilk Animator bileşenini bul
        if (animator == null)
        {
            animator = FindFirstObjectByType<Animator>();
        }

        if (animator != null)
        {
            
            animator.SetTrigger(triggerName);
            SoundManager.PlaySound(SoundType.TELEPORTATION);
            Destroy(gameObject, 4f); // 4 saniye sonra objeyi yok et
        }
        else
        {
            Debug.LogWarning("Sahnede Animator bileşeni bulunamadı!");
        }
    }
}

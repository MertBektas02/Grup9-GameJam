using UnityEngine;
public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particle;
 public void PlayParticle()
    {
        if (particle != null)
        {
            particle.gameObject.SetActive(true); // GameObject'i aktive et
            particle.Play();
            Debug.Log("Particle oynatıldı: " + particle.name);
        }
        else
        {
            Debug.LogError("ParticleSystem referansı boş!");
        }
    }

    public void StopParticle()
    {
        if (particle != null)
        {
            particle.Stop();
            // particle.gameObject.SetActive(false); // Gerekirse kapat
        }
    }
}
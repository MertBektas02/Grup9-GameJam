using UnityEngine;
public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particle;
    public void PlayParticle()
    {
        if (particle != null)
            particle.Play();
    }
    public void StopParticle()
    {
        if (particle != null)
            particle.Stop();
    }
}
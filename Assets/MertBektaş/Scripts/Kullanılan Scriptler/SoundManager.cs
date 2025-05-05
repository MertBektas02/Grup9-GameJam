using System.Runtime.InteropServices;
using UnityEngine;

public enum SoundType
{
    ALARM,
    BUTTONCLICK,
    MAUSEONBUTTON,
    MAUSEONBUTTON2,
    TELEPORTATION,
    BACKGORUND
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundList;
   private static SoundManager instance;
   private AudioSource audioSource;

    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        audioSource=GetComponent<AudioSource>();
        PlaySound(SoundType.BACKGORUND);
    }

    public static void PlaySound(SoundType sound, float volume=1f)
   {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)sound]);
   }
}
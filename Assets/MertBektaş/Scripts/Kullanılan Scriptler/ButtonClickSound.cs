using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void PlayButtonClick()
    {
        SoundManager.PlaySound(SoundType.BUTTONCLICK);
    }
}

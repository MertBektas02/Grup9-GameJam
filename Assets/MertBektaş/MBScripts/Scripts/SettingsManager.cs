using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider masterVolumeSlider;
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        // Volume
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        masterVolumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);

        // Fullscreen
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);

        // Resolutions
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}

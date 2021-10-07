using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    private Slider volumeSlider;
    private float curentVolume;

    private void Start()
    {
        volumeSlider = gameObject.GetComponent<Slider>();

        if (volumeSlider != null)
        {
            volumeSlider.normalizedValue = PlayerPrefs.HasKey("VolumeLevel") ? PlayerPrefs.GetFloat("VolumeLevel") : curentVolume;
        }

    }

    private void FixedUpdate()
    {
        curentVolume = volumeSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", curentVolume);
    }
}

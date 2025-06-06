using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SliderEsercizi : MonoBehaviour
{
    public Light lightSource;     // La luce da controllare
    public Slider intensitySlider; // Lo slider che l'utente muove
    public AudioSource audioSource;     // La luce da controllare
    public Slider volumeSlider;
    void Start()
    {
        // Imposta il valore iniziale dello slider in base alla luce
        intensitySlider.value = lightSource.intensity;
        volumeSlider.value = audioSource.volume;
    }
    void Update()
    {
        // Aggiunge il listener per quando lo slider cambia
        intensitySlider.onValueChanged.AddListener(UpdateLightIntensity);
        volumeSlider.onValueChanged.AddListener(VolumeUpdate);
    }
    void UpdateLightIntensity(float value)
    {
        lightSource.intensity = value;
    }
    void VolumeUpdate(float value)
    {
        audioSource.volume = value;
    }
}

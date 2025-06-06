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

    public Toggle AttivaOggetto;
    public Toggle AttivaDisattivaPanello;
    public TextMeshProUGUI toggletext;
    public GameObject plane;
    public GameObject panelloinfo;
    
    void Start()
    {
        plane.SetActive(false);

        // Inizializza valori slider
        intensitySlider.value = lightSource.intensity;
        volumeSlider.value = audioSource.volume;

        // Aggiungi listener UNA VOLTA SOLA
        intensitySlider.onValueChanged.AddListener(UpdateLightIntensity);
        volumeSlider.onValueChanged.AddListener(VolumeUpdate);
        AttivaOggetto.onValueChanged.AddListener(AttivaDisattiva);
        AttivaDisattivaPanello.onValueChanged.AddListener(AttivaDisattivapanello);
    }
    void UpdateLightIntensity(float value)
    {
        lightSource.intensity = value;
    }
    void VolumeUpdate(float value)
    {
        audioSource.volume = value;
    }

    void AttivaDisattiva(bool isOn)
    {
        if (isOn)
        {
            plane.gameObject.SetActive(true);
            toggletext.text = "è Attivo";
        }
        else
        {
            plane.gameObject.SetActive(false);
            toggletext.text = "è Disattivo";
        }
    }

    void AttivaDisattivapanello(bool isOn)
    {
        if (isOn)
        {
            panelloinfo.gameObject.SetActive(true);
        }
        else
        {
            panelloinfo.gameObject.SetActive(false);
        }
    }
}

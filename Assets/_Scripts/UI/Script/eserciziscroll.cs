using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class eserciziscroll : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button[] buttons;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // importante: per evitare problemi di scope

            // Aggiungi listener al bottone
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }

    void OnButtonClicked(int index)
    {
        TextMeshProUGUI tmpText = buttons[index].GetComponentInChildren<TextMeshProUGUI>();
        if (tmpText != null)
        {
            text.text = tmpText.text;
        }
    }

}

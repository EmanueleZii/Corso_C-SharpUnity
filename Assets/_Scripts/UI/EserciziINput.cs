using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EserciziINput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI outputText;

    public void ReadInput()
    {
        string userInput = inputField.text;
        if (outputText != null)
            outputText.text = "Hai inserito" + userInput;
    }

}

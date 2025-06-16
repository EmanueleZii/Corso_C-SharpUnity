using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Students : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI textPrefab;
    public Transform spawnParent;
    public void SpawnText() {
        string userInput = inputField.text;
        TextMeshProUGUI newText = Instantiate(textPrefab, spawnParent);
        newText.text = userInput;
    }
    public void ResetTesti() {
        foreach (Transform child in spawnParent) {
            Destroy(child.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class Difficolta : MonoBehaviour
{
    public TMP_Dropdown myDropdown;

    public TextMeshProUGUI text;
    void Start()
    {
        myDropdown.ClearOptions();

        List<string> options = new List<string> { "facile", "medio", "difficile" };
        myDropdown.AddOptions(options);


        if (myDropdown == null)
            myDropdown = GetComponent<TMP_Dropdown>();

        myDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    public void OnDropdownChanged(int scelta)
    {
        switch (scelta)
        {
            case 0:
                text.text = "sei una pippa";
                break;
            case 1:
                text.text = "casual gamer";
                break;
            case 2:
                text.text = "weee te la tiriiii";
                
                break;
            default:
                text.text = "qualcosa e andato storto...";
                break;
        }
    }
}

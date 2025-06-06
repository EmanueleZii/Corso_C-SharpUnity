using UnityEngine;
using System.Collections.Generic;
using TMPro; 

public class DropdownTMPExample : MonoBehaviour
{
    public TMP_Dropdown myDropdown;
    public GameObject cubo;  

    void Start()
    {
        myDropdown.ClearOptions();

        List<string> options = new List<string> { "rosso", "blue", "giallo" };
        myDropdown.AddOptions(options);

        if (myDropdown == null)
            myDropdown = GetComponent<TMP_Dropdown>();

        myDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    void OnDropdownChanged(int index)
    {
        Renderer rend = cubo.GetComponent<Renderer>();

        switch (index)
        {
            case 0:
                rend.material.color = Color.red;
                break;
            case 1:
                rend.material.color = Color.blue;
                break;
            case 2:
                rend.material.color = Color.yellow;
                break;
            default:
                rend.material.color = Color.white;
                break;
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class button : MonoBehaviour
{
    public TextMeshProUGUI mytext;
    public TextMeshProUGUI numero;
    public GameObject finestra;
    public int num = 0;
    void Start()
    {
        finestra.gameObject.SetActive(true);
        mytext.gameObject.SetActive(false);
        numero.text = num.ToString();
    }

    void Update()
    {
        numero.text = num.ToString();
    }
    public void OnClick()
    {
        mytext.gameObject.SetActive(true);
        mytext.text = "Hai Cliccato!";
    }

    public void Aumenta()
    {
        num++;
    }
    public void decremennta()
    {
        num--;
    }

    public void Conferma()
    {
        mytext.gameObject.SetActive(true);
        mytext.text = "Hai Cliccato!";
        finestra.gameObject.SetActive(false);
    }
    
    public void Annulla()
    {
        finestra.gameObject.SetActive(false);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class StudentsMenager : MonoBehaviour {
    public TMP_InputField nome, cognome, eta;
    public TMP_Dropdown classi_dropDown;
    public Button aggiungi;
    public Slider voto_medio;
    public TextMeshProUGUI studentPrefab; 
    public Transform ParentInstance;
    int votomin = 0;
    int votomax = 10;
    int currentvoto = 0;
    // Lista per tenere traccia degli oggetti studenti istanziati
    private List<GameObject> studentiIstanziati = new List<GameObject>();
    // Per sapere quale studente stai editando
    private GameObject studenteSelezionato = null;
    void Start()
    {
        nome.text = "Inserisci Nome";
        cognome.text = "Inserisci Cognome";
        eta.text = "Inserisci eta";
        voto_medio.minValue = votomin;
        voto_medio.maxValue = votomax;
        voto_medio.value = currentvoto;
        List<string> classi = new List<string> { "Seleziona classe", "A1", "A2", "A3", "B1", "B2" };
        classi_dropDown.ClearOptions();
        classi_dropDown.AddOptions(classi);
        //DontDestroyOnLoad(gameObject);
    }

    public void Aggiungi()
    {
        // Istanzia il prefab
        var nuovoStudenteGO = Instantiate(studentPrefab.gameObject, ParentInstance);
    
        var nuovoStudente = nuovoStudenteGO.GetComponent<TextMeshProUGUI>();

        // Imposta il testo
        nuovoStudente.text = "Nome: " + nome.text + "\n" +
                            "Cognome: " + cognome.text + "\n" +
                            "eta: " + eta.text + "\n" +
                            "classe: " + classi_dropDown.options[classi_dropDown.value].text + "\n" +
                            "voto: " + voto_medio.value.ToString();

        // Assegna i bottoni
        Button editBtn = nuovoStudenteGO.GetComponentsInChildren<Button>(true).FirstOrDefault(b => b.gameObject.name == "Editbtn");
        Button delBtn = nuovoStudenteGO.GetComponentsInChildren<Button>(true).FirstOrDefault(b => b.gameObject.name == "Delbtn");

        if (editBtn != null)
            editBtn.onClick.AddListener(() => Edit(nuovoStudenteGO));
        if (delBtn != null)
            delBtn.onClick.AddListener(() => Delete(nuovoStudenteGO));

        studentiIstanziati.Add(nuovoStudenteGO);

        ResetForm();
        Debug.Log("Creato uno");

    }

    // Edita lo studente selezionato
    public void Edit(GameObject studenteGO)
    {
        
        studenteSelezionato = studenteGO;
        var testo = studenteGO.GetComponent<TextMeshProUGUI>().text.Split('\n');
        nome.text = testo[0].Replace("Nome: ", "");
        cognome.text = testo[1].Replace("Cognome: ", "");
        eta.text = testo[2].Replace("eta: ", "");
        classi_dropDown.value = classi_dropDown.options.FindIndex((o) => o.text == testo[3].Replace("classe: ", ""));
        float voto;
        if (float.TryParse(testo[4].Replace("voto: ", ""), out voto))
            voto_medio.value = voto;

        // Cambia la funzione del bottone "aggiungi" in "salva modifica"
        aggiungi.onClick.RemoveAllListeners();
        aggiungi.onClick.AddListener(SalvaModifica);
        
        Debug.Log("Ha modificato");
    }

    // Salva la modifica sullo studente selezionato
    public void SalvaModifica()
    {
        if (studenteSelezionato != null)
        {
            Delete(studenteSelezionato);
            var nuovoTesto = "Nome: " + nome.text + "\n" +
                            "Cognome: " + cognome.text + "\n" +
                            "eta: " + eta.text + "\n" +
                            "classe: " + classi_dropDown.options[classi_dropDown.value].text + "\n" +
                            "voto: " + voto_medio.value.ToString();
            studenteSelezionato.GetComponent<TextMeshProUGUI>().text = nuovoTesto;
            studenteSelezionato = null;

            // Ripristina il bottone aggiungi
            aggiungi.onClick.RemoveAllListeners();
            studentiIstanziati.Remove(studenteSelezionato);
            Debug.Log("Sta salvando la modifica");
        }
        ResetForm();
    }

    // Elimina lo studente selezionato
    public void Delete(GameObject studenteGO)
    {
        studentiIstanziati.Remove(studenteGO);
        Destroy(studenteGO);
        ResetForm();
        Debug.Log("Ha Distrutto l'oggetto selezionato");
    }

    public void DeleteAll()
    {
        foreach (var studente in studentiIstanziati.ToList())
        {
            Destroy(studente);
        }
        studentiIstanziati.Clear();
    }

    public void ResetForm()
    {
        nome.text = "";
        cognome.text = "";
        eta.text = "";
        classi_dropDown.value = 0;
        voto_medio.value = currentvoto;
        Debug.Log("Ha Resettato");
    }
}
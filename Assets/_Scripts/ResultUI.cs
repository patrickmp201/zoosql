using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public GameObject resultPanel;
    
    public List<TextMeshProUGUI> typeTexts;
    public List<TextMeshProUGUI> valueTexts;

    private Dictionary<string, int> results;

    private void Awake()
    {
        results = new Dictionary<string, int>();
    }

    private void Start()
    {
        
    }
    
    public void OpenPanel()
    {
        resultPanel.SetActive(true);
        ShowResults();
    }
    
    public void ClosePanel()
    {
        resultPanel.SetActive(false);
    }
    
    public void OnClickClose()
    {
        ClosePanel();
        SceneManager.LoadScene("Quiz1");
        GameManager2.Instance.Awake();
        GameManager2.Instance.Start();
    }
    
    //Funcion que recorra por todo el enum TipoPregunta y muestre el tipo de pregunta y el valor de la pregunta en el UI
    public void ShowResults()
    {
        // Quiero recorrer la lista questions de GameManager2 y contar cuántas preguntas hay de cada tipo y guardalas en el diccionario results
        
        foreach (var question in GameManager2.Instance.questions)
        {
            if (results.ContainsKey(question.tipoPregunta.ToString()))
            {
                results[question.tipoPregunta.ToString()]++;
            }
            else
            {
                results.Add(question.tipoPregunta.ToString(), 1);
            }
        }
        
        // Mostrar en un log los resultados
        foreach (var result in results)
        {
            Debug.Log($"Tipo de pregunta: {result.Key}, Cantidad: {result.Value}");
        }
        
        // Recorrer el diccionario results y mostrar los resultados en el UI
        int numberOfElements = Enum.GetValues(typeof(TipoPregunta)).Length;
        for (int i = 0; i < numberOfElements; i++)
        {
            typeTexts[i].text = ((TipoPregunta)i).ToString();
            valueTexts[i].text = results.ContainsKey(((TipoPregunta)i).ToString()) ? results[((TipoPregunta)i).ToString()].ToString() : "0";
        }
    }
}

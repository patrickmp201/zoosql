using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    public static QuizUI Instance { private set; get; }
    
    [SerializeField] private Text m_question;
    [SerializeField] private Image m_image;
    [SerializeField] private List<Button> m_buttonList;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void Start()
    {
        Init();
    }
    
    public void Init()
    {
        m_question = GameObject.Find("TextQuestion").GetComponent<Text>();
    }
    
    public void MostrarPregunta(PreguntaSO pregunta)
    {

        m_question.text = pregunta.text_pregunta;
        m_image.sprite = pregunta.spr_pregunta;

        for (int i = 0; i < m_buttonList.Capacity; i++)
        {
            m_buttonList[i].GetComponentInChildren<Text>().text = pregunta.text_alternativas[i].text_alternativa;
        }

    }


}

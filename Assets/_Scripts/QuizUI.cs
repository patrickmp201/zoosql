using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question;
    [SerializeField] private List<Button> m_buttonList;


    public void MostrarPregunta(PreguntaSO pregunta)
    {

        m_question.text = pregunta.text_pregunta;

        for (int i = 0; i < m_buttonList.Capacity; i++)
        {
            m_buttonList[i].GetComponentInChildren<Text>().text = pregunta.text_alternativas[i].text_alternativa;
        }

    }


}

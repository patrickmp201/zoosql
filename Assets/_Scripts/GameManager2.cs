using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.UI;


public class GameManager2 : MonoBehaviour
{
    public int IndexPregunta = 0;
    public List<PreguntaSO> Preguntas;
    [SerializeField] private Sprite m_correctAnswerSprite;
    [SerializeField] private Sprite m_incorrectAnswerSprite;
    [SerializeField] private List<GameObject> m_pointsBar;
    [SerializeField] private List<Button> m_buttons;
    
    [SerializeField] private AudioClip m_correctAnswerSound;
    [SerializeField] private AudioClip m_incorrectAnswerSound;
    
    [SerializeField] private bool[] m_isCorrectAnswer;


    private void Start()
    {
        IniciarJuego();
    }


    public void IniciarJuego()
    {
        Dificultad dificultad = DataManager.Instance.dificultad;
        Tema tema = DataManager.Instance.tema;


        Preguntas = PreguntasManager.Instance.ElegirTema(dificultad, tema);

        // Aquí puedes añadir la lógica para iniciar el juego con la lista de preguntas seleccionadas
        Debug.Log(Preguntas.Count);
        UIManager.Instance.MostrarPregunta(Preguntas[IndexPregunta]);
    }

    public void SiguientePregunta(int indexButton)
    {
        
        if (Preguntas[IndexPregunta].text_alternativas[indexButton].Is_correct)
        {
            m_pointsBar[IndexPregunta].GetComponent<Image>().sprite = m_correctAnswerSprite;
            SoundManager.Instance.PlaySound(m_correctAnswerSound);
        }
        else
        {
            m_pointsBar[IndexPregunta].GetComponent<Image>().sprite = m_incorrectAnswerSprite;
            SoundManager.Instance.PlaySound(m_incorrectAnswerSound);
        }
        
        IndexPregunta = IndexPregunta + 1;
        
        if (IndexPregunta >= Preguntas.Count - 1)
        {
            IndexPregunta = Preguntas.Count - 1;
        }
        
        UIManager.Instance.MostrarPregunta(Preguntas[IndexPregunta]);
    }

    //probando github
}

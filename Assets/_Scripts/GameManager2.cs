using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager2 : MonoBehaviour
{
    public static GameManager2 Instance { private set; get; }
    
    public int IndexPregunta = 0;
    public List<PreguntaSO> Preguntas;
    [SerializeField] private Sprite m_correctAnswerSprite;
    [SerializeField] private Sprite m_incorrectAnswerSprite;
    [SerializeField] private List<GameObject> m_pointsBar;
    [SerializeField] private List<Button> m_buttons;
    
    [SerializeField] private AudioClip m_correctAnswerSound;
    [SerializeField] private AudioClip m_incorrectAnswerSound;
    
    public bool[] m_IsCorrectAnswer { private set; get; }

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


    private void Start()
    {
        IniciarJuego();
        m_IsCorrectAnswer = new bool[10];
    }


    public void IniciarJuego()
    {
        Dificultad dificultad = DataManager.Instance.dificultad;
        Tema tema = DataManager.Instance.tema;


        Preguntas = PreguntasManager.Instance.ElegirTema(dificultad, tema);

        // Aquí puedes añadir la lógica para iniciar el juego con la lista de preguntas seleccionadas
        Debug.Log(Preguntas.Count);
        UIManager.Instance.Start();
        UIManager.Instance.MostrarPregunta(Preguntas[IndexPregunta]);
    }

    public void SiguientePregunta(int indexButton)
    {
        
        if (Preguntas[IndexPregunta].text_alternativas[indexButton].Is_correct)
        {
            m_pointsBar[IndexPregunta].GetComponent<Image>().sprite = m_correctAnswerSprite;
            SoundManager.Instance.PlaySound(m_correctAnswerSound);
            m_IsCorrectAnswer[IndexPregunta] = true;
        }
        else
        {
            m_pointsBar[IndexPregunta].GetComponent<Image>().sprite = m_incorrectAnswerSprite;
            SoundManager.Instance.PlaySound(m_incorrectAnswerSound);
            m_IsCorrectAnswer[IndexPregunta] = false;
        }
        
        IndexPregunta = IndexPregunta + 1;
        
        if (IndexPregunta >= Preguntas.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            IndexPregunta = 0;
        }
        
        UIManager.Instance.MostrarPregunta(Preguntas[IndexPregunta]);
    }

    //probando github
}

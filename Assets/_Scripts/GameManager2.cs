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
    [SerializeField] private List<ListPreguntasSO> bdQuestionsAlgebra;
    [SerializeField] private List<ListPreguntasSO> bdQuestionsPlSQL;
    public List<PreguntaSO> questions;
    
    [SerializeField] private Tema m_tema;
    [SerializeField] private Dificultad m_dificultad;
    
    [SerializeField] private Sprite m_correctAnswerSprite;
    [SerializeField] private Sprite m_incorrectAnswerSprite;
    [SerializeField] private List<GameObject> m_pointsBar;
    
    [SerializeField] private AudioClip m_correctAnswerSound;
    [SerializeField] private AudioClip m_incorrectAnswerSound;
    
    [SerializeField] private QuizUI m_QuizUI;
    
    public bool[] m_IsCorrectAnswer { private set; get; }

    public void Awake()
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

        m_QuizUI = FindObjectOfType<QuizUI>();
    }


    public void Start()
    {
        IniciarJuego();
        m_IsCorrectAnswer = new bool[10];
    }


    public void IniciarJuego()
    {
        questions = new List<PreguntaSO>();
        questions = GetQuestions(DataManager.Instance.Dificultad, DataManager.Instance.Tema);

        // Aquí puedes añadir la lógica para iniciar el juego con la lista de preguntas seleccionadas
        m_QuizUI.Start();
        m_QuizUI.MostrarPregunta(questions[IndexPregunta]);
    }

    public void SiguientePregunta(int indexButton)
    {
        
        if (questions[IndexPregunta].text_alternativas[indexButton].Is_correct)
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
        
        IndexPregunta++;
        
        if (IndexPregunta >= questions.Count)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            IndexPregunta = 0;
        }
        
        m_QuizUI.MostrarPregunta(questions[IndexPregunta]);
    }
    
    private List<PreguntaSO> GetQuestions(Dificultad dificultad, Tema tema)
    {
        List<ListPreguntasSO> bdQuestions = new List<ListPreguntasSO>();
        List<PreguntaSO> questionsByDifficulty = new List<PreguntaSO>();
        List<PreguntaSO> randomQuestions = new List<PreguntaSO>();
        
        bdQuestions = tema == Tema.Algebra ? bdQuestionsAlgebra : bdQuestionsPlSQL;
        
        foreach (ListPreguntasSO listPreguntas in bdQuestions)
        {
            foreach (PreguntaSO pregunta in listPreguntas.BancoPreguntas)
            {
                if (pregunta.dificultad == dificultad)
                {
                    questionsByDifficulty.Add(pregunta);
                }
            }
        }
        
        while (questionsByDifficulty.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, questionsByDifficulty.Count);
            randomQuestions.Add(questionsByDifficulty[randomIndex]);
            questionsByDifficulty.RemoveAt(randomIndex);
        }
        
        return randomQuestions;
    }

    //probando github
}

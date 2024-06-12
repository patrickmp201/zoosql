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

    public List<(Tema, Dificultad)> difficultyLevel;
    public int currentLevel;
    
    public bool isGameOver = false;
    
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
        isGameOver = false;

        difficultyLevel = new List<(Tema, Dificultad)>
        {
            (Tema.Algebra, Dificultad.Facil),
            (Tema.Algebra, Dificultad.Intermedio),
            (Tema.Algebra, Dificultad.Dificil),
            (Tema.Plsql, Dificultad.Facil),
            (Tema.Plsql, Dificultad.Intermedio),
            (Tema.Plsql, Dificultad.Dificil)
        };
        
        SetCurrentLevel();
    }


    public void IniciarJuego()
    {
        questions = new List<PreguntaSO>();
        
        Debug.LogError("Dificultad: " + DataManager.Instance.Dificultad + " Tema: " + DataManager.Instance.Tema);
        questions = GetQuestions(DataManager.Instance.Dificultad, DataManager.Instance.Tema);

        // Aqu� puedes a�adir la l�gica para iniciar el juego con la lista de preguntas seleccionadas
        if (m_QuizUI != null)
        {
            m_QuizUI.Start();
            m_QuizUI.MostrarPregunta(questions[IndexPregunta]);
        }
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
        
        if (IndexPregunta >= 10)
        {
            SceneManager.LoadScene("RouletteScene");
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
                if (listPreguntas.dificultad == dificultad)
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
        
        var randomQuestionsCopy = new List<PreguntaSO>(randomQuestions);
        randomQuestions.Clear();
        
        for (int i = 0; i < 10; i++)
        {
            randomQuestions.Add(randomQuestionsCopy[i]);
        }
        
        return randomQuestions;
    }

    private void SetCurrentLevel()
    {
        // Hacer una busqueda dentro de la lista de difficultyLevel para encontrar el nivel actual, comparando con el DataManager.Instance.Tema y DataManager.Instance.Dificultad y luego asignar el valor a currentLevel con el �ndice encontrado
        
        for (int i = 0; i < difficultyLevel.Count; i++)
        {
            if (difficultyLevel[i].Item1 == DataManager.Instance.Tema && difficultyLevel[i].Item2 == DataManager.Instance.Dificultad)
            {
                currentLevel = i;
            }
        }
    }

    //probando github
}

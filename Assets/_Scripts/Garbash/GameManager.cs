

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//[RequireComponent(typeof(AudioSource))]
//public class GameManager : MonoBehaviour
//{

//    [SerializeField] private AudioClip m_correctSound = null;
//    [SerializeField] private AudioClip m_incorrectSound = null;
//    [SerializeField] private Color m_correctColor = Color.black;
//    [SerializeField] private Color m_incorrectColor = Color.black;
//    [SerializeField] private float m_waitTime = 0.0f;

//    private QuizDB m_quizDB = null;
//    private QuizUI m_quizUI = null;
//    private AudioSource m_audioSource = null;

//    private int questionCount = 0; // Contador para el n�mero de preguntas
//    private const int maxQuestions = 9; // L�mite de preguntas

//    private void Start()
//    {
//        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
//        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
//        m_audioSource = GetComponent<AudioSource>();

//        NextQuestion();
//    }

//    private void NextQuestion()
//    {
//        m_quizUI.Construct(m_quizDB.GetRandom(), GiveAnswer);
//    }


//    private void GiveAnswer(OptionButton optionButton)
//    {
//        StartCoroutine(GiveAnswerRoutine(optionButton));
//    }

//    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
//    {
//        if (m_audioSource.isPlaying)
//            m_audioSource.Stop();

//        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
//        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

//        m_audioSource.Play();

//        yield return new WaitForSeconds(m_waitTime);

//        // Solo llama a NextQuestion si el contador es menor que el l�mite
//        if (questionCount < maxQuestions)
//        {
//            questionCount++;
//            NextQuestion();
//        }
//        else
//        {
//            // Aqu� puedes manejar el caso cuando se alcanza el l�mite de preguntas.
//            // Por ejemplo, podr�as llamar a una funci�n de fin de juego o mostrar un mensaje.
//            SceneManager.LoadScene(1);
//        }
//    }

//    //private void GameOver()
//    //{
//    //    //logica de game over
//    //    SceneManager.LoadScene(0);

//    //}


//}

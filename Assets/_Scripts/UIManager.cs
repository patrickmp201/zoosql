using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //set privado get publico
    public static UIManager Instance { private set; get; }


    public QuizUI QuizUI
    {
        get
        {
            if (quizUI != null)
            {
                Debug.Log("entro al if");
                return quizUI;

            }
            else
            {

                Debug.Log("entro al else");
                quizUI = GameObject.Find("QuizUI").GetComponent<QuizUI>();
                Debug.Log(quizUI);
                return quizUI;
            }
        }
    }
    private QuizUI quizUI;



    //Se llama cuando un objeto es cargado en memoria, se ejecuta cuando esta cargando el juego
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("ya existe");
            Destroy(this);

        }

    }

    public void MostrarPregunta(PreguntaSO pregunta)
    {

        QuizUI.MostrarPregunta(pregunta);
    }



}

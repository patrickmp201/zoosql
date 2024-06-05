using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //set privado get publico
    public static UIManager Instance { private set; get; }


    public QuizUI QuizUI;



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
            Destroy(gameObject);

        }

    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        QuizUI = QuizUI.Instance;
    }

    public void MostrarPregunta(PreguntaSO pregunta)
    {
        QuizUI.Init();
        QuizUI.MostrarPregunta(pregunta);
    }



}

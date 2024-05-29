using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //set privado get publico
    public static DataManager Instance { private set; get; }
    public Dificultad dificultad;
    public Tema tema;


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

    public void SetDificultad(Dificultad dificultad)
    {
        this.dificultad = dificultad;

    }

    public void SetTema(Tema tema)
    {

        this.tema = tema;
    }



}

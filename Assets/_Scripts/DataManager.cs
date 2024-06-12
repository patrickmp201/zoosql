using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //set privado get publico
    public static DataManager Instance { private set; get; }
    [field: SerializeField]
    public Dificultad Dificultad { get; set; }
    [field: SerializeField]
    public Tema Tema { get; set; }
    
    


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



}

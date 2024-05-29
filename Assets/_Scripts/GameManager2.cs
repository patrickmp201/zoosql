using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager2 : MonoBehaviour
{
    public int IndexPregunta = 0;
    public List<PreguntaSO> Preguntas;


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

        IndexPregunta = IndexPregunta + 1;
    }

    public void SiguientePregunta()
    {
        UIManager.Instance.MostrarPregunta(Preguntas[IndexPregunta]);
        IndexPregunta = IndexPregunta + 1;
    }


}

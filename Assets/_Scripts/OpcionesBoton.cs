using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesBoton : MonoBehaviour
{
    // Start is called before the first frame update
    public Dificultad EleccionDificultad;
    public Tema tema;

    void Start()
    {
    }

    public void SetDificultad()
    {
        DataManager.Instance.Dificultad = EleccionDificultad;
    }

    public void SetTema()
    {
        DataManager.Instance.Tema = tema;
    }
}

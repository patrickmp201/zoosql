using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambiarScena : MonoBehaviour
{
    public bool pasarEscenas;
    public int indiceEscenas;


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 representa el bot�n derecho del mouse
        {
            CambiarNivel(indiceEscenas);
            Debug.Log("Cambiando a la escena con �ndice: " + indiceEscenas);
        }

        if (pasarEscenas)
        {
            CambiarNivel(indiceEscenas);
            Debug.Log("Cambiando a la escena con �ndice: " + indiceEscenas);
            pasarEscenas = false; // Resetear para evitar m�ltiples cambios
        }
    }

    public void CambiarNivel(int indice)
    {
        if (indice >= 0 && indice < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indice);
        }
        else
        {
            Debug.LogError("�ndice de escena fuera de rango: " + indice);
        }
    }
}



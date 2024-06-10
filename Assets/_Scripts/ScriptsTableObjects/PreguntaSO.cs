using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NuevaPregunta", menuName = "Pregunta")]
public class PreguntaSO : ScriptableObject
{
    public string text_pregunta;
    public Sprite spr_pregunta;
    public Alternativa[] text_alternativas;
    public Dificultad dificultad;
    public Tema tema;
    public TipoPregunta tipoPregunta;
}
// El enum es un indice
public enum Dificultad{

    Facil, Intermedio, Dificil

}

[Serializable]
public  struct Alternativa {


    public string text_alternativa;
    public bool Is_correct;    

}

public enum Tema {

    Plsql, Algebra
}

public enum TipoPregunta
{

    introduccion,condiconales, estructuras_control, excepiones,cursores,procedimientos,triggers,
    
    seleccion,proyeccion,seleccion_condicion,proyeccion_condicion,union,diferencia, interseccion, join_natural,union_codicion
}



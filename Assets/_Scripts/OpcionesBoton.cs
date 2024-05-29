using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcionesBoton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public Text text;
    public Dificultad EleccionDificultad;
    public bool IsTema;
    public Tema tema;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (IsTema)
            {
                Tema();
            }
            else
            {
                SetDificultad();
            }
        });

        text = GetComponentInChildren<Text>();
    }

    public void SetDificultad()
    {
        DataManager.Instance.SetDificultad(EleccionDificultad);

        if (EleccionDificultad == Dificultad.facil)
        {
            SceneLoadManager.Instance.ChangeScene("Scene1");
        }
        else if (EleccionDificultad == Dificultad.intermedio)
        {
            SceneLoadManager.Instance.ChangeScene("Scene1");
        }
        else if (EleccionDificultad == Dificultad.dificil)
        {
            SceneLoadManager.Instance.ChangeScene("Scene1");
        }
    }

    public void Tema()
    {
        DataManager.Instance.SetTema(tema);
    }
}

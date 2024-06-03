using System;
using UnityEngine;

namespace _Scripts
{
    public class RouletteTop : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Icon"))
            {
                Debug.Log(other.gameObject.name + " ha colisionado con el top de la ruleta");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Icon"))
            {
                Debug.Log(other.gameObject.name + " ha triggereado con el top de la ruleta");
            }
        }
    }
}

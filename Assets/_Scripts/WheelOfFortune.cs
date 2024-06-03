using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    public class WheelOfFortune : MonoBehaviour
    {
        public Sprite correctAnswerSprite;
        public Sprite incorrectAnswerSprite;
        public GameObject[] wheelSegments; // Asume que hay 10 segmentos en la ruleta

        private void Start()
        {
            // Asigna los sprites a los segmentos de la ruleta
            for (int i = 0; i < wheelSegments.Length; i++)
            {
                var image = wheelSegments[i].GetComponent<Image>();
                image.sprite = i < 5 ? correctAnswerSprite : incorrectAnswerSprite;
            }
        }

        public void SpinWheel()
        {
            // Inicia la corutina para girar la ruleta
            StartCoroutine(SpinWheelCoroutine());
        }

        private IEnumerator SpinWheelCoroutine()
        {
            // Gira la ruleta durante un tiempo aleatorio
            float spinTime = Random.Range(2f, 5f);
            float timer = 0f;

            while (timer < spinTime)
            {
                transform.Rotate(0f, 0f, -360f * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }

            // Selecciona el segmento de la ruleta que está en la posición superior
            int selectedSegmentIndex = Mathf.FloorToInt(transform.rotation.eulerAngles.z / 36f);
            HandleWheelResult(selectedSegmentIndex);
        }

        private void HandleWheelResult(int selectedSegmentIndex)
        {
            // Si el segmento seleccionado tiene el sprite de respuesta correcta, avanza al siguiente nivel
            var image = wheelSegments[selectedSegmentIndex].GetComponent<Image>();
            if (image.sprite == correctAnswerSprite)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}

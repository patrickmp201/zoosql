using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace _Scripts
{
    public class WheelOfFortune : MonoBehaviour
    {
        public Sprite correctAnswerSprite;
        public Sprite incorrectAnswerSprite;
        
        [SerializeField] private GameObject m_iconPrefab;
        public int numberOfIcons = 10;
        private readonly List<GameObject> icons = new ();
        private float radiusWheel;
        public float rotationSpeed = 100f;
        private bool isSpinning = false;
        private bool isOnSegment = false;
        private int currentSegment = 0;

        public RectTransform topRouletteRectTransform;
        
        Sequence sequence;
        
        // public GameObject[] wheelSegments; // Asume que hay 10 segmentos en la ruleta

        private void Awake()
        {
            sequence = DOTween.Sequence();
        }

        private void Start()
        {
            InitializeWheel();
            AnimateIconsToEdges();
            sequence.Play();
        }

        private void Update()
        {
            if (isSpinning)
            {
                transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
                if (!isOnSegment)
                {
                    currentSegment = SelectSegment();
                }

                if (currentSegment != SelectSegment())
                {
                    isOnSegment = false;
                }
            }
            // GameObject topObject = GetTopGameObject();
            // topObject.transform.DOScale(Vector3.one * 1.2f, 0.1f);
        }

        private void InitializeWheel()
        {
            for (int i = 0; i < numberOfIcons; i++)
            {
                GameObject icon = Instantiate(m_iconPrefab, transform.position, Quaternion.identity, transform);
                
                var randomSprite = UnityEngine.Random.Range(0, 2) == 0 ? correctAnswerSprite : incorrectAnswerSprite;
                icon.GetComponent<Image>().sprite = randomSprite;
                
                // agregar el gameobject icon como hijo del gameobject que tiene este script
                icon.transform.SetParent(transform);
                icons.Add(icon);
            }
            radiusWheel = transform.gameObject.GetComponent<RectTransform>().rect.width / 2;
        }
        
        private void AnimateIconsToEdges()
        {
            for (int i = 0; i < icons.Count; i++)
            {
                float angle = i * 360f / numberOfIcons;
                Vector3 endPos = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0f) * radiusWheel; // 0.5f is the radius of the wheel
                sequence.Append(icons[i].transform.DOLocalMove(endPos, 0.3f).SetEase(Ease.OutBack));
            }
        }

        public void SpinWheel()
        {
            if (isSpinning)
            {
                // Si la ruleta ya está girando, detén la rotación y selecciona un segmento.
                isSpinning = false;
            }
            else
            {
                // Si la ruleta no está girando, inicia la rotación.
                isSpinning = true;
                StartCoroutine(SlowDownRotation());
            }
        }
        
        IEnumerator SlowDownRotation()
        {
            while (rotationSpeed > 0)
            {
                rotationSpeed -= Time.deltaTime * 10;  // Ajusta este valor para controlar la rapidez con la que se desacelera la ruleta.
                yield return null;
            }
            rotationSpeed = 0;
            isSpinning = false;
            // SelectSegment();
        }
        
        private GameObject GetTopGameObject()
        {
            GameObject topObject = null;

            foreach (var icon in icons)
            {
                var iconRectTransform = icon.GetComponent<RectTransform>().rect;

                if (iconRectTransform.Overlaps(topRouletteRectTransform.rect))
                {
                    Debug.Log("Top object overlap found!");
                    topObject = icon;
                }
            }
            
            return topObject;
        }
        
        private int SelectSegment()
        {
            int numberOfSegments = icons.Count;
            float segmentRotation = 360f / numberOfSegments;
            int selectedSegment = Mathf.FloorToInt(transform.eulerAngles.z / segmentRotation);
            Debug.Log("selectedSegment: " + icons[selectedSegment].name);
            icons[selectedSegment].transform.DOScale(Vector3.one * 1.2f, 0.1f);
            Debug.Log(selectedSegment);
            isOnSegment = true;

            if (selectedSegment >= 1)
            {
                icons[selectedSegment - 1].transform.DOScale(Vector3.one, 0.1f);
            }

            return selectedSegment;
            // HandleWheelResult(selectedSegment);
        }

        // private void HandleWheelResult(int selectedSegmentIndex)
        // {
        //     // Si el segmento seleccionado tiene el sprite de respuesta correcta, avanza al siguiente nivel
        //     var image = wheelSegments[selectedSegmentIndex].GetComponent<Image>();
        //     if (image.sprite == correctAnswerSprite)
        //     {
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //     }
        // }
    }
}

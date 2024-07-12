using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public AudioClip soundClip;
    private AudioSource audioSource;
    private GameObject player;
    public float maxDistance = 10.0f; // Distancia máxima a la cual se escucha el sonido
    public float minVolume = 0.1f; // Volumen mínimo cuando el jugador está dentro del rango
    public CameraController cameraController;
    public Vector3 pointToMoveCamera;
    public float moveDuration = 3f; // Duración en segundos





    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        // Encontrar al jugador por layer
        int playerLayer = LayerMask.NameToLayer("Layer1");
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == playerLayer)
            {
                player = obj;
                break;
            }
        }

        // Configurar el AudioSource
        audioSource.clip = soundClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= maxDistance)
            {
                // Usar una caída de volumen ajustada para que comience más bajo
                float volume = Mathf.Clamp01(1.0f - (distance / maxDistance));
                audioSource.volume = Mathf.Lerp(minVolume, 1.0f, volume);
            }
            else
            {
                // Si está fuera del rango máximo, el volumen es 0
                audioSource.volume = 0;
            }
        }
    }

    //para la moneda invisible
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el jugador interactúa con la moneda
        if (collision.gameObject.layer == LayerMask.NameToLayer("Layer1"))
        {

            if (spriteRenderer.enabled)
            {
                // Mover la cámara al punto especificado
                cameraController.MoveCameraToPoint();
                // La moneda está visible, destruirla e incrementar el marcador
                GameManager.Instance.IncrementScore(1);
                Destroy(gameObject);
                // Mover la cámara al punto especificado
               
            }
            else
            {
               
                // La moneda está invisible, hacerla visible
                spriteRenderer.enabled = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public AudioClip soundClip;
    private AudioSource audioSource;
    private GameObject player;
    public float maxDistance = 10.0f; // Distancia m�xima a la cual se escucha el sonido
    public float minVolume = 0.1f; // Volumen m�nimo cuando el jugador est� dentro del rango
    public CameraController cameraController;
    public Vector3 pointToMoveCamera;
    public float moveDuration = 3f; // Duraci�n en segundos





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
                // Usar una ca�da de volumen ajustada para que comience m�s bajo
                float volume = Mathf.Clamp01(1.0f - (distance / maxDistance));
                audioSource.volume = Mathf.Lerp(minVolume, 1.0f, volume);
            }
            else
            {
                // Si est� fuera del rango m�ximo, el volumen es 0
                audioSource.volume = 0;
            }
        }
    }

    //para la moneda invisible
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el jugador interact�a con la moneda
        if (collision.gameObject.layer == LayerMask.NameToLayer("Layer1"))
        {

            if (spriteRenderer.enabled)
            {
                // Mover la c�mara al punto especificado
                cameraController.MoveCameraToPoint();
                // La moneda est� visible, destruirla e incrementar el marcador
                GameManager.Instance.IncrementScore(1);
                Destroy(gameObject);
                // Mover la c�mara al punto especificado
               
            }
            else
            {
               
                // La moneda est� invisible, hacerla visible
                spriteRenderer.enabled = true;
            }
        }
    }
}

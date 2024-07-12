using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //para la moneda invisible
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si el jugador interactúa con la moneda
        if (collision.gameObject.layer == LayerMask.NameToLayer("Layer1"))
        {

            if (spriteRenderer.enabled)
            {
                // La moneda está visible, destruirla e incrementar el marcador
                GameManager.Instance.IncrementScore(1);
                Destroy(gameObject);
            }
            else
            {
                // La moneda está invisible, hacerla visible
                spriteRenderer.enabled = true;
            }
        }
    }
}

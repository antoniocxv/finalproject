using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D jugadorRB;

    [SerializeField] private float parallaxEffectMultiplier; // Factor de parallax
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

       

    }
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = (jugadorRB.velocity.x *0.1f) *velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier);
        lastCameraPosition = cameraTransform.position;
    }
}

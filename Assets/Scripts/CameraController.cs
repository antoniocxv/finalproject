using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vcamPlayer;
    public CinemachineVirtualCamera vcamGem;
    public float duration = 3f; // Duraci�n de la transici�n
    public MovableObject movableObject;

    private void Start()
    {
        // Asegurarse de que la c�mara del jugador tenga la mayor prioridad al inicio
        vcamPlayer.Priority = 10;
        vcamGem.Priority = 5;
    }

    public void MoveCameraToPoint()
    {
        // Cambiar la prioridad para que la c�mara apunte a la gema
        vcamGem.Priority = 15;
        vcamPlayer.Priority = 5;
        StartCoroutine(ReturnToPlayerAfterDelay());
    }

    private IEnumerator ReturnToPlayerAfterDelay()
    {
        yield return new WaitForSeconds(1);
        // Iniciar el movimiento del GameObject
        if (movableObject != null)
        {
            movableObject.StartMoving();
        }
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(duration);
       
        // Volver a la c�mara del jugador
        vcamPlayer.Priority = 10;
        vcamGem.Priority = 5;
    }
}

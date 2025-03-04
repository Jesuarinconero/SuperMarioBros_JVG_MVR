using UnityEngine;

// Declaraci�n de la clase SideScrolling que requiere un componente Camera.
[RequireComponent(typeof(Camera))]
public class SideScrolling : MonoBehaviour
{
    // Referencias al componente Camera y al objeto del jugador.
    private new Camera camera;
    private Transform player;

    // Altura predeterminada y subterr�nea del seguimiento de la c�mara.
    public float height = 6.5f;
    public float undergroundHeight = -9.5f;

    // Umbral para determinar si el jugador est� bajo tierra.
    public float undergroundThreshold = 0f;

    // Se ejecuta al despertar el componente.
    private void Awake()
    {
        // Obtiene referencias a componentes necesarios.
        camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Se ejecuta en cada frame despu�s de que se hayan realizado todas las actualizaciones.
    private void LateUpdate()
    {
        // Rastrea al jugador movi�ndose hacia la derecha.
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }

    // Funci�n para establecer la altura subterr�nea de la c�mara.
    public void SetUnderground(bool underground)
    {
        // Establece la posici�n Y de la c�mara seg�n si el jugador est� bajo tierra o no.
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = underground ? undergroundHeight : height;
        transform.position = cameraPosition;
    }
}

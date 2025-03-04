using UnityEngine;

// Declaración de la clase SideScrolling que requiere un componente Camera.
[RequireComponent(typeof(Camera))]
public class SideScrolling : MonoBehaviour
{
    // Referencias al componente Camera y al objeto del jugador.
    private new Camera camera;
    private Transform player;

    // Altura predeterminada y subterránea del seguimiento de la cámara.
    public float height = 6.5f;
    public float undergroundHeight = -9.5f;

    // Umbral para determinar si el jugador está bajo tierra.
    public float undergroundThreshold = 0f;

    // Se ejecuta al despertar el componente.
    private void Awake()
    {
        // Obtiene referencias a componentes necesarios.
        camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Se ejecuta en cada frame después de que se hayan realizado todas las actualizaciones.
    private void LateUpdate()
    {
        // Rastrea al jugador moviéndose hacia la derecha.
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }

    // Función para establecer la altura subterránea de la cámara.
    public void SetUnderground(bool underground)
    {
        // Establece la posición Y de la cámara según si el jugador está bajo tierra o no.
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = underground ? undergroundHeight : height;
        transform.position = cameraPosition;
    }
}

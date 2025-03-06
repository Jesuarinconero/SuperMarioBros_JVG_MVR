using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Offset para posicionar la c�mara
    public Camera camera; // Para acceder a la c�mara y ajustar el FOV si es necesario

    private void Start()
    {
        // Inicializa el offset, de ser necesario
        offset = transform.position - target.position;
    }

    void Update()
    {
        // Actualiza la posici�n de la c�mara, siguiendo suavemente al objetivo (Mario)
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);

        // Si Mario cambia de tama�o, ajustamos el FOV de la c�mara
        if (camera != null)
        {
            float scale = target.localScale.x; // Puedes usar cualquier componente de la escala que quieras (x, y)
            camera.orthographicSize = Mathf.Lerp(5, 7, scale); // Ajusta el FOV seg�n el tama�o de Mario (ajusta estos valores seg�n sea necesario)
        }
    }
}

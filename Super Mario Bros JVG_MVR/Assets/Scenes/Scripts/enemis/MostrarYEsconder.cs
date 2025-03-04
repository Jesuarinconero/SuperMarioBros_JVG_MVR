using UnityEngine;

public class MostrarYEsconder : MonoBehaviour
{
    public GameObject objetomovimiento;
    public Transform showPoint;
    public Transform hidePoint;

    public float waitforShow = 2f; // Tiempo de espera antes de aparecer
    public float waitforHide = 2f; // Tiempo de espera antes de esconderse

    public float speedshow = 2f; // Velocidad al aparecer
    public float speedhide = 2f; // Velocidad al esconderse

    private Vector3 targetPoint; // 🔥 Cambiado a Vector3
    private bool isMoving = false; // Controla si está en movimiento

    void Start()
    {
        if (showPoint == null || hidePoint == null)
        {
            Debug.LogError("❌ ERROR: showPoint o hidePoint no están asignados en el Inspector.");
            return;
        }

        objetomovimiento.transform.position = hidePoint.position; // Inicia oculta
        targetPoint = hidePoint.position;
        Invoke("Show", waitforShow); // Espera y aparece
    }

    void Update()
    {
        if (isMoving)
        {
            objetomovimiento.transform.position = Vector3.MoveTowards(objetomovimiento.transform.position, targetPoint, speedshow * Time.deltaTime);

            // Si llegó a la posición objetivo, detenerse
            if (Vector3.Distance(objetomovimiento.transform.position, targetPoint) < 0.1f)
            {
                isMoving = false;
                if (targetPoint == showPoint.position) // 🔥 Corrección aquí
                {
                    Invoke("Hide", waitforHide); // Espera y se esconde
                }
                else
                {
                    Invoke("Show", waitforShow); // Espera y aparece
                }
            }
        }
    }

    void Show()
    {
        targetPoint = showPoint.position;
        isMoving = true;
    }

    void Hide()
    {
        targetPoint = hidePoint.position;
        isMoving = true;
    }

    private void OnDrawGizmos()
    {
        if (showPoint == null || hidePoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(showPoint.position, Vector3.one); // 🔥 Cambiado a Vector3
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(hidePoint.position, Vector3.one); // 🔥 Cambiado a Vector3
    }
}

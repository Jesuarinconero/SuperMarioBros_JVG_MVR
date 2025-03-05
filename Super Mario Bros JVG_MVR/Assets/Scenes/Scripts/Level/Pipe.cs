using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform connection;
    public KeyCode enterKeyCode = KeyCode.S;
    public Vector3 enterDirection = Vector3.down;
    public Vector3 exitDirection = Vector3.zero;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (connection != null && other.CompareTag("Player"))
        {
            if (Input.GetKey(enterKeyCode))
            {
                StartCoroutine(Enter(other.GetComponent<Mario>()));
            }
        }
    }

    private IEnumerator Enter(Mario mario)
    {
        // Desactivar movimiento y colisiones
        mario.GetComponent<Mover>().enabled = false;
        mario.GetComponent<Colisiones>().enabled = false;
        mario.rb2d.linearVelocity = Vector2.zero;

        // Animaci�n de entrada
        Vector3 enteredPosition = transform.position + enterDirection;
        Vector3 enteredScale = Vector3.one * 0.5f;
        yield return Move(mario.transform, enteredPosition, enteredScale);
        yield return new WaitForSeconds(1f);

        // Ajuste de la c�mara si hay SideScrolling
        var sideScrolling = Camera.main.GetComponent<SideScrolling>();
        sideScrolling.SetUnderground(connection.position.y < sideScrolling.undergroundThreshold);

        // Teletransportaci�n con direcci�n de salida
        if (exitDirection != Vector3.zero)
        {
            mario.transform.position = connection.position - exitDirection;
            yield return Move(mario.transform, connection.position + exitDirection, Vector3.one);
        }
        else
        {
            mario.transform.position = connection.position;
            mario.transform.localScale = Vector3.one;
        }

        // Reactivar movimiento y colisiones
        mario.GetComponent<Mover>().enabled = true;
        mario.GetComponent<Colisiones>().enabled = true;
    }

    private IEnumerator Move(Transform player, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;
        Vector3 startPosition = player.position;
        Vector3 startScale = player.localScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            player.position = Vector3.Lerp(startPosition, endPosition, t);
            player.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.position = endPosition;
        player.localScale = endScale;
    }
}

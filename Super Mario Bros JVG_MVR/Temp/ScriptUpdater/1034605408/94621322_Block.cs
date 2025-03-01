using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private bool bouncing;
    public GameObject brickPiecePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CabezaMario"))
        {
            Debug.Log("Cabezazo de Mario");
            //Bounce();
            Break();
        }
    }

    private void Bounce()
    {
        if (!bouncing)
        {
            StartCoroutine(BounceAnimation());
        }
    }

    private IEnumerator BounceAnimation()
    {
        bouncing = true;
        float time = 0;
        float duration = 0.1f;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + Vector2.up * 0.25f;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        time = 0;

        while (time < duration)
        {
            transform.position = Vector2.Lerp(targetPosition, startPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        bouncing = false;
    }

    private void Break()
    {
        Vector2[] velocities =
        {
            new Vector2( 3f,  12f),
            new Vector2(-3f,  12f),
            new Vector2( 3f,  -8f),
            new Vector2(-3f,  -8f)
        };

        float[] rotations = { 0, 90, -90, 180 };

        for (int i = 0; i < velocities.Length; i++)
        {
            GameObject brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(0, 0, rotations[i]));
            brickPiece.GetComponent<Rigidbody2D>().linearVelocity = velocities[i];
        }

        Destroy(gameObject);
    }
}

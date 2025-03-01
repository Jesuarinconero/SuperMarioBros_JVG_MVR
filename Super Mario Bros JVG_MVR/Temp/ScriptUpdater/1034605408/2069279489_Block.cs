using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{

    bool bouncing;
    public GameObject brickPiecePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CabezaMario"))
        {
            Debug.Log("Cabesaso de Mario");
            //Bounce();
            Break();
        }
    }
    void Bounce()
    {
        if (!bouncing)
        {
            StartCoroutine(BounceAnimation());
        }
    }
    IEnumerator BounceAnimation()
    {
        bouncing = true;
        float time = 0;
        float duration = 0.1f;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = (Vector2)transform.position + Vector2.up * 0.25f;

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
    void Break()
    {
        GameObject brickPiece;
        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
        brickPiece.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3f, 12f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        brickPiece.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3f, 12f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
        brickPiece.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(3f, -8f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
        brickPiece.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-3f, -8f);
        Destroy(gameObject);
    }
}
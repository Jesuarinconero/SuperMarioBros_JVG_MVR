using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;

public class Block : MonoBehaviour
{
    bool bouncing;
    public GameObject brickPiecePrefab;
    public GameObject itemPrefab;
    public Sprite emptyBlockSprite; // Sprite cuando el bloque está vacío
    private bool isEmpty = false; // Estado del bloque
    private SpriteRenderer spriteRenderer;

    private SpritesAnimation spritesAnimationScript;  // Referencia a la animación de sprites
    Mario mario;
   
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Referencia al SpriteRenderer
        spritesAnimationScript = GetComponent<SpritesAnimation>(); // Referencia al script de animación
        mario = GetComponent<Mario>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No hay SpriteRenderer en " + gameObject.name);
        }

        if (spritesAnimationScript == null)
        {
            // Si no se encuentra el componente SpritesAnimation, intentar buscarlo en el objeto padre o asignarlo manualmente
            Debug.LogWarning("No se encontró el script de animación SpritesAnimation en " + gameObject.name + ". Intentando asignar desde otro objeto.");

            // Intentar obtener el componente SpritesAnimation en un GameObject específico (si es necesario)
            // Ejemplo: spritesAnimationScript = GameObject.Find("OtroObjetoConAnimacion").GetComponent<SpritesAnimation>();

            // O asignar el script manualmente si lo tienes en el Inspector
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CabezaMario"))
        {
            Debug.Log("¡Cabezazo de Mario!");
            if (!isEmpty)
            {
                Break();
            }
            else
            {
                Bounce();
            }
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
        AudioManager.Instance.PlayBump();
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
        if (itemPrefab != null)
        {
            
            StartCoroutine(ShowItem());
        }
        else
        {
            // Si no hay itemPrefab, el bloque se destruye normal
            AudioManager.Instance.PlayBreak();

                DestroyBlock();
            
         
        }
    }

    IEnumerator ShowItem()
    {
        AudioManager.Instance.PlayPowerAppear();
        GameObject nuevoItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        movimientoWoomba automovimiento = nuevoItem.GetComponent<movimientoWoomba>();
        if (automovimiento != null)
        {
            automovimiento.enabled = false;
        }

        float time = 0;
        float duracion = 1f;
        Vector2 startPosition = nuevoItem.transform.position;
        Vector2 targetPosition = (Vector2)transform.position + Vector2.up * 0.5f;

        while (time < duracion)
        {
            nuevoItem.transform.position = Vector2.Lerp(startPosition, targetPosition, time / duracion);
            time += Time.deltaTime;
            yield return null;
        }

        nuevoItem.transform.position = targetPosition;
        if (automovimiento != null)
        {
            automovimiento.enabled = true;
        }

        // Aquí cambiamos el sprite cuando el item ya salió
        isEmpty = true;
        spriteRenderer.sprite = emptyBlockSprite;

        // Detenemos la animación
        spritesAnimationScript.StopAnimation();
    }

    void DestroyBlock()
    {
        ScoreManager.Instance.SumarPuntos(50);
        GameObject brickPiece;
        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.identity);
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

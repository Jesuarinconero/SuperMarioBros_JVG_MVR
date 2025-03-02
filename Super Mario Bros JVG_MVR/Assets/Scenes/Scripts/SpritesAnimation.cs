using UnityEngine;
using System.Collections;

public class SpritesAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameTime = 0.1f;

    private int animationFrame = 0;
    private SpriteRenderer spriteRenderer;
    public bool loop = true;

    public bool isAnimating = true;  // Controla si la animaci�n sigue funcionando

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        if (loop)
        {
            while (isAnimating) // Solo ejecuta la animaci�n si isAnimating es true
            {
                spriteRenderer.sprite = sprites[animationFrame];
                animationFrame++;

                if (animationFrame >= sprites.Length)
                {
                    animationFrame = 0;
                }

                yield return new WaitForSeconds(frameTime);
            }
        }
        else
        {
            while (animationFrame < sprites.Length)
            {
                spriteRenderer.sprite = sprites[animationFrame];
                animationFrame++;
                yield return new WaitForSeconds(frameTime);
            }
            Destroy(gameObject);
        }
  
    }

    // M�todo para detener la animaci�n
    public void StopAnimation()
    {
        isAnimating = false;
    }
}

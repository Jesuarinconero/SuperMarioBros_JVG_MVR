using UnityEngine;
using System.Collections;

public class SpritesAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameTime = 0.1f;

    private int animationFrame = 0;
    private SpriteRenderer spriteRenderer;

    public bool isAnimating = true;  // Controla si la animación sigue funcionando

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
        while (isAnimating) // Solo ejecuta la animación si isAnimating es true
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

    // Método para detener la animación
    public void StopAnimation()
    {
        isAnimating = false;
    }
}

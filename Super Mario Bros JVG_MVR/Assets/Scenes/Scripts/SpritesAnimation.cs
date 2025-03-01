using UnityEngine;
using System.Collections;

public class SpritesAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameTime = 0.1f;

    private float timer = 0f;
    private int animationFrame = 0;

    private SpriteRenderer spriteRenderer;

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
        while (true) 
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
}

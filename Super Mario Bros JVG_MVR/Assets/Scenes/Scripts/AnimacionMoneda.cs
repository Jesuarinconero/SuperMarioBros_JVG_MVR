using UnityEngine;
using UnityEngine.UI;

public class AnimacionMoneda : MonoBehaviour
{

    public Sprite[] sprites;
 public float frameTime = 0.1f;
    Image image;
    int animationframe = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image = GetComponent<Image>();
        InvokeRepeating("ChangeImage",frameTime, frameTime);
    }
    void ChangeImage()
    {
        image.sprite = sprites[animationframe];
        animationframe++;
        if(animationframe >= sprites.Length)
        {
            animationframe = 0;
        }
    }
}

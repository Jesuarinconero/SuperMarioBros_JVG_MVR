using System;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;

public class FloatPoint : MonoBehaviour
{
    public Sprite[] sprites;
    public int numPoint = 0;
    public float distance = 2f;
    public float speed = 2f;
    public bool detroy = true;
    float targetPos;
    public int[] puntos;
    public bool destroy = true;
    
    public Point[] points;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Show(numPoint);
        targetPos = transform.position.y + distance;
    }

    void Show(int points)
    {
     
    for(int i= 0; i < this.points.Length; i++)
        {
            if (this.points[i].numPoints == points) { 
                spriteRenderer.sprite = this.points[i].sprite;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < targetPos)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed *Time.deltaTime));
        }else if (destroy){
            Destroy(gameObject);
                }
    }
    [Serializable]
    public class Point
    {
        public int numPoints;
        public Sprite sprite;
    }
}


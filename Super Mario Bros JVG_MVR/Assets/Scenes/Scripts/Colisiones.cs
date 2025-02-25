using UnityEngine;

public class Colisiones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pipe"))
        {
            Debug.Log("Toco la tuberia de tu puta madre :=)");

            
        }else if (collision.gameObject.CompareTag("suelo"))
        {
            Debug.Log("Toco el suelo de tu puta madre :=)");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pipe")
        {
            Debug.Log("Toco la tuberia de tu puta madre :=)");


        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pipe"))
        {
            Debug.Log("Dejo de tocar la tuberia de tu puta madre  :=)");


        }
        else if (collision.gameObject.CompareTag("suelo"))
        {
            Debug.Log("Dejo de tocar  el suelo de tu puta madre :=)");
        }
    }
}

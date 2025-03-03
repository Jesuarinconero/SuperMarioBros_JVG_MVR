using JetBrains.Annotations;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public Transform flag;
    public GameObject poitnFreab;
    public Transform bottonFlag;
    public float flagVelocity = 5;
    bool downFlag;
    Mover mover;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Mario mario = collision.GetComponent<Mario>();
        if(mario != null)
        {
            downFlag = true;
            mario.Goal();
            mover = collision.GetComponent<Mover>();
            Vector2 contactoPoint = collision.ClosestPoint(transform.position);
            Instantiate(poitnFreab, contactoPoint, Quaternion.identity);
            CalcularAltura(contactoPoint.y);
        }
    }
    private void FixedUpdate()
    {
        if (downFlag)
        {
            if(flag.position.y> bottonFlag.position.y)
            {
                flag.position = new Vector2(flag.position.x, flag.position.y - (flagVelocity * Time.fixedDeltaTime));
            }
            else
            {
                mover.isFlagFDown = true;
            }
        }
    }
    void CalcularAltura(float posicionMario)
    {
        float size = GetComponent<BoxCollider2D>().bounds.size.y;
        float min1 = transform.position.y + (size - size / 5f);
        float min2 = transform.position.y + (size - 2*size / 5f);
        float min3 = transform.position.y + (size - 3 * size / 5f);
        float min4 = transform.position.y + (size - 4 * size / 5f);
        float min5 = transform.position.y + (size - 5 * size / 5f);

        if (posicionMario>= min1)
        {
            ScoreManager.Instance.SumarPuntos(5000);
        }
        else if(posicionMario >= min2)
        {
            ScoreManager.Instance.SumarPuntos(2000);
        }
        else if (posicionMario >= min3)
        {
            ScoreManager.Instance.SumarPuntos(800);
        }
        else if (posicionMario >= min4)
        {
            ScoreManager.Instance.SumarPuntos(400);
        }
        else
        {
            ScoreManager.Instance.SumarPuntos(100);
        }

    }
}

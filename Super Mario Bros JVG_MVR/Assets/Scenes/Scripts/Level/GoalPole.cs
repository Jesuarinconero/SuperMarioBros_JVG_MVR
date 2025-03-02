using JetBrains.Annotations;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public Transform flag;

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
}

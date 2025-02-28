using UnityEngine;

public class MostrarYEsconder : MonoBehaviour
{
    public GameObject objetomovimiento;
    public Transform showPoint;
    public Transform hidePoint;


    public float waitforShow;
    public float waitforHide;


    public float speedshow;
    public float speedhide;

    float timeshow;
    float timehide;

    float speed;
    Vector2 targetpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetpoint = hidePoint.position;
        speed = speedhide;
        timehide = 0;
        timeshow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        objetomovimiento.transform.position = Vector2.MoveTowards(objetomovimiento.transform.position,targetpoint,speed*Time.deltaTime);
        if (Vector2.Distance(objetomovimiento.transform.position, hidePoint.position) < 0.1f){
            //El objeto esta en el punto escondido
            timeshow += Time.deltaTime;
            if (timeshow >= waitforShow )
            {
                targetpoint = showPoint.position;
                speed = speedshow;
                timeshow = 0;
            }

        }
        else if (Vector2.Distance(objetomovimiento.transform.position, showPoint.position) < 0.1f)
        {
            timehide += Time.deltaTime;
            if (timehide >= waitforHide)
            {
                targetpoint = hidePoint.position;
                speed = speedhide;
                timehide = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up, Vector2.one);
    }
}

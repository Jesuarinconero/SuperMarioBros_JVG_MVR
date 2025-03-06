using UnityEngine;

public class MusicaInicio : MonoBehaviour
{
    public AudioClip audioInicio;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // A�ade un AudioSource si no existe
        }

        audioSource.loop = true; // Hace que la m�sica se repita en bucle
        audioSource.playOnAwake = false; // Evita que se reproduzca autom�ticamente
    }

    private void Start()
    {
        Musicainicio(); // Llama a la funci�n para iniciar la m�sica
    }

    public void Musicainicio()
    {
        if (audioInicio != null && audioSource != null)
        {
            audioSource.clip = audioInicio;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Falta AudioClip o AudioSource en MusicaInicio.");
        }
    }
}

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
            audioSource = gameObject.AddComponent<AudioSource>(); // Añade un AudioSource si no existe
        }

        audioSource.loop = true; // Hace que la música se repita en bucle
        audioSource.playOnAwake = false; // Evita que se reproduzca automáticamente
    }

    private void Start()
    {
        Musicainicio(); // Llama a la función para iniciar la música
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

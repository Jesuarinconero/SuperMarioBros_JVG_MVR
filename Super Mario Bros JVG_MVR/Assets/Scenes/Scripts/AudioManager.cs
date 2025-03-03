using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour{
    public AudioClip clipJump;
    public AudioClip clipBigJump;
    public AudioClip clipCoin;
    public AudioClip clipBigStomp;
    public AudioClip clipFlipDie;
    public AudioClip clipShoot;
    public AudioClip clipPowerUp;
    public AudioClip clipPowerDown;
    public AudioClip clipPowerUpAppear;
    public AudioClip clipBreak;
    public AudioClip clipBump;
    public AudioClip clipDie;
    public AudioClip clipFlagPole;
    public AudioClip clipStomp;
    AudioSource audioSource; 
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayJump()
    {
        
        audioSource.PlayOneShot(clipJump);
    }

    public void PlayBigJump()
    {
        audioSource.PlayOneShot(clipBigJump);
    }
    public void PlayCoin()
    {
        audioSource.PlayOneShot(clipCoin);
    }
    public void PlayStomp()
    {
        audioSource.PlayOneShot(clipStomp);
    }
    public void PlayflipDie()
    {
        audioSource.PlayOneShot(clipFlipDie);
    }
    public void PlayShoot()
    {
        audioSource.PlayOneShot(clipShoot);
    }
    public void PlayPowerUp()
    {
        audioSource.PlayOneShot(clipPowerUp);
    }
    public void PlayPowerDown()
    {
        audioSource.PlayOneShot(clipPowerDown);
    }
    public void PlayPowerAppear()
    {
        audioSource.PlayOneShot(clipPowerUpAppear);
    }
    public void PlayBreak()
    {
        audioSource.PlayOneShot(clipBreak);
    }
    public void PlayBump()
    {
        audioSource.PlayOneShot(clipBump);
    }
    public void PlayDead()
    {
        audioSource.PlayOneShot(clipDie);
    }
    public void PlayFlagPole()
    {
        audioSource.PlayOneShot(clipFlagPole);
    }




}

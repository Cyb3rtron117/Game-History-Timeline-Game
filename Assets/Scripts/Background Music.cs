using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource Music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Music.volume = 0.1f;
        Music.Play();
    }

    public void PauseMusic()
    {
        Music.Pause();
    }
    public void UnPause()
    {
        Music.UnPause();
    }

    private void FixedUpdate()
    {
        if(Music.isPlaying && SceneManager.GetActiveScene().name == "Main Menu")
        {
            Music.Stop();
        }
        else
        {
            if(!Music.isPlaying)
            {
                Music.Play();
            }
        }
    }
}

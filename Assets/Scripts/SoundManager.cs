using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Player")]
    public AudioSource playerWalk;
    public AudioSource playerAttack;
    public AudioSource playerHurt;
    [Header("Enemy")]
    public AudioSource enemyAttack;
    public AudioSource enemyHurt;
    [Header("Button")]
    public AudioSource button;

    [Header("Music")]
    public AudioSource FightMusic;
    
    public AudioSource VectoryMusic;

    private GameObject _BackgroundMusicObj;
    public BackgroundMusic _BackgroundMusic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _BackgroundMusicObj = GameObject.FindGameObjectWithTag("SceneTracker");
        if(_BackgroundMusicObj != null)
        {
            _BackgroundMusic = _BackgroundMusicObj.GetComponent<BackgroundMusic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playPlayerwalk()
    {
        playerWalk.Play();
        playerWalk.volume = 0.1f;
    }
    public void stopPlayerWalk()
    {
        playerWalk.Stop();
    }
    public void playPlayerAttack()
    {
        playerAttack.Play();
    }
    public void playPlayerHurt()
    {
        playerHurt.Play();
    }
    public void playEnemyAttack()
    {
        enemyAttack.Play();
    }
    public void playEnemyHurt()
    {
        enemyHurt.Play();
    }

    public void playButton()
    {
        button.volume = 0.2f;
        button.Play();
    }
    public void playFightMusic()
    {
        if (_BackgroundMusic != null)
        {
            _BackgroundMusic.PauseMusic();
        }
        FightMusic.volume = 0.1f;
        FightMusic.Play();
    }
    public void stopFightMusic()
    {
        FightMusic.Stop();
        if (_BackgroundMusic != null)
        {
            _BackgroundMusic.UnPause();
        }
    }
    public void playVictory()
    {
        VectoryMusic.volume = 0.1f;
        VectoryMusic.Play();
    }
}

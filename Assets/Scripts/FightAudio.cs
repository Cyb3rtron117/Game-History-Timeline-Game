using UnityEngine;

public class FightAudio : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        _soundManagerScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playPlayerAttack()
    {
        _soundManagerScript.playPlayerAttack();
    }
    public void playPlayerHurt()
    {
        _soundManagerScript.playPlayerHurt();
    }
    public void playEnemyAttack()
    {
        _soundManagerScript.playEnemyAttack();
    }
    public void playEnemyHurt()
    {
        _soundManagerScript.playEnemyHurt();
    }

    public void playButton()
    {
        _soundManagerScript.playButton();
    }
    public void playFightMusic()
    {
        _soundManagerScript.playFightMusic();
    }
    public void stopFightMusic()
    {
        _soundManagerScript.stopFightMusic();
    }
    public void playVictory()
    {
        _soundManagerScript.playVictory();
    }
}

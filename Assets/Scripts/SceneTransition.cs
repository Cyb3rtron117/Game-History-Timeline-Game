using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;

    public float transitionTime = 1f;
    public void loadMainMenu() //start scene
    {
        StartCoroutine(LoadNextLevel(0));
    }

    public void loadWinter() //level
    {
        StartCoroutine(LoadNextLevel(1));
    }

    public void loadSpring() //endscreen
    {
        StartCoroutine(LoadNextLevel(2));
    }
    public void loadSummer()
    {
        StartCoroutine(LoadNextLevel(3));
    }

    public void loadAutumn()
    {
        StartCoroutine(LoadNextLevel(4));
    }
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadNextLevel(int LevelIndex)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }

    
}

using System;
using UnityEngine;

public class FastTravel : MonoBehaviour
{
    public TransitionSelect TravelTo;
    public GameObject sceneTransitionObj;
    public GameObject _SceneComplete;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(sceneTransitionObj == null)
        {
            sceneTransitionObj = GameObject.FindGameObjectWithTag("GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            switch (TravelTo)
            {
                case TransitionSelect.None:
                    Debug.LogError("None Selected for transition");
                    break;
                case TransitionSelect.Winter:
                    if(_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Spring)
                    {
                        SceneTracker.travelDirection = TravelDirection.Left;
                    }
                    sceneTransitionObj.GetComponent<SceneTransition>().loadWinter();
                    break;
                case TransitionSelect.Spring:
                    if (_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Winter)
                    {
                        SceneTracker.travelDirection = TravelDirection.Right;
                    }
                    if (_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Summer)
                    {
                        SceneTracker.travelDirection = TravelDirection.Left;
                    }
                    sceneTransitionObj.GetComponent<SceneTransition>().loadSpring();
                    break;
                case TransitionSelect.Summer:
                    if (_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Spring)
                    {
                        SceneTracker.travelDirection = TravelDirection.Right;
                    }
                    else if (_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Autumn)
                    {
                        SceneTracker.travelDirection = TravelDirection.Left;
                    }
                    sceneTransitionObj.GetComponent<SceneTransition>().loadSummer();
                    break;
                case TransitionSelect.Autumn:
                    if (_SceneComplete.GetComponent<SceneComplete>().thisLevel == currentLevel.Summer)
                    {
                        SceneTracker.travelDirection = TravelDirection.Right;
                    }
                    sceneTransitionObj.GetComponent<SceneTransition>().loadAutumn();
                    break;
            }
        }
    }




}


public enum TransitionSelect
{
    None,
    Winter,
    Spring,
    Summer,
    Autumn

}

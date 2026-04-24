using System.Collections.Generic;
using UnityEngine;

public class SceneTracker : MonoBehaviour
{
    public static bool WinterComplete = false;
    public static bool SpringComplete = false;
    public static bool SummerComplete = false;
    public static bool AutumnComplete = false;

    public static TravelDirection travelDirection;
    void Awake()
    {
        // Prevents this GameObject from being destroyed when a new scene loads
        DontDestroyOnLoad(gameObject);
        travelDirection = TravelDirection.Right;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhichScene(currentLevel level)
    {
        switch (level)
        {
            case currentLevel.Winter:
                WinterComplete = true;
                break;
            case currentLevel.Spring:
                SpringComplete = true;
                break;
            case currentLevel.Summer:
                SummerComplete = true;
                break;
            case currentLevel.Autumn:
                AutumnComplete = true;
                break;

        }
    }

}

public enum TravelDirection
{
    Left,
    Right,
}

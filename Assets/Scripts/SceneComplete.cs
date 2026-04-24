using UnityEngine;

public class SceneComplete : MonoBehaviour
{
    [SerializeField] private GameObject _sceneTracker;
    public currentLevel thisLevel;
    public GameObject EnemiesParent;
    public GameObject Player;

    [Header("Player Pos")]
    public Vector2 winterAltPos;
    public Vector2 springAltPos;
    public Vector2 summerAltPos;
    public Vector2 autumnAltPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _sceneTracker = GameObject.FindGameObjectWithTag("SceneTracker");
        switch (thisLevel)
        {
            case currentLevel.Winter:
                if(SceneTracker.WinterComplete)
                {
                    EnemiesParent.SetActive(false);
                    if (SceneTracker.travelDirection == TravelDirection.Left)
                    {
                        Player.transform.position = winterAltPos;
                    }
                }                
                break;
            case currentLevel.Spring:
                if (SceneTracker.SpringComplete)
                {
                    EnemiesParent.SetActive(false);
                    if (SceneTracker.travelDirection == TravelDirection.Left)
                    {
                        Player.transform.position = springAltPos;
                    }
                }
                break;
            case currentLevel.Summer:
                if (SceneTracker.SummerComplete)
                {
                    EnemiesParent.SetActive(false);
                    if (SceneTracker.travelDirection == TravelDirection.Left)
                    {
                        Player.transform.position = summerAltPos;
                    }
                }
                break;
            case currentLevel.Autumn:
                if (SceneTracker.AutumnComplete)
                {
                    EnemiesParent.SetActive(false);
                    if (SceneTracker.travelDirection == TravelDirection.Left)
                    {
                        Player.transform.position = autumnAltPos;
                    }
                }
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _sceneTracker.GetComponent<SceneTracker>().WhichScene(thisLevel);
        }
    }
}

public enum currentLevel
{
    Winter,
    Spring,
    Summer,
    Autumn
}

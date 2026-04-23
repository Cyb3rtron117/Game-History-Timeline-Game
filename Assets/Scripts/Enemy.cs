using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Fighting fightingScript;

    public Sprite FightSprite;
    public string FightTitle = " ";
    [Header("Positioning")]
    public Vector2 SpritePosition = Vector2.zero;
    public Vector2 SpriteSize = new Vector2(100, 100);
    public Vector2 ShadowSize = new Vector2(100, 40);
    public Vector2 ShadowPosition = Vector2.zero;
    [Header("Text")]
    [TextArea(2, 10)]
    public string GameText = " ";

    public bool test = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fightingScript = GameObject.FindGameObjectWithTag("FightController").GetComponent<Fighting>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fight()
    {
        fightingScript.UpdateEnemy(FightSprite, FightTitle, gameObject, SpritePosition, SpriteSize, ShadowSize, ShadowPosition, GameText);
    }

    public void Die()
    {

        gameObject.SetActive(false);
    }
}

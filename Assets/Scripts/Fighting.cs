using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fighting : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject EnemyImageObjectParent;
    public GameObject EnemyImageObject;
    public TextMeshProUGUI EnemyTitleObject;
    public GameObject CurrentEnemy;
    public GameObject enemyShadow;

    [Header("Dialogue")]
    public TextMeshProUGUI EnemyDialogue1;
    public TextMeshProUGUI EnemyDialogue2;


    public GameObject Player;
    private Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyTitleObject.text = "Enemy";
        EnemyImageObject.GetComponent<Image>().sprite = null;

        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        CurrentEnemy = null;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEnemy(Sprite enemyImage, string enemyTitle, GameObject enemy, Vector2 enemPos, Vector2 enemSize, Vector2 shadowSize, Vector2 shadowPos)
    {
        EnemyTitleObject.text = enemyTitle;

        EnemyImageObjectParent.GetComponent<RectTransform>().anchoredPosition = enemPos;
        EnemyImageObject.GetComponent<RectTransform>().sizeDelta = enemSize;
        enemyShadow.GetComponent<RectTransform>().sizeDelta = shadowSize;
        enemyShadow.GetComponent<RectTransform>().anchoredPosition = shadowPos;

        EnemyImageObject.GetComponent<Image>().sprite = enemyImage;
        CurrentEnemy = enemy;



        EnemyDialogue1.text = $"{enemyTitle} attacks with Basic";
        EnemyDialogue2.text = $"{enemyTitle} attacks with Advanced";
        StartFight();
    }

    void StartFight()
    {
        anim.SetTrigger("Start");
    }

    public void Win()
    {
        Player.GetComponent<PlayerManager>().InCombat = false;
        PlayerManager.FreezePlayer = false;
        CurrentEnemy.GetComponent<Enemy>().Die();

        /*
        EnemyTitleObject.text = "Enemy";
        EnemyImageObject.GetComponent<Image>().sprite = null;
        CurrentEnemy = null;*/
    }
}

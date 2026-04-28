using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fighting : MonoBehaviour
{
    private PlayerInputSystem playerInputSys; //input system reference

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

    private Loot lootScript;

    private bool inFight = false;

    void Awake()
    {
        playerInputSys = new PlayerInputSystem(); //initialising the input system
    }
    void OnEnable()
    {
        playerInputSys.Enable(); //needed for the input system
    }
    void OnDisable()
    {
        playerInputSys.Disable(); //needed for the input system
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lootScript = GetComponent<Loot>();
        EnemyTitleObject.text = "Enemy";
        EnemyImageObject.GetComponent<Image>().sprite = null;

        if(Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        CurrentEnemy = null;
        anim = GetComponent<Animator>();

        inFight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInputSys.Player.Skip.WasReleasedThisFrame() && inFight)
        {
            anim.ResetTrigger("Skip");
        }
        if (playerInputSys.Player.Skip.WasPressedThisFrame() && inFight)
        {
            anim.SetTrigger("Skip");
        }
        
    }

    public void UpdateEnemy(Sprite enemyImage, string enemyTitle, GameObject enemy, Vector2 enemPos, Vector2 enemSize, Vector2 shadowSize, Vector2 shadowPos, string LootText)
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


        lootScript.text = LootText;
    }

    void StartFight()
    {
        anim.SetTrigger("Start");
        inFight = true;
    }

    public void Win()
    {
        Player.GetComponent<PlayerManager>().InCombat = false;
        Player.GetComponent<PlayerManager>().inRange = false;
        PlayerManager.FreezePlayer = false;
        CurrentEnemy.GetComponent<Enemy>().Die();

        inFight = false;
        /*
        EnemyTitleObject.text = "Enemy";
        EnemyImageObject.GetComponent<Image>().sprite = null;
        CurrentEnemy = null;*/
    }
}

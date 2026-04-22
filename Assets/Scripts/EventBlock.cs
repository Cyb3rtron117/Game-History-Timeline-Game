using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventBlock : MonoBehaviour
{
    [Header("Tiles")]
    public AnimatedTile q_default;
    public AnimatedTile q_to_e;
    public AnimatedTile e_to_q;
    public AnimatedTile e_default;
    public Tilemap tilemap;

    public bool isOpen = false;
    public Animator animator;

    [Header("Cinemachine")]
    public CinemachineCamera cineCam;
    public GameObject playerCamTarget;
    public GameObject myInfo;

    [SerializeField] private float camShakeTime = 0.5f;
    [SerializeField] private float camShakeIntensity = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap.SetTile(tilemap.WorldToCell(transform.position), q_default);
        playerCamTarget = GameObject.FindGameObjectWithTag("PlayerCamTarget");
        cineCam = GameObject.FindFirstObjectByType<CinemachineCamera>();
        animator = gameObject.GetComponent<Animator>();
        if(myInfo == null )
        {
            myInfo = gameObject.transform.GetChild(0).gameObject;
            myInfo.SetActive(false);
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
            ToggleBlock();
            cineCam.GetComponent<CineCamShake>().ShakeCamera(camShakeIntensity, camShakeTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isOpen)
        {
            ToggleBlock();
        }
    }

    void ToggleBlock()
    {
        switch (isOpen)
        {
            case false:
                isOpen = true;
                tilemap.SetTile(tilemap.WorldToCell(transform.position), q_to_e);
                StartCoroutine(Make_Exclamation(q_to_e.m_AnimatedSprites.Length / q_to_e.m_MaxSpeed));
                break;

            case true:
                isOpen = false;
                tilemap.SetTile(tilemap.WorldToCell(transform.position), e_to_q);
                StartCoroutine(Make_Question(e_to_q.m_AnimatedSprites.Length / e_to_q.m_MaxSpeed));

                break;
        }
    }

    IEnumerator Make_Exclamation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tilemap.SetTile(tilemap.WorldToCell(transform.position), e_default);
        myInfo.SetActive(true);
        animator.SetTrigger("open");
        cineCam.Follow = myInfo.transform;
        //PlayerManager.FreezePlayer = true;

    }
    IEnumerator Make_Question(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tilemap.SetTile(tilemap.WorldToCell(transform.position), q_default);

        cineCam.Follow = playerCamTarget.transform;
        //PlayerManager.FreezePlayer = false;
        animator.SetTrigger("close");
    }

    public void Hide()
    {
        myInfo.SetActive(false);
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventBlock : MonoBehaviour
{
    public AnimatedTile q_default;
    public AnimatedTile q_to_e;
    public AnimatedTile e_to_q;
    public AnimatedTile e_default;
    public Tilemap tilemap;

    public bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap.SetTile(tilemap.WorldToCell(transform.position), q_default);
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
    }
    IEnumerator Make_Question(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tilemap.SetTile(tilemap.WorldToCell(transform.position), q_default);
    }

}

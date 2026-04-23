using TMPro;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Animator anim;
    public string text;
    public TextMeshProUGUI LootTextObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLoot()
    {
        LootTextObj.text = text;
        anim.SetTrigger("Loot");
    }
    public void HideLoot()
    {
        anim.SetTrigger("closeLoot");
    }
}

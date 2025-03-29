using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomSpawn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Interact interact;
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interact = transform.GetChild(0).GetComponent<Interact>();
        int num = Random.Range(0, 7);
        spriteRenderer.sprite = GameManager.Instance.ItemImages[num];
        interact.number = num;
    }
}

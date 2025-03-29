using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    PlayerData playerData;
    [SerializeField] private float Damage;
    void Start()
    {
        playerData = GameManager.Instance.PlayerData;
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerData.Hit(Damage);
        }
    }
}

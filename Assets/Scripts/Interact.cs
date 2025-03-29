using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public int number;
    PlayerData playerData;
    enum InteractType
    {
        Lever,
        Door,
        Item
    }
    [SerializeField] InteractType type;
    private void Start()
    {
        playerData = GameManager.Instance.PlayerData;
    }
    private void OnDisable()
    {
        switch (type)
        {
            case InteractType.Door:
                break;
            case InteractType.Lever: 
                break;
            case InteractType.Item:playerData.AddItem(number);
                break;
        }
    }
}

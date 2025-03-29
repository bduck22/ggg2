using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPrint : MonoBehaviour
{
    enum UiType
    {
        Air,
        Hp,
        Weight
    }
    [SerializeField] UiType type;
    PlayerData playerData;
    Text text;
    Image Image;
    void Start()
    {
        text = GetComponent<Text>();
        Image = text.transform.parent.GetComponent<Image>();
        playerData = GameManager.Instance.PlayerData;
    }
    void Update()
    {
        switch (type)
        {
            case UiType.Air:
                text.text = playerData.Air.ToString("#,##0") + " / " + playerData.MaxAir.ToString("#,##0");
                Image.fillAmount = playerData.Air / playerData.MaxAir;
                break;
            case UiType.Hp:
                text.text = playerData.Hp.ToString("#,##0") + " / " + playerData.MaxHp.ToString("#,##0");
                Image.fillAmount = playerData.Hp / playerData.MaxHp;
                break;
            case UiType.Weight:
                text.text = playerData.Weight.ToString("#,##0kg") + " / " + playerData.MaxWeight.ToString("#,##0kg");
                break;
        }
    }
}

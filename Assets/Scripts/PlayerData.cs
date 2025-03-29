using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public float Speed;
    public float Air;
    public float MaxAir;
    public float Hp;
    public float MaxHp;
    public float Weight;
    public float MaxWeight;

    public float AirDownSpeed;
    [SerializeField]Volume volume;

    public bool Invin;
    public float InvinTime;

    public int InvenSize;
    public List<int> Inventory;

    [SerializeField] Transform InvenImage;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Air > 0)
        {
            Air -= AirDownSpeed*Time.deltaTime;
            volume.weight = 1-Air/MaxAir;
        }
    }

    public void InvenLoad()
    {
        for (int i = 0; i < InvenSize; i++) {
            InvenImage.GetChild(i).GetChild(0).GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < Inventory.Count; i++)
        {
            InvenImage.GetChild(i).GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.ItemImages[Inventory[i]];
        }
    }

    IEnumerator InvinFalse()
    {
        Invin = true;
        for(int i = 0; i < 4; i++)
        {
            sprite.color = Color.white - Color.black * 0.7f;
            yield return new WaitForSeconds(InvinTime / 8f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(InvinTime / 8f);
        }
        Invin = false;
    }

    public void Hit(float Damage)
    {
        if (!Invin)
        {
            if (Hp > Damage)
            {
                Hp -= Damage;
            }
            else Hp = 0;
            StartCoroutine(InvinFalse());
        }
    }

    public void AddItem(int Itemnumber)
    {
        if(Inventory.Count < InvenSize)
        {
            Inventory.Add(Itemnumber);
            InvenLoad();
        }
    }
}

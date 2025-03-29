using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float Speed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, Player.position.y, -10), Speed*Time.deltaTime);
    }
}

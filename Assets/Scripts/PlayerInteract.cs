using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform E;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interact>())
        {
            E.position = collision.transform.position + new Vector3(0, 0.7f, 0);
            E.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (E.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E)&&collision.gameObject.layer==3)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        E.gameObject.SetActive(false);
    }
}

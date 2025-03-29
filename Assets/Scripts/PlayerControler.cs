using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform Flash;
    bool Horizon;
    bool Vertical;
    PlayerData playerData;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerData = GetComponent<PlayerData>();
    }
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Flash.localRotation = Quaternion.Euler(0, 0, 90);
                spriteRenderer.flipX = true;
            }
            else
            {
                Flash.localRotation = Quaternion.Euler(0, 0, 270);
                spriteRenderer.flipX = false;
            }
            Rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerData.Speed, Rb.velocity.y);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            Rb.velocity = new Vector2(0, Rb.velocity.y);
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                Flash.localRotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                Flash.localRotation = Quaternion.Euler(0, 0, 0);
            }
            Rb.velocity = new Vector2(Rb.velocity.x, Input.GetAxisRaw("Vertical") * playerData.Speed);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 0);
        }

        if (!Input.GetButton("Vertical")&& !Input.GetButton("Horizontal"))
        {
            animator.SetTrigger("Stop");
            Rb.velocity = Vector2.zero;
        }else
        {
            animator.SetFloat("Speed", playerData.Speed / 4);
            animator.SetTrigger("Move");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    [SerializeField]
    private GameObject playerPivot;
    
    Vector2 movementDirection;
    Animator playerAnimator;
    SpriteRenderer playerSprite;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        RotatePivot();
    }

    private void MovePlayer()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementDirection == Vector2.zero)
        {
            playerAnimator.SetFloat("xVelocity", 0f);
            return;
        }

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        if (movementDirection.x != 0)
        {
            if (movementDirection.x < 0)
            {
                playerSprite.flipX = true;
            } else
            {
                playerSprite.flipX = false;
            }
        }

        playerAnimator.SetFloat("xVelocity", 1f);
    }

    private void RotatePivot()
    {
        Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookDirection = (lookDirection - transform.position).normalized;
        
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        playerPivot.transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.forward);
    }
}

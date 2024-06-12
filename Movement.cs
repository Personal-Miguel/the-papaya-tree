using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private readonly string MAIN_CHAR_NAME = "TropicalNative";
    private readonly int MOUSE_LEFT_BTN = 0;
    private readonly int RIGHT_MOUSE_BTN = 1;
    private readonly int JUMP_STRENGTH = 20;

    private Rigidbody2D rb;
    private Animator anim;

    private int moveCharges = 3;
    private bool onMoveCooldown = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateJumpAndDashIndicators();

        var rawMousePos = Input.mousePosition;
        var mousePos = Camera.main.ScreenToWorldPoint(rawMousePos);


        if (Input.GetMouseButton(MOUSE_LEFT_BTN) && !Input.GetMouseButton(RIGHT_MOUSE_BTN) && !onMoveCooldown && moveCharges > 0)
        {
            Console.Write(mousePos.x);
            Jump();
            HandleChargeSpent();
        }
    }

    private void UpdateJumpAndDashIndicators()
    {
        GameObject.Find("Indicator1").GetComponent<Renderer>().material.color = moveCharges > 2 ? Color.green : Color.red;
        GameObject.Find("Indicator2").GetComponent<Renderer>().material.color = moveCharges > 1 ? Color.green : Color.red;
        GameObject.Find("Indicator3").GetComponent<Renderer>().material.color = moveCharges > 0 ? Color.green : Color.red;
    }

    private void HandleChargeSpent()
    {
        moveCharges--;
        onMoveCooldown = true;

        Invoke(nameof(AddMoveCharge), 2.0f);
        Invoke(nameof(PutMoveCooldownFalse), 0.2f);
    }

    private void AddMoveCharge()
    {
        moveCharges++;
    }

    private void PutMoveCooldownFalse()
    {
        onMoveCooldown = false;
    }

    void Jump()
    {
        var grunt = GameObject.Find("Grunt").GetComponent<AudioSource>();
        grunt.Play();

        var mainChar = GameObject.Find(MAIN_CHAR_NAME);
        var mainCharPos = mainChar.transform.position;

        var rawMousePos = Input.mousePosition;
        var mousePos = Camera.main.ScreenToWorldPoint(rawMousePos);

        float horizontalVelocity;
        if (mainCharPos.x > mousePos.x)
        {
            anim.SetBool("IsFacingRight", false);
            horizontalVelocity = -2.5f * (mainCharPos.x - mousePos.x);
        }
        else
        {
            anim.SetBool("IsFacingRight", true);
            horizontalVelocity = 2.5f * (mousePos.x - mainCharPos.x);
        }
        rb.velocity = new Vector2(horizontalVelocity * 0.8f, JUMP_STRENGTH);
    }
}

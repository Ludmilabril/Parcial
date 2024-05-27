using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller_PlayerDash : Controller_PlayerLevel2
{
    private float horizontal;
    private bool isFacingRight = true;
    public float jumpingPower = 5f;

    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 100f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpingPower, rb.velocity.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    public override void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, rb.velocity.z);
        base.FixedUpdate();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector3(transform.localScale.x * dashPower, 0f, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
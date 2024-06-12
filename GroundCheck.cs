using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private readonly Vector3 AT_CHAR_FEET = new Vector2(-0.17f, -4.83f);
    private readonly int ANGLE = 0;

    public Transform groundCheckTransform;
    public LayerMask groundLayer;

    private Animator anim;
    private bool isGrounded;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(
            groundCheckTransform.position,
            AT_CHAR_FEET,
            CapsuleDirection2D.Horizontal,
            ANGLE,
            groundLayer
        );

        if (isGrounded)
        {
            anim.SetBool("InFlight", false);
        }
        else
        {
            anim.SetBool("InFlight", true);
        }
    }
}

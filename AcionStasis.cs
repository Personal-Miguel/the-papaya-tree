using UnityEngine;
using UnityEngine.UI;

public class AcionStasis : MonoBehaviour
{
    private readonly int LEFT_MOUSE_BTN = 0;
    private readonly int RIGHT_MOUSE_BTN = 1;
    private readonly Vector2 STAND_STILL = new(0, 0);
    private readonly float STASIS_TIMEOUT_LENGTH = 1f;

    public Image stasisMeter;
    public Image meterHolder;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource stasisSound;
    private bool stasisTimeOut = false;
    private float elapsed = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stasisSound = GameObject.Find("StasisSound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Input.GetMouseButton(LEFT_MOUSE_BTN) && Input.GetMouseButton(RIGHT_MOUSE_BTN) && !stasisTimeOut)
        {
            anim.SetBool("InStasis", true);

            rb.velocity = STAND_STILL;
            rb.gravityScale = 0;

            stasisMeter.enabled = true;
            meterHolder.enabled = true;
            stasisMeter.fillAmount = elapsed / 0.5f;

            elapsed += Time.deltaTime;
            if (elapsed >= 0.5f)
            {
                elapsed %= 0.5f;
                stasisTimeOut = true;
                Invoke(nameof(PutStasisTimeoutFalse), STASIS_TIMEOUT_LENGTH);
            }
        }
        else
        {
            stasisMeter.enabled = false;
            meterHolder.enabled = false;
            elapsed = 0;

            stasisSound.Play();
            anim.SetBool("InStasis", false);
            rb.gravityScale = 5;
        }
    }

    private void PutStasisTimeoutFalse()
    {
        stasisTimeOut = false;
    }
}

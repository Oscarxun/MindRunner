using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;

    public float jumpForce;

    private Rigidbody2D playerRigidBody;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D playerCollider;
    private Animator playerAnimator;

    public GameManager gameManager;

    public TGCConnectionController controller;
    public Slider attSlider;
    private float sliderValue;

    //private int poorSignal;
    private int attention;
    private int blink;

    public static bool gotMagnet;

    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        moveSpeedStore = moveSpeed;

        gotMagnet = false;

        attSlider.value = 0.0f;
        sliderValue = attSlider.value;

        controller.Connect();

        //controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        controller.UpdateAttentionEvent += OnUpdateAttention;
        controller.UpdateBlinkEvent += OnUpdateBlink;
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounded)
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }

        playerAnimator.SetBool("Grounded", grounded);

        attSlider.value = Mathf.Lerp(sliderValue, ((float)attention / 100), 0.5f);
        sliderValue = attSlider.value;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.Disconnect();
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "KillBox" || collision.gameObject.tag == "Monster")
        {
            gameManager.RestartGame();

            moveSpeed = moveSpeedStore;
        }
    }

    void OnUpdateAttention(int value)
    {
        attention = value;
        moveSpeed = moveSpeedStore + (attention / 20);
        //Debug.Log(moveSpeed);
    }

    void OnUpdateBlink(int value)
    {
        blink = value;
        //Debug.Log(blink);

        if(blink > 60)
        {
            if (grounded)
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }
}

using System;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    float jumpForce;
    public LayerMask groundLayer;

    private Vector2 direction = Vector2.right;
    private float horizontal;
    Animator Animator;
    float velX, velY;
    public Rigidbody2D playerRigidbody { get; private set; }

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", horizontal != 0);
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);


        //Debug.Log(Physics2D.Raycast(transform.position, Vector3.down, 0.1f));

        // Almacena el resultado del rayo en una variable.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);

        /*
        // Usa la variable para saber si el rayo golpeó algo.
        if (hit.collider != null)
        {
            // Esto solo se ejecuta si el rayo golpeó un collider.
            Debug.Log("Estoy tocando el suelo en el punto: " + hit.point);
            Debug.Log("El objeto que golpeé se llama: " + hit.collider.gameObject.name);

            // Puedes usar esta información para tomar decisiones en tu juego.
        }
        */

        if (hit.collider!=null)
        {
            isGrounded = true;
            //Debug.Log("true");
        }
        else
        {
            isGrounded = false;
            //Debug.Log("false");
        }

        if (Input.GetKeyDown(inputUp)&&isGrounded)
        {
            //SetDirection(Vector2.up);
            jump();
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right);
        }
        else
        {
            SetDirection(Vector2.zero);
        }
    }

    private void FixedUpdate()
    {
        Vector2 posTmp = playerRigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        playerRigidbody.MovePosition(posTmp + translation);
    }

    void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    private Rigidbody2D _playerRigidbody;
    public bool IsonGround = true;
    public int life = 3;
    public TextMeshProUGUI lifeText;
    private Animator Anim; 

    private void Start()
    {

        _playerRigidbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
         
        MovePlayer();

    
        if (Input.GetKeyDown(KeyCode.Space) && IsonGround)
        {
            Jump();
            IsonGround = false;
            Anim.SetBool("isOnGround", false);
        }
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.5f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
        
    }
    public void updateLifeText()
    {
        lifeText.text = life.ToString();

    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() { _playerRigidbody.velocity = new Vector2(0, jumpPower); }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsonGround = true;
            Anim.SetBool("isOnGround", true);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            lifeText.text = life.ToString();
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.6f, gameObject.transform.position.y - 0.6f, gameObject.transform.position.z);

            IsonGround = true;

            if (life <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }

        }

    }
}
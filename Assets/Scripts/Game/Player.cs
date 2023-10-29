using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _playerSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 playerDirection;

    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(direction, 0).normalized;
    }
    private void FixedUpdate()
    {
        if(_gameManager.startTimer == 0)
            _rigidbody.velocity = new Vector2(playerDirection.x * _playerSpeed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckMiss")
        {
            _gameManager.score++;
            _gameManager.speed += 0.1f;
            _gameManager.TextsUpdate();
            _gameManager.UpdateSpeed();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Car")
           _gameManager.GameOver();
        
        if (collision.transform.tag == "Money")
        {
            Destroy(collision.gameObject);
            _gameManager.money++;
            _gameManager.TextsUpdate();
        }
    }


}

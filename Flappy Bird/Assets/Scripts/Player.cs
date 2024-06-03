using UnityEngine;


public class Player : MonoBehaviour
{
    public GameSettings gameSettings;
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), gameSettings.playerAnimationDelay, gameSettings.playerAnimationSpeed);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(gameSettings.playerJumpKey)) {
            direction = Vector3.up * gameSettings.playerStrength;
        }

        // Apply gravity and update the position
        direction.y += gameSettings.playerGravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * gameSettings.playerTilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteRenderer.sprite = gameSettings.playerAnimationSprites[spriteIndex];
        spriteIndex = (spriteIndex + 1) % gameSettings.playerAnimationSprites.Count;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            GameManager.Instance.IncreaseScore();
        }
    }

}


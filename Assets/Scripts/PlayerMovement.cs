using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    public ScoreManager scoreManager;
    public GameManager gameManager;

    public float jumpSpeed;
    public float maxFallSpeed;
    public float gravity;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _velocity;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.gameState == GameState.Start)
        {
            _rigidbody.velocityY = 0;
            transform.position = new Vector3(transform.position.x, math.sin(Time.time * 2f) * 0.3f, -1f);
            _velocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            _velocity = math.max(jumpSpeed, (_velocity + jumpSpeed) / 1.4f);

        _velocity = math.max(-1 * maxFallSpeed, _velocity - gravity * Time.deltaTime);
        _rigidbody.velocityY = _velocity;

        var zRot = _velocity > 0 ? _velocity * 4 : math.max(-90, _velocity * 6);
        transform.rotation = Quaternion.Euler(0, 0, zRot);

        _animator.SetBool(IsFalling, _velocity < -8);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreTrigger"))
            scoreManager.IncrementScore();
        else if (other.CompareTag("Killer")) gameManager.PlayerDead();
    }
}
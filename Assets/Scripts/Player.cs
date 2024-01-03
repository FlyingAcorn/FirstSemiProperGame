using UnityEngine;

public class Player : MonoBehaviour
{
    private float _movementX;
    private float _movementZ;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    private Rigidbody _myBody;
    private Animator _myAnim;
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;
    private ICollision _iCollision;
    private static readonly int Magnitude = Animator.StringToHash("Magnitude");
    private static readonly int Y = Animator.StringToHash("y");
    private static readonly int VelocityY = Animator.StringToHash("velocityY");
    private static readonly int TrapDeath = Animator.StringToHash("trapDeath");
    private static readonly int Victory = Animator.StringToHash("victory");

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Win) _myAnim.SetBool(Victory,true);
    }


    private void Start()
    {
        _myBody = GetComponent<Rigidbody>();
        _myAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.state == GameManager.GameState.Play) PlayerMovement();
        if (transform.position.y < -0.6f)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
        }
    }

    private void Update()
    {
        _myAnim.SetFloat(Y,transform.position.y,0.05f,Time.deltaTime);
        _myAnim.SetFloat(VelocityY,_myBody.velocity.y,0.05f,Time.deltaTime);
        if (GameManager.Instance.state != GameManager.GameState.Play) return;
        PlayerJump();
        if (Input.GetKeyDown(KeyCode.E)) _iCollision?.Interact();
    }

   private void PlayerMovement()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        _movementZ = Input.GetAxisRaw("Vertical");
        var movementDirection = new Vector3(_movementX, 0, _movementZ);
        var inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        _myAnim.SetFloat(Magnitude,inputMagnitude,0.1f,Time.deltaTime);
        if (_movementX == 0 & _movementZ == 0) return;
        transform.position += movementDirection * (moveForce * Time.deltaTime);
        var targetAngle = Mathf.Atan2(_movementX, _movementZ) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0,angle,0);
    }
   
    private void PlayerJump()
    {
        if (_myBody.velocity.y >0.1 || _myBody.velocity.y <-0.1f) return;
        if (Input.GetButtonDown("Jump")) _myBody.velocity = Vector2.up * jumpForce;
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out ICollision icol)) _iCollision = icol;
        if (trigger.TryGetComponent(out Teleporter teleporter))transform.position = teleporter.destination;
        if (trigger.TryGetComponent(out Trap _))
        {
            _myAnim.SetBool(TrapDeath,true);
            GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.TryGetComponent(out ICollision _))  _iCollision = null;
    }
}

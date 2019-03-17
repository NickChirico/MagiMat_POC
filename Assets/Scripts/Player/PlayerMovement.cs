using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles player movement: running, jumping, climbing
//uses Physics2D to check for ground and climbables, does not use attached colliders

public class PlayerMovement : MonoBehaviour
{
    private PlayerManager _playerManager;
    
    private Rigidbody2D _rigidbody2D;

    private Vector2 _inputVector;
    [HideInInspector] public bool _hasJumped; //whether or not the player has jumped recently, set to false when recently grounded/climbing
    [HideInInspector] public bool _isGrounded;
    [HideInInspector] public bool _wasGrounded;
    [HideInInspector] public bool _isClimbing;
    
    public float acceleration;
    public float groundFriction; //drag force
    public float maxMoveSpeed; //max horizontal velocity, does not cap velocity, instead determines when more force can be added
    public float climbSpeed;
    public float jumpPower;

    public LayerMask groundLayers;
    public LayerMask climbableLayers;
    
    private float _gravityScale;

    void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
        
        //assign components
        _rigidbody2D = GetComponent<Rigidbody2D>();

        //remember original gravity scale in case it is changed later
        _gravityScale = _rigidbody2D.gravityScale;
    }

    void Update()
    {   
        //axis inputs to Vector2
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _inputVector = new Vector2(horizontal, vertical);

        //grounded check and check if the player was recently grounded
        //if player was recently grounded, set _hasJumped to false
        _wasGrounded = _isGrounded;
        _isGrounded = GroundedCheck();
        if (_isGrounded && !_wasGrounded)
        {
            _hasJumped = false;
        }
        
        //player can jump if grounded or climbing and has not jumped recently
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded || _isClimbing) && !_hasJumped)
        {
            if (_isClimbing)
            {
                _isClimbing = false;
                _rigidbody2D.gravityScale = _gravityScale;
            }
            Jump(jumpPower);
            _hasJumped = true;
        }

        //if the player is not currently climbing, circleCast nearby to look for climbables
        //if there is a nearby climbable, press W to start climbing
        if (!_isClimbing)
        {
            Collider2D climbable = ClimbableNearby();
            if (climbable)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //changes for changing movement mode to climbing
                    _isClimbing = true;
                    _hasJumped = false;
                    _rigidbody2D.gravityScale = 0;
                    _rigidbody2D.velocity = Vector2.zero;
                    SnapXToClimbable(climbable);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (_isClimbing)
        {
            Climb();
        }
        else
        {
            Run();
        }
    }

    bool GroundedCheck()
    {
        //check below the player if there is ground
        
        return Physics2D.OverlapArea(
            transform.position + new Vector3(-0.35f, -0.5f, 0),
            transform.position + new Vector3(0.35f, -0.6f, 0), 
            groundLayers);
    }

    Collider2D ClimbableNearby()
    {
        //circle cast on the center of the player for climbables, return Collider2D if one is present
        
        return Physics2D.OverlapCircle(transform.position, 0.25f, climbableLayers);
    }

    void SnapXToClimbable(Collider2D climbable)
    {
        //when player starts climbing, center player's X position to climbable's center
        
        float snapX = climbable.transform.position.x;
        transform.position = new Vector2(snapX, transform.position.y);
    }

    void Run()
    {
        //handles horizontal movement when grounded or in the air
        
        Vector2 velocity = _rigidbody2D.velocity;
        Vector2 horizontalInput = new Vector2(_inputVector.x, 0);

        if (_isGrounded && _inputVector.x == 0)
        {
            //if the player is grounded and is no longer moving the character, apply drag to bring player to a fast stop
            Vector2 velocityX = new Vector2(velocity.x, 0);
            _rigidbody2D.AddForce(velocityX * -groundFriction * Time.fixedDeltaTime);
        } 
        else if (Mathf.Abs(velocity.x) < maxMoveSpeed)
        {
            //add force to player in input direction, only runs if player is not already at its maxMoveSpeed
            _rigidbody2D.AddForce(horizontalInput * acceleration * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }

    void Climb()
    {
        //handles vertical movement when climbing
        
        Vector3 verticalInput = new Vector2(0, _inputVector.y);
        
        _rigidbody2D.MovePosition(transform.position + (verticalInput * climbSpeed * Time.fixedDeltaTime));
    }

    void Jump(float power)
    {
        //add upward force for jump
        //set y velocity to 0 for consistent jump height even if there was previously a downward velocity
        
        Vector2 velocity = _rigidbody2D.velocity;
        velocity.y = 0;
        _rigidbody2D.velocity = velocity;
        _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}

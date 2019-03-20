using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;

    public Material material;
    
    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public class FireToad : Enemy
{
    [HideInInspector] public bool _isGrounded;
    [HideInInspector] public bool _isJumping;
    public float jumpPower;
    public GameObject Fireball;
    
    void Update()
    {
        //Will jump if it is on the ground and isn't already in the jumping process
        if (_isGrounded && !_isJumping)
        {
            StartCoroutine(JumpAttack());
        }
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

    //Wait a few seconds, jumps, attacks during the jump at different heights
    IEnumerator JumpAttack()
    {
        _isJumping = true;
        float JumpWait = 3;
        float AttackWait = Random.Range(.2f, .3f);
        yield return new WaitForSeconds(JumpWait);
        Jump(jumpPower);
        _isGrounded = false;
        yield return new WaitForSeconds(AttackWait);
        GameObject FireballClone = Instantiate(Fireball, transform.position, Quaternion.identity);
    }

    //Set grounded when on the ground
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            _isGrounded = true;
        }
    }
}


public class StoneGolem : Enemy
{
    [HideInInspector] public bool _isWalking;
    [HideInInspector] public bool _isThrowing;
    
    
    public float walkSpeed; //speed of walking
    public GameObject Boulder; // prefab for boulder that is thrown
    public float walkTimer = 0f; // timer used to walk for certain length of time //DEFINETLY NOT A GOOD IDEA WE NEED A BETTER ONE -Charlie
    public float walkDuration; //duration of walk, pitted againsted the walk timer
    
    void Update()
    {
        walkTimer += Time.deltaTime; //increase timer by real world time
        
        //will start sequence when it is done with both processeses 
        if (!_isWalking && !_isThrowing)
        {
            StartCoroutine(boulderAttack());
        }
    }
    void Walk(float Speed, float timer, float duration)
    {
        //constantly change the x velocity to mimick walking
        //walking only for short period
        
        Vector2 velocity = _rigidbody2D.velocity;
        int numberModifyer = Random.Range(0, 2) * 2 - 1;

        while (timer <= duration)
        {
            velocity.x += walkSpeed * numberModifyer;
        }
        
    }

    //Wait a few seconds, jumps, attacks during the jump at different heights
    //Debating making the random setters into variables, is that neccessary?
    IEnumerator boulderAttack()
    {   
        walkDuration = Random.Range(0.5f, 1.5f);     //set walk duration
        float AttackWait = Random.Range(.2f, .3f);   // set attack wait duration
        
        _isWalking = true;
        walkTimer = 0;
        Walk(walkSpeed, walkTimer, walkDuration );
        _isThrowing = true;
        _isWalking = false;
        yield return new WaitForSeconds(AttackWait);
        GameObject BoulderClone = Instantiate(Boulder, transform.position, Quaternion.identity);
        _isThrowing = false;
    }

   
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;
    
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
        //
        if (_isGrounded && _isJumping)
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

    IEnumerator JumpAttack()
    {
        _isJumping = true;
        float JumpWait = 3;
        float AttackWait = Random.Range(.2f, .3f);
        yield return new WaitForSeconds(JumpWait);
        Jump(jumpPower);
        yield return new WaitForSeconds(AttackWait);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            GameObject FireballClone = Instantiate(Fireball, transform.position, Quaternion.identity);
        }
    }
}

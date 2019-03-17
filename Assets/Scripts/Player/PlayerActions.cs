using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//handles player actions: absorbing materials, abilities, attacking

public class PlayerActions : MonoBehaviour
{
    private PlayerManager _playerManager;
    
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider;
    
    private Vector2 _inputVector;

    void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
        
        //assign components
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        //reset scene for testing
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
        
        //axis inputs to Vector2
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _inputVector = new Vector2(horizontal, vertical);
    }

    void ThrowMaterialAbsorber()
    {
        
    }
    
    void Attack()
    {
        //MaterialManager.ActiveMaterial.Attack(_inputVector) - something like this?
        //access method from material script
    }
    
    void Special()
    {
        //access method from material script
    }
    
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

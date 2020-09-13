using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _coins;
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private Rigidbody2D _rigidBody;

    private Animator _animator;
    private bool _grounded = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Enemie>())
            transform.position = new Vector3(-8f, -0.2f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
            _coins++;

        if (collision.GetComponent<Floor>())
            _grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Floor>())
            _grounded = false;
    }

    private void FlipX(bool flipX)
    {
        _render.flipX = flipX;
    }

    private void SetAnimation(bool run)
    {
        _animator.SetBool("Run", run);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            FlipX(true);
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            FlipX(false);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && _grounded)
            _rigidBody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            SetAnimation(false);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            SetAnimation(true);
    }
}

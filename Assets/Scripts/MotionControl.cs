using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    private Rigidbody _characterRigitBody;
    [SerializeField] private float _characterSpeed;
    [SerializeField] private float _characterRotationSpeed;
    private AnimationController _characterAnimationController;
    private bool _isGrounded;
    private float _verticalMotion;
    private float _horizontalMotion;

    private float _characterVelocity
    {
        get => _characterRigitBody.velocity.magnitude;
    }

    private Vector3 _direction
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _characterSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterRigitBody = GetComponent<Rigidbody>();
        _characterAnimationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        _verticalMotion = Input.GetAxisRaw("Vertical") * _characterSpeed;
        _horizontalMotion = Input.GetAxisRaw("Horizontal") * _characterRotationSpeed;

        if (_isGrounded)
            _characterAnimationController.WalkAnimation(_characterVelocity * _verticalMotion);
    }

    private void FixedUpdate()
    {
        _characterRigitBody.drag = _verticalMotion > 0 || _verticalMotion < 0 ? 0.8f : 5;

        _characterRigitBody.rotation *= Quaternion.Euler(0, _horizontalMotion, 0);

        _characterRigitBody.AddForce(transform.forward * _verticalMotion, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}

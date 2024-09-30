using System;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody RB;
    AudioSource audioSource;
    [SerializeField] private float Speed;
    [SerializeField] private float speedRotarion;
    [SerializeField] private GameManager gameManager;
    float xdirection;
    float zdirection;
    [Header("Raycast")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce;
    private bool isjump;
    private float rotationy;
    Vector3 moveDirection;
    Vector3 localMoveDirection;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (rotationy != 0)
        {
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.y += rotationy *speedRotarion *Time.deltaTime;
            transform.eulerAngles = currentRotation;
        }
        moveDirection = new Vector3(xdirection, 0, zdirection);
        localMoveDirection = transform.TransformDirection(moveDirection);
    }
    public void XDirection(InputAction.CallbackContext context)
    {
        xdirection = context.ReadValue<float>();
        CheckMovementSound();
    }
    public void Rotation(InputAction.CallbackContext context)
    { 
        rotationy = context.ReadValue<float>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        isjump = context.performed;
    }
    private void CheckMovementSound()
    {
        if ((xdirection != 0 || zdirection != 0) && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (xdirection == 0 && zdirection == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cambiar"))
        {
            gameManager.LoadScene("Game2");
        }
    }
    public void ZDirection(InputAction.CallbackContext context)
    {
        zdirection = context.ReadValue<float>();
        CheckMovementSound();
    }
    private void FixedUpdate()
    {
        RB.velocity = new Vector3(localMoveDirection.x * Speed, RB.velocity.y, localMoveDirection.z * Speed);
        if (Physics.Raycast(transform.position, Vector3.down, 1.03f, groundLayer))
        {
            if (isjump)
            {
                RB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }
}

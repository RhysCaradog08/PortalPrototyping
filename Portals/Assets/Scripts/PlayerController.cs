using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    Transform cam;

    [Header("Movement")]
    float speed;
    public float moveSpeed;
    public Transform pivot;
    public float rotateSpeed;
    Vector3 move;
    Vector3 moveDir;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Jumping")]
    public float jumpSpeed = 5;
    [SerializeField] float gravity = -9.81F;
    [SerializeField] Vector3 velocity;
    public float fallMultiplier = 2;
    public float lowJumpMultiplier = 2.5f;
    bool hasJumped;
    [SerializeField] bool canPressSpace = true;

    private void Start()
    {
        cc = GetComponent<CharacterController>();

        cam = Camera.main.transform;

        speed = moveSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Jump") && !hasJumped) //Check to stop infinite jumping.
        {
            canPressSpace = true;
        }

        if (cc.isGrounded)
        {
            velocity.y = 0f;  //Reverts Players Y position to zero if grounded.

            if (Input.GetButton("Jump") && canPressSpace)  //Sets Y position to match jumpSpeed identifies that player has performed the Jump action.
            {
                velocity.y = jumpSpeed;
                hasJumped = true;
            }

            if (hasJumped)  //Sets Jump animation and prevents player from additional jumps once the Jump action is performed.
            {
                canPressSpace = false;
                hasJumped = false;
            }
   
        }

        if (velocity.y < 0)  //Allows for greater height to be achieved if Jump input is held.
        {
            velocity.y += gravity * (fallMultiplier + 1) * Time.deltaTime;
        }
        else if (velocity.y > 0 && !Input.GetKey(KeyCode.Space))  //Allows for a brief Jump action to be performed.
        {
            velocity.y += gravity * (lowJumpMultiplier + 1) * Time.deltaTime;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        move = new Vector3(horizontal, 0, vertical).normalized;

        if (move.magnitude >= Mathf.Epsilon) //Orients the player to have forward orientation relevant to camera rotation.
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cc.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
    }
}

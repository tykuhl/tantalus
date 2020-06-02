using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;

    public static bool standstill = false;

    Vector3 forward, right;

    Vector3 direction, rightMovement, upMovement, heading;

    private Animator animator;

	// Use this for initialization
	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        getInput();
    }

    private void getInput()
    {
        direction = new Vector3(Input.GetAxis("horizontalKey"), 0, Input.GetAxis("verticalKey"));
        rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("horizontalKey");
        upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("verticalKey");
        heading = Vector3.Normalize(rightMovement + upMovement);

        // getting input for movement
        if (heading != Vector3.zero)
        {
            if (standstill == false)
                Move();
            else
                animator.SetBool("isMoving", false);
        }
        else
            animator.SetBool("isMoving", false);
    }

    void Move()
    {
        animator.SetBool("isMoving", true);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public int speed = 3;
    const float gravity = 9.8f;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    Vector3 moveVector;
    private void MoveCharacter()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal")*speed *Time.deltaTime, 0, Input.GetAxis("Vertical")*speed *Time.deltaTime);
        //moveVector = transform.TransformDirection(moveVector);
        moveVector = transform.localRotation * moveVector;
        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;
        }
        characterController.Move(moveVector);

    }
}

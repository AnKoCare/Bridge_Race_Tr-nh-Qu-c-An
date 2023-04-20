using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider))]
public class PlayerController : Character
{
    // [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] private Animator animator;
    int move;
    


    private void Start() 
    {
        //UIManager.Ins.OpenUI(UIID.MainMenu);
        //Set material
        CodeEnum = 0;
        meshRenderer.material = MaterialTypeManager.instance.Materials[CodeEnum];
        Type = (MaterialType)CodeEnum;

        //Set position
        //gameObject.transform.position = StartPoint.transform.position;
        SetPosition();
        //transform.position = new Vector3(StarPoint.transform.position.x, StarPoint.transform.position.y + 1.6f, StarPoint.transform.position.z);
    }

    private void FixedUpdate()
    {
 
        _characterController.Move(new Vector3(_joystick.Horizontal * _moveSpeed * Time.fixedDeltaTime, _gravity, _joystick.Vertical * _moveSpeed * Time.fixedDeltaTime));
        //animator.SetTrigger("Running");
        //Debug.Log("3");
        // _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            move = 1;
            transform.rotation = Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical));
            animator.SetFloat("Move", Mathf.Abs(move));
        }
        else if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            move = 0;
            animator.SetFloat("Move", Mathf.Abs(move));
        }
    }

    public void SetPosition()
    {
        gameObject.transform.position = StartPoint.transform.position;
    }
}
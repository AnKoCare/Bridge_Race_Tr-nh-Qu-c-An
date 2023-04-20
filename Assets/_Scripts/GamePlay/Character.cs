using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected GameObject BrickBack;
    [SerializeField] protected GameObject Container;
    [SerializeField] protected GameObject StartPoint;
    [SerializeField] protected LayerMask brickStair;
    [SerializeField] private IState<Character> currentState;
    [SerializeField] public int CodeEnum;
    [SerializeField] public int CountSpawnBrick = 0;
    public Ground currentGround;

    public MaterialType Type; //Material cua nhan vat

    public int CountBrickBack = 0; //So luong gach nhan vat an duoc

    private void Awake() 
    {
        brickStair = (1 << LayerMask.NameToLayer("BrickStair"));
    }
    //private void Start() 
    //{
    //    ChangeState(new IdleState());    
    //}

    protected void OnInit()
    {

    }

    protected void Control()
    {

    }
    private void Update() 
    {
        CheckStair();
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    //Add brick
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Brick"))
        {
            Brick brick = other.gameObject.GetComponent<Brick>();
            if(brick != null)
            {
                if(Type == brick.Type)
                {
                    //Deactive Brick
                    currentGround.Despawn(brick);

                    CountBrickBack++; //Tang so luong gach nhan vat an duoc
                    GameObject brickback = Instantiate(BrickBack); //sinh ra vien gach dang sau nhan vat
                    brickback.transform.SetParent(Container.transform);

                    //Set position 
                    brickback.transform.position = new Vector3(Container.transform.position.x, Container.transform.position.y + 0.35f * CountBrickBack, Container.transform.position.z);
                    brickback.transform.localEulerAngles = new Vector3(0,90,0);

                    //Set name
                    brickback.name = "brickback " + (int)Type + " " + CountBrickBack;

                    //Set material
                    Brick brickmaterial = brickback.GetComponent<Brick>();
                    brickmaterial.meshRenderer.material = MaterialTypeManager.instance.Materials[(int)Type];
                    brickmaterial.Type = Type;
                }
            }
        }
    }

    protected void CheckStair()
    {
        Debug.DrawLine(transform.position + Vector3.forward, transform.position + Vector3.forward + Vector3.down, Color.red, 2f);
        if(Physics.Raycast(transform.position + Vector3.forward + Vector3.up, Vector3.down, out RaycastHit stair, Mathf.Infinity, brickStair))
        {
            Collider colliderStair = stair.collider;
            BrickStair brickStair = colliderStair.gameObject.GetComponent<BrickStair>();
            if((Type == brickStair.Type || brickStair.Type == MaterialType.White) && CountBrickBack > 0)
            {
                if(!colliderStair.isTrigger)
                {
                    colliderStair.isTrigger = true;
                }    
            }
            else if(Type != brickStair.Type && CountBrickBack == 0)
            {
                if(colliderStair.isTrigger)
                {
                    colliderStair.isTrigger = false;
                }
            }
            else if(Type != brickStair.Type && CountBrickBack > 0 && !colliderStair.isTrigger)
            {
                colliderStair.isTrigger = true;
            }

        }    
    }

    protected void RemoveBrick()
    {

    }

    protected void ClearBrick()
    {

    }

    protected void Stage()
    {

    }

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public virtual void OnIdleEnter()
    {

    }

    public virtual void OnIdleExecute()
    {

    }

    public virtual void OnIdleExit()
    {
        
    }

    public virtual void OnPatrolEnter()
    {
        
    }

    public virtual void OnPatrolExecute()
    {

    }

    public virtual void OnPatrolExit()
    {

    }

    public virtual void OnClimbEnter()
    {
        
    }

    public virtual void OnClimbExecute()
    {

    }

    public virtual void OnClimbExit()
    {

    }
}

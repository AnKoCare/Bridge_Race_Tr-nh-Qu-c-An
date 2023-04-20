using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] public Transform Cup;
    public float searchRadius = 10f;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] public Animator animator;
    public int move;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //Set position
        gameObject.transform.position = StartPoint.transform.position;

        //Set material
        meshRenderer.material = MaterialTypeManager.instance.Materials[CodeEnum];
        Type = (MaterialType)CodeEnum;
        //ChangeState(new PatrolState());
    }

    private Vector3 SearchBrick()
    {
        List<Brick> brickPos = new List<Brick>();
        if (currentGround.brickground.Count == 0)
        {
            return Vector3.zero;
        }
        for (int i = 0; i < currentGround.brickground.Count; i++)
        {
            if (currentGround.brickground[i].Type == Type && currentGround.brickground[i].gameObject.activeSelf)
            {
                brickPos.Add(currentGround.brickground[i]);
                //return currentGround.brickground[i].transform.position;
            }
        }
        if(brickPos.Count == 0)
        {
            return Vector3.zero;
        }
        float disMin = Vector3.Distance(transform.position, brickPos[0].transform.position);
        int pos = 0;
        for(int i = 0; i < brickPos.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, brickPos[i].transform.position);
            disMin = (distance < disMin) ? distance : disMin;
        }
        for(int i = 0; i < brickPos.Count; i++)
        {
            if(disMin == Vector3.Distance(transform.position, brickPos[i].transform.position))
            {
                pos = i;
            }
        }
        //int randomPos = Random.Range(0, brickPos.Count);
        return brickPos[pos].transform.position;
    }

    public override void OnPatrolEnter()
    {
        targetPosition = transform.position;
    }

    public override void OnPatrolExecute()
    {
        if (Vector3.Distance(targetPosition, transform.position)< 1.2f)
        {
            if (CountBrickBack >= 26)
            {   
                ChangeState(new ClimbState());
                return;
            }
            targetPosition = SearchBrick();
            if (targetPosition.sqrMagnitude != 0)
            {
                // Đặt đích cho AI di chuyển đến vị trí đó
                navMeshAgent.SetDestination(targetPosition);
                move = 1;
                animator.SetFloat("Move", Mathf.Abs(move));
            }
            else
            {
                // Tìm vị trí ngẫu nhiên trên NavMesh
                targetPosition = RandomNavSphere(transform.position, searchRadius, navMeshAgent.areaMask);

                // Đặt đích cho AI di chuyển đến vị trí đó
                navMeshAgent.SetDestination(targetPosition);
                move = 1;
                animator.SetFloat("Move", Mathf.Abs(move));
            }
        }
    }

    public override void OnPatrolExit()
    {

    }

    public override void OnClimbEnter()
    {
        
    }

    public override void OnClimbExecute()
    {
        move = 1;
        navMeshAgent.SetDestination(Cup.transform.position);
        animator.SetFloat("Move", Mathf.Abs(move));
        if(CountBrickBack <= 0)
        {
            ChangeState(new PatrolState());
        }
    }

    public override void OnClimbExit()
    {

    }

    public override void OnIdleEnter()
    {
        base.OnIdleEnter();
    }

    public override void OnIdleExecute()
    {
        //animator.SetFloat("Move", Mathf.Abs(Left_Right));
        base.OnIdleExecute();
    }

    public override void OnIdleExit()
    {
        base.OnIdleExit();
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    public void NewChangeStateBot()
    {
        ChangeState(new PatrolState());
    }
}

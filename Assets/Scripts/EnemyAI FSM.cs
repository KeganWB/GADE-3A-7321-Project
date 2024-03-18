using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform _playerTransform; //Reference to the player's transform
    public Transform _blueFlagTransform; //Reference to the blue flag's transform
    public Transform _redFlagTransform; //Reference to the red flag's transform
    public Transform _blueFlagBaseTransform; //Reference to the blue flag base's transform
    public Transform _redFlagBaseTransform; //Reference to the red flag base's transform

    private NavMeshAgent _navMeshAgent;
    private EnemyState _currentState;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(EnemyState.ChasePlayer); 
    }

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.CarryFlag:
                CarryFlag();
                break;
            case EnemyState.ReturnFlag:
                ReturnFlag();
                break;
        }
    }

    private void Idle()
    {
        //Needs code
    }

    private void ChasePlayer()
    {
        if (_playerTransform != null)
        {
            _navMeshAgent.SetDestination(_playerTransform.position);
        }
    }

    private void CarryFlag()
    {
        if (_redFlagTransform != null)
        {
            _navMeshAgent.SetDestination(_redFlagBaseTransform.position);
        }
    }

    private void ReturnFlag()
    {
        if (_blueFlagTransform != null)
        {
            _navMeshAgent.SetDestination(_blueFlagBaseTransform.position);
        }
    }
    
    //For the enemy AI, need to update code
    public void PickUpRedFlag(Transform flagTransform)
    {
        _redFlagTransform = flagTransform;
        ChangeState(EnemyState.CarryFlag);
    }
    
    public void ReturnBlueFlag()
    {
        ChangeState(EnemyState.ReturnFlag);
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState = newState;
    }
}

public enum EnemyState
{
    Idle,
    ChasePlayer,
    CarryFlag,
    ReturnFlag
}

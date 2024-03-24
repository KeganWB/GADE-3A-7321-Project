using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform _playerTransform;
    public Transform _redFlagTransform;
    public Transform _blueFlagBaseTransform;

    private NavMeshAgent _navMeshAgent;
    private EnemyState _currentState;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(EnemyState.ReturnFlag);
    }

    private void FixedUpdate()
    {
        switch (_currentState)
        {
            case EnemyState.ChasePlayer:
                UpdateChasePlayerState();
                break;
            case EnemyState.ChaseFlag:
                UpdateChaseFlagState();
                break;
            case EnemyState.ReturnFlag:
                UpdateReturnFlagState();
                break;
        }
    }

    private void UpdateChasePlayerState()
    {
        ChasePlayer();
        if (ShouldSwitchToChaseFlag())
        {
            ChangeState(EnemyState.ChaseFlag);
        }
    }

    private void UpdateChaseFlagState()
    {
        ChaseFlag();
        if (ShouldSwitchToReturnFlag())
        {
            ChangeState(EnemyState.ReturnFlag);
        }
    }

    private void UpdateReturnFlagState()
    {
        ReturnFlag();
        if (ShouldSwitchToChasePlayer())
        {
            ChangeState(EnemyState.ChasePlayer);
        }
    }

    private void ChasePlayer()
    {
        if (_playerTransform != null)
        {
            _navMeshAgent.SetDestination(_playerTransform.position);
        }
    }

    private void ChaseFlag()
    {
        if (_redFlagTransform != null)
        {
            _navMeshAgent.SetDestination(_redFlagTransform.position);
        }
        
    }

    private void ReturnFlag()
    {
        Debug.Log("returning");
        if (_blueFlagBaseTransform != null)
        {
            Debug.Log("super return");
            _navMeshAgent.SetDestination(_blueFlagBaseTransform.position);
        }
    }

    private bool ShouldSwitchToChaseFlag()
    {
        //If the enemy is close to the red flag
        return Vector3.Distance(transform.position, _redFlagTransform.position) < 5f;
    }

    private bool ShouldSwitchToReturnFlag()
    {
        //If the red flag is picked up
        return _redFlagTransform != null && _redFlagTransform.parent == transform;
    }

    private bool ShouldSwitchToChasePlayer()
    {
        //If the enemy has the red flag and is far from the blue flag base
        return _redFlagTransform != null && Vector3.Distance(transform.position, _blueFlagBaseTransform.position) > 5f;
    }

    private void ChangeState(EnemyState newState)
    {
        Debug.Log("Changing state from " + _currentState + " to " + newState);
        _currentState = newState;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.CompareTag("RedFlag"))
        {
            GameManager.Instance.EnemyPickedUpRedFlag(other.gameObject);
            ChangeState(EnemyState.ReturnFlag);
           
            Debug.Log("collided with red flag");
            //PickUpRedFlag(other.transform);
        }

       
        if (other.CompareTag("Player") && GameManager.Instance._blueFlagPickedUp)
        {
            Debug.Log("Collided with player carrying blue flag");

            //Unparent the blue flag from the player
            GameManager.Instance._blueFlag.transform.parent = null;

            //Reset _blueFlagPickedUp to false
            GameManager.Instance._blueFlagPickedUp = false;

            //Move the blue flag back to its original position
            GameManager.Instance._blueFlag.transform.position = GameManager.Instance._blueFlagBasePosition.position;
            GameManager.Instance._blueFlag.transform.rotation = GameManager.Instance._blueFlagBasePosition.rotation;
        }
        
        if (other.CompareTag("BlueFlagBase") && GameManager.Instance._redFlagPickedUp)
        {
            
            GameManager.Instance.EnemyReturnedRedFlagAtBase();
            ChangeState(EnemyState.ChasePlayer);
        }
        
        
    }

}

public enum EnemyState
{
    ChasePlayer,
    ChaseFlag,
    ReturnFlag
}

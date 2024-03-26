using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform _playerTransform;
    public Transform _redFlagTransform;
    public Transform _blueFlagBaseTransform;

    private NavMeshAgent _navMeshAgent;
    private EnemyState _currentState;

    public bool _isRedFlagPickedUp;
    public bool _isBlueFlagPickedUp;

    public bool _redFlagIsDropped  = false;
    public bool _blueFlagIsDropped = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(EnemyState.ChaseFlag);
    }

    private void Update()
    {
        _isRedFlagPickedUp = GameManager.Instance._redFlagPickedUp;
        _isBlueFlagPickedUp = GameManager.Instance._blueFlagPickedUp;

        switch (_currentState)
        {
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;

            case EnemyState.ChaseFlag:
                ChaseFlag();
                break;

            case EnemyState.ReturnFlag:
                ReturnFlag();
                break;
        }

        UpdateState();
    }

    private void UpdateState()
    {
        if (_currentState == EnemyState.ChasePlayer && ShouldSwitchToChaseFlag())
        {
            ChangeState(EnemyState.ChaseFlag);
        }
            
        else if (_currentState == EnemyState.ChaseFlag && ShouldSwitchToReturnFlag())
        {
            ChangeState(EnemyState.ReturnFlag);
        }
            
        else if (_currentState == EnemyState.ReturnFlag && ShouldSwitchToChasePlayer())
        {
            ChangeState(EnemyState.ChasePlayer);
        }
        else if (_currentState == EnemyState.ReturnFlag && ShouldSwitchToChaseFlag())
        {
            ChangeState(EnemyState.ChaseFlag);
        }
            
        else if (_currentState == EnemyState.ChaseFlag && ShouldSwitchToChasePlayer())
        {
            ChangeState(EnemyState.ChasePlayer);
        }
        else if (_currentState == EnemyState.ChasePlayer && ShouldSwitchToReturnFlag())
        {
            ChangeState(EnemyState.ReturnFlag);
        }
    }

    private void ChasePlayer()
    {
        
        _navMeshAgent.SetDestination(GameManager.Instance._blueFlag.transform.position);
        
    }

    private void ChaseFlag()
    {
        if (_redFlagTransform != null && !_isRedFlagPickedUp && !_isBlueFlagPickedUp)
            _navMeshAgent.SetDestination(_redFlagTransform.position);
    }

    private void ReturnFlag()
    {
        if (_blueFlagBaseTransform != null && _isRedFlagPickedUp)
            _navMeshAgent.SetDestination(_blueFlagBaseTransform.position);
        
    }

    private bool ShouldSwitchToChaseFlag()
    {
        if (!_isBlueFlagPickedUp && !_isRedFlagPickedUp)
        {
            return true;
        }

        return false;
    }

    private bool ShouldSwitchToReturnFlag()
    {
        //distances for base and player
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        float distanceToBase = Vector3.Distance(transform.position, _blueFlagBaseTransform.position);
       
        
        //Check if both flags are picked up and the enemy is closer to the base than the player
        if (_isRedFlagPickedUp && _isBlueFlagPickedUp && distanceToBase < distanceToPlayer)
            
        {
            return true;
        }

        if (_isRedFlagPickedUp && !_isBlueFlagPickedUp)
        {
            return true;
        }

        return false;

        
    }


    private bool ShouldSwitchToChasePlayer()
    {
        //distances for base and player
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
        float distanceToBase = Vector3.Distance(transform.position, _blueFlagBaseTransform.position);
        
        //Check if the enemy is closer to the player than the base
        if (_isRedFlagPickedUp && _isBlueFlagPickedUp && distanceToPlayer < distanceToBase)
        {
            return true;
            
        }
        if (_blueFlagIsDropped)
        {
            return true;
            
        }
        
        if (_isBlueFlagPickedUp)
        {
            return true;
        }

        return false;
    }

    private void ChangeState(EnemyState newState)
    {
        _currentState = newState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFlag"))
        {
            Debug.Log("Picked up red flag"); 
            GameManager.Instance.EnemyPickedUpRedFlag(other.gameObject);
            _isRedFlagPickedUp = true;
           
        }

        if (other.CompareTag("Player") && _isBlueFlagPickedUp)
        {
            Debug.Log("smashed player"); 
            GameManager.Instance._blueFlag.transform.parent = null;
            GameManager.Instance._blueFlagPickedUp = false;
            _isBlueFlagPickedUp = false;
            _blueFlagIsDropped = true;
            
            GameManager.Instance._blueFlag.transform.position = GameManager.Instance._blueFlagDropped.transform.position;
            GameManager.Instance._blueFlag.transform.rotation = GameManager.Instance._blueFlagDropped.transform.rotation;
            
            
        }

        if (other.CompareTag("Player") && _isRedFlagPickedUp)
        {
            Debug.Log("Dropped red flag"); 
            GameManager.Instance._redFlag.transform.parent = null;
            GameManager.Instance._redFlagPickedUp = false;
            _isRedFlagPickedUp = false;
            _redFlagIsDropped = true;
            GameManager.Instance._redFlag.transform.position = GameManager.Instance._redFlagDropped.position;
            GameManager.Instance._redFlag.transform.rotation = GameManager.Instance._redFlagDropped.rotation;
            
        }

        if (other.CompareTag("BlueFlagBase") && _isRedFlagPickedUp)
        {
            GameManager.Instance.EnemyReturnedRedFlagAtBase();
            _isRedFlagPickedUp = false;
        }
        if (other.CompareTag("BlueFlag") && _blueFlagIsDropped)
        {
            Debug.Log("Returned blue flag"); 
            GameManager.Instance._blueFlag.transform.parent = null;
            GameManager.Instance._blueFlagPickedUp = false;
            _isBlueFlagPickedUp = false;
            _blueFlagIsDropped = false;
            
            GameManager.Instance._blueFlag.transform.position = GameManager.Instance._blueFlagBasePosition.transform.position;
            GameManager.Instance._blueFlag.transform.rotation = GameManager.Instance._blueFlagBasePosition.transform.rotation;
            
            
        }
        
        
    }
}

public enum EnemyState
{
    ChasePlayer,
    ChaseFlag,
    ReturnFlag
}


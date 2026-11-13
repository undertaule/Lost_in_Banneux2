using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    Patrolling,
    Following,
}
public class EnemiController : MonoBehaviour
{
    [Header("Reference")] 
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] patrolPoints;
    
    [Header("Settings")]
    [SerializeField] private float patrolWaitTime = 1f;
    [SerializeField] private float stopAtDistance = 2.5f;
    [SerializeField] private float detectionRange = 50f;
    [SerializeField] private float viewAngle = 100f;
    [SerializeField] private float losePlayerTime = 10f;
    
    

    private NavMeshAgent _agent;
    private int _currentPatrolIndex;
    private bool _isWaiting;
    private EnemyState _state = EnemyState.Patrolling;
    private float _timeSinceLostplayer;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        GoToNextPoint();
    }

    private void Update()
    {

        var distanceToPlayer = Vector3.Distance(player.position, transform.position);
        switch (_state)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (distanceToPlayer <= detectionRange && CanSeePlayer())
                {
                    Debug.Log("Passage en FOLLOWING");
                    _state = EnemyState.Following;
                }

                break;
            
            case EnemyState.Following:
                FollowPlayer();
                if (!CanSeePlayer())
                {
                    _timeSinceLostplayer += Time.deltaTime;
                    if (_timeSinceLostplayer >= patrolWaitTime)
                    {
                        _state = EnemyState.Patrolling;
                        GoToClosestPatrolPoint();
                    }
                }
                else
                {
                    _timeSinceLostplayer = 0f;
                }

                break;

        }
        
    }

    private void FollowPlayer()
    {
        Debug.Log("FollowPlayer exécuté");
        _agent.SetDestination(player.position);
        Debug.Log("Destination : " + _agent.destination);
        Debug.Log("Stopped : " + _agent.isStopped);
        Debug.Log("HasPath : " + _agent.hasPath);

    }
    private void Patrol()
    {
        if (_isWaiting) return;
        if (!_agent.pathPending && _agent.remainingDistance <= stopAtDistance)
        {
            StartCoroutine(WaitAtPatrolPoint());
        }
    }

    private IEnumerator WaitAtPatrolPoint()
    {
        _isWaiting = true;
        _agent.isStopped = true;
        
        yield return new WaitForSeconds(patrolWaitTime);
        
        _agent.isStopped = false;
        GoToNextPoint();
        _isWaiting = false;
        
    }

    private void GoToClosestPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        var closestIndex = 0;
        var closestDistance = float.MaxValue;

        for (var i = 0; i < patrolPoints.Length; i++)
        {
            var distance = Vector3.Distance(player.position, patrolPoints[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }
        _currentPatrolIndex = closestIndex;
        _agent.SetDestination(patrolPoints[_currentPatrolIndex].position);
        
    }

    private void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;
        
        _agent.SetDestination(patrolPoints[_currentPatrolIndex].position);
        _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Length;
        
    }

    private bool CanSeePlayer()
    {
        bool facing = IsFacingPlayer();
        bool clear = HasClearPathToPlayer();

       

        return facing && clear;
    }

    private bool IsFacingPlayer()
    {
        var dirToPlayer = (player.position - transform.position).normalized;
        var angle = Vector3.Angle(transform.forward, dirToPlayer);

        

        return angle < viewAngle / 2f;
        
    }

    private bool HasClearPathToPlayer()
    {
        var dirToPlayer = player.position - transform.position;

        if (Physics.Raycast(transform.position, dirToPlayer.normalized, out RaycastHit hit, dirToPlayer.magnitude))
        {
            
            
            return hit.transform == player;
        }

        Debug.Log("Rien touché");
        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        Debug.Log("Le joueur est mort !");

        // Désactive le joueur
        player.gameObject.SetActive(false);

        // Ou charge un écran de Game Over
        // SceneManager.LoadScene("GameOver");
    }
}

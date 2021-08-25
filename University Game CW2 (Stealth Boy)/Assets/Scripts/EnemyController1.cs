using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController1 : MonoBehaviour
{
    // Enemy controller for the Runner enemy type.
    #region Editor Fields

    [Header("General")]
    [SerializeField]
    private GameController gameController;

    [Header("Candidates")]
    [SerializeField]
    private float fieldOfViewAngle = 20;

    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private LayerMask obstacleLayerMask;

    #endregion

    #region Private Fields

    private SphereCollider candidateSphereCollider;
    private readonly List<GameObject> candidates = new List<GameObject>();
    private GameObject target;

    #endregion

    #region Public Properties
    
    public bool IsTarget => target != null;
    
    // todo: change to property
    public Waypoint waypoint;

    // todo: change to property
    public StateMachine stateMachine = new StateMachine();
    
    // todo: change to property
    public Vector3 lastSeenPosition;
    
    public float SearchTime = 10f;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        // Getting the collider of the the Enemy object. 
        candidateSphereCollider = GetComponent<SphereCollider>();
        if (gameController == null)
        {
            gameController = FindObjectOfType<GameController>();
        }
    }

    private void Start()
    {
        //Starting the state AI state machine with the patrol state.
        stateMachine.ChangeState(new State_Patrol(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void OnDisable()
    {
        // Clearing the possible candidate that could be tracked by the enemy. This is so
        // I may use this in the future to track multiple players.
        candidates.Clear();
    }

    private void OnDrawGizmos()
    {
        // Drawing gizmos for candidate detection and drawing gizmos for candidate that is being chased.  
        Gizmos.color = Color.blue;
        if (lastSeenPosition != Vector3.zero)
        {
            Gizmos.DrawWireSphere(lastSeenPosition, 1.0f);
        }

        var enemyTransform = transform;
        var enemyUp = enemyTransform.up;
        var enemyForward = enemyTransform.forward;
        var enemyPosition = enemyTransform.position;

        if (candidateSphereCollider == null)
        {
            candidateSphereCollider = GetComponent<SphereCollider>();
        }

        var maxRadius = candidateSphereCollider.radius + 0.7f;

        var leftAngle = Quaternion.AngleAxis(fieldOfViewAngle, enemyUp) * enemyForward * maxRadius;
        var rightAngle = Quaternion.AngleAxis(-fieldOfViewAngle, enemyUp) * enemyForward * maxRadius;

        Gizmos.DrawRay(enemyPosition, leftAngle);
        Gizmos.DrawRay(enemyPosition, rightAngle);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Adding player to the candidate list if he is in the collider of the enemy.
        if (IsPlayer(other))
        {
            candidates.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Removing the player from possible candidates to chance if he exits the collider.
        if (IsPlayer(other))
        {
            var playerGameObject = other.gameObject;
            if (candidates.Remove(playerGameObject) && playerGameObject == target)
            {
                target = null;
            }
        }
    }

    private void FixedUpdate()
    {
        // Checking which one of the candidates is within the field of view of the enemy.
        FindTargetFromCandidates();
    }

    #endregion

    #region Public Methods

    // todo: delete
    public void RedLightOn()
    {
        // Turning on the red spot light when player is seen.
        gameController.IncrementSpotted();
    }

    // todo: delete
    public void RedLightOff()
    {
        // Red light off when in search state.
        gameController.DecrementSpotted();
    }

    // todo: delete
    public void GreenLightOn()
    {
        // Green light on when in search state.
        gameController.IncrementSearching();
    }

    // todo: delete
    public void GreenLightOff()
    {
        // Green light off when enemy is going back to patrol.
        gameController.DecrementSearching();
    }

    #endregion

    #region Private Methdos

    private void FindTargetFromCandidates()
    {
        // Checking which one of the candidates is within the field of view of the enemy.
        var enemyTransform = transform;
        var enemyDirection = enemyTransform.forward;
        var enemyPosition = enemyTransform.position;

        target = null;

        foreach (var candidate in candidates)
        {
            var candidatePosition = candidate.transform.position;
            var candidateDirection = (candidatePosition - enemyPosition).normalized;

            if (!IsInFieldOfView(enemyDirection, candidateDirection))
            {
                continue;
            }

            if (!IsVisible(enemyPosition, candidatePosition, out var hit))
            {
                continue;
            }

            if (IsPlayer(hit.collider))
            {
                lastSeenPosition = candidatePosition;
                target = candidate;

                Debug.DrawLine(enemyPosition, candidatePosition, Color.green);
            }
            else
            {
                Debug.DrawLine(enemyPosition, candidatePosition, Color.red);
            }
        }
    }

    private bool IsInFieldOfView(Vector3 enemyDirection, Vector3 candidateDirection)
    {
        return Vector3.Angle(enemyDirection, candidateDirection) <= fieldOfViewAngle;
    }

    private bool IsVisible(Vector3 enemyPosition, Vector3 candidatePosition, out RaycastHit hit)
    {
        // Checking if the player is not blocked by any objects like walls.
        return Physics.Linecast(
            enemyPosition,
            candidatePosition,
            out hit,
            obstacleLayerMask,
            QueryTriggerInteraction.Ignore
        );
    }

    private bool IsPlayer(Component component)
    {
        // Checking if the object that enter the collider has the player tag.
        return component.CompareTag(playerTag);
    }

    #endregion
}

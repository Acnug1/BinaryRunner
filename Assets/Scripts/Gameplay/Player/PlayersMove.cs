using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(200)]

public class PlayersMove : MonoBehaviour
{
    [Tooltip("Скорость движения вперед")]
    [Min(1f)]
    [SerializeField] private float _moveForwardSpeed = 100f;

    private Player[] _players;
    private Rigidbody[] _rigidbodies;
    private Coroutine _moveForward;

    private void Awake()
    {
        _players = GetComponentsInChildren<Player>();
    }

    private void Start()
    {
        _rigidbodies = GetRigidbodiesOfPlayers(_players);
        StartMoveForward(_rigidbodies);
    }

    private Rigidbody[] GetRigidbodiesOfPlayers(Player[] players)
    {
        var rigidbodies = new List<Rigidbody>();

        foreach (Player player in players)
        {
            rigidbodies.Add(player.GetComponent<Rigidbody>());
        }

        return rigidbodies.ToArray();
    }

    private void StartMoveForward(Rigidbody[] rigidbodies)
    {
        if (_moveForward != null)
            StopCoroutine(_moveForward);

        _moveForward = StartCoroutine(MoveForward(rigidbodies));
    }

    private IEnumerator MoveForward(Rigidbody[] rigidbodies)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        yield return waitForFixedUpdate;

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.velocity = Vector3.forward * _moveForwardSpeed * Time.fixedDeltaTime;
        }
    } 
}

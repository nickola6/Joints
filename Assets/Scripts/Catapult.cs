using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spoon _spoon;
    [SerializeField] private ProjectileSpawner _projectileSpawner;

    private State _state;

    private enum State
    {
        Waiting,
        Fired,
        Returning
    }

    private void OnEnable()
    {
        _inputReader.CatapultFirePressed += OnFirePressed;
        _inputReader.CatapultResetPressed += OnResetPressed;
    }

    private void OnDisable()
    {
        _inputReader.CatapultFirePressed -= OnFirePressed;
        _inputReader.CatapultResetPressed -= OnResetPressed;
    }

    private void Start()
    {
        _projectileSpawner.Spawn();
        _state = State.Waiting;
    }

    private void FixedUpdate()
    {
        if (_state != State.Returning || _spoon.IsInitPosition == false)
            return;

        _projectileSpawner.Spawn();
        _state = State.Waiting;
    }

    private void OnFirePressed()
    {
        if (_state != State.Waiting)
            return;

        _spoon.Fire();
        _state = State.Fired;
    }

    private void OnResetPressed()
    {
        if (_state != State.Fired)
            return;

        _projectileSpawner.Despawn();
        _spoon.ReturnToRest();
        _state = State.Returning;
    }
}
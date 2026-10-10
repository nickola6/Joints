using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;

    private Rigidbody _projectile;

    public void Spawn()
    {
        _projectile = Instantiate(_prefab, transform.position, transform.rotation);
    }

    public void Despawn()
    {
        Destroy(_projectile.gameObject);
        _projectile = null;
    }
}
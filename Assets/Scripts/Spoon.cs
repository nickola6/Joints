using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SpringJoint))]
public class Spoon : MonoBehaviour
{
    [SerializeField] private float _rotationTolerance = 1f;
    [SerializeField] private float _angularVelocityTolerance = 0.05f;

    private Rigidbody _rigidbody;
    private SpringJoint _springJoint;
    private Quaternion _initRotation;
    private Vector3 _initAnchorPosition;
    private Vector3 _launchAnchorPosition;

    public bool IsInitPosition => Quaternion.Angle(_rigidbody.rotation, _initRotation) <= _rotationTolerance &&
        _rigidbody.angularVelocity.sqrMagnitude <= _angularVelocityTolerance * _angularVelocityTolerance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();

        _springJoint.connectedBody = null;
        _springJoint.autoConfigureConnectedAnchor = false;

        _launchAnchorPosition = _springJoint.connectedAnchor;
        _initAnchorPosition = transform.TransformPoint(_springJoint.anchor);

        _springJoint.minDistance = 0f;
        _springJoint.maxDistance = 0f;
        _springJoint.connectedAnchor = _initAnchorPosition;

        _rigidbody.centerOfMass = Vector3.zero;
        _initRotation = _rigidbody.rotation;
    }

    public void Fire()
    {
        _springJoint.connectedAnchor = _launchAnchorPosition;
    }

    public void ReturnToRest()
    {
        _springJoint.connectedAnchor = _initAnchorPosition;
    }
}
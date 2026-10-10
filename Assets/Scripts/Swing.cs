using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _pushPower = 100f;
    
    private Rigidbody _rigidbody;
    private HingeJoint _hingeJoint;
    private bool _isPushed;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void OnEnable()
    {
        _inputReader.SwingPressed += OnSwingPressed;
    }

    private void OnDisable()
    {
        _inputReader.SwingPressed -= OnSwingPressed;
    }

    private void FixedUpdate()
    {
        if (_isPushed == false)
            return;

        _isPushed = false;
        _rigidbody.AddRelativeTorque(_hingeJoint.axis * _pushPower, ForceMode.Force);
    }

    private void OnSwingPressed()
    {
        _isPushed = true;
    }
}
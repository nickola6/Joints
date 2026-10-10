using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _swingKey = KeyCode.S;
    [SerializeField] private KeyCode _catapultFireKey = KeyCode.F;
    [SerializeField] private KeyCode _catapultResetKey = KeyCode.R;

    public event Action SwingPressed;
    public event Action CatapultFirePressed;
    public event Action CatapultResetPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_swingKey))
            SwingPressed?.Invoke();

        if (Input.GetKeyDown(_catapultFireKey))
            CatapultFirePressed?.Invoke();

        if (Input.GetKeyDown(_catapultResetKey))
            CatapultResetPressed?.Invoke();
    }
}
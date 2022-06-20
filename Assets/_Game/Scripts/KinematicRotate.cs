using UnityEngine;

public class KinematicRotate : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private ForceMode forceMode;
    private Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddTorque(0, 0, speed, forceMode);
    }
}

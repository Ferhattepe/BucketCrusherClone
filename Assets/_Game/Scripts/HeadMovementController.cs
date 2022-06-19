using UnityEngine;

public class HeadMovementController : MonoBehaviour
{
    public Rigidbody targetBody;
    public Joystick joystick;
    public float forceSpeed;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            targetBody.velocity = new Vector3(joystick.Horizontal, joystick.Vertical, 0) * forceSpeed;
        }
        else
        {
            targetBody.velocity = Vector3.zero;
        }

    }
}

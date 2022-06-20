using UnityEngine;

public class ActivatePhysics : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Head"))
        {
            Active();
            gameObject.tag = "Touched";
        }
        else if (other.collider.CompareTag("Touched"))
        {
            Active();
        }
    }

    private void Active()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
    }
}

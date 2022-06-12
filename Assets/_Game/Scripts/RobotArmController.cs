using System.Collections.Generic;
using UnityEngine;

public class RobotArmController : MonoBehaviour
{
    public HingeJoint stickPrefab;
    public HingeJoint fixJoint;
    public Rigidbody headBody;
    public int stickCount;
    public List<HingeJoint> currentSticks;
    private void Awake()
    {
        if (currentSticks.Count < stickCount)
        {
            var needStickAmount = stickCount - currentSticks.Count;
            for (var i = 0; i < needStickAmount; i++)
            {
                var stick = Instantiate(stickPrefab, transform);
                if (currentSticks.Count > 0)
                {
                    var lastStick = currentSticks[currentSticks.Count - 1];
                    lastStick.connectedBody = stick.GetComponent<Rigidbody>();
                }
                currentSticks.Add(stick);
            }
            fixJoint.connectedBody = currentSticks[0].GetComponent<Rigidbody>();
            currentSticks[currentSticks.Count - 1].connectedBody = headBody;
            headBody.position = fixJoint.transform.position + Vector3.up * currentSticks.Count;
        }
    }
}

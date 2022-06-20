using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;
using System;

public class RobotArmController : MonoBehaviour
{
    public HingeJoint stickPrefab;
    public HingeJoint fixJoint;
    public Rigidbody headBody;
    public IntReference stickCount;
    private List<HingeJoint> _currentSticks;

    private void Awake()
    {
        _currentSticks = new List<HingeJoint>();
        AddSticks(stickCount);
        SetConfigurations();
    }

    private void SetConfigurations()
    {
        fixJoint.connectedBody = _currentSticks[0].GetComponent<Rigidbody>();
        _currentSticks[_currentSticks.Count - 1].connectedBody = headBody;
        headBody.position = fixJoint.transform.position + Vector3.up * _currentSticks.Count;
    }

    public void OnStickCountChanged()
    {
        var amount = stickCount - _currentSticks.Count;
        if (amount > 0)
        {
            AddSticks(amount);
        }
        else if (amount < 0)
        {
            RemoveSticks(amount);
        }

        SetConfigurations();
    }

    private void RemoveSticks(int amount)
    {
        amount = Math.Abs(amount);
        for (var i = 0; i < amount; i++)
        {
            var stick = _currentSticks[0];
            _currentSticks.RemoveAt(0);
            Destroy(stick.gameObject);
        }
    }

    private void AddSticks(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            var stick = Instantiate(stickPrefab, transform);
            if (_currentSticks.Count > 0)
            {
                var lastStick = _currentSticks[_currentSticks.Count - 1];
                lastStick.connectedBody = stick.GetComponent<Rigidbody>();
            }
            _currentSticks.Add(stick);
        }
    }
}

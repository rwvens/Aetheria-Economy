﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using static Unity.Mathematics.math;

public class VelocityMatch : AgentBehavior
{
    public event Action OnMatch;
    public float2 TargetVelocity;
    private Thruster _thrust;
    private Turning _turning;
    private const float TargetThreshold = .1f;

    private ItemManager _context;

    public VelocityMatch(ItemManager context, Entity entity, ControllerData controllerData) : base(context, entity, controllerData)
    {
        _context = context;
        _thrust = Entity.GetBehavior<Thruster>();
        _turning = Entity.GetBehavior<Turning>();
    }

    public void Clear()
    {
        OnMatch = null;
    }
    
    public override void Update(float delta)
    {
        if (_thrust != null && _turning != null)
        {
            var deltaV = TargetVelocity - Entity.Velocity;
            if(length(deltaV) < TargetThreshold)
                OnMatch?.Invoke();
            _turning.Axis = TurningInput(deltaV);
            _thrust.Axis = ThrustInput(deltaV);
        }
    }
    
    public float2 MatchDistanceTime
    {
        get
        {
            var velocity = length(Entity.Velocity);
            var deltaV = TargetVelocity - Entity.Velocity;
            
            var stoppingTime = length(deltaV) / (_thrust.Thrust / Entity.Mass);
            var stoppingDistance = stoppingTime * (velocity / 2);
            
            var angleDiff = Entity.Direction.AngleDiff(deltaV);
            var turnaroundTime = angleDiff / (_turning.Torque / Entity.Mass);
            var turnaroundDistance = turnaroundTime * velocity;
            
            return float2(stoppingDistance + turnaroundDistance, stoppingTime + turnaroundTime);
        }
    }
}

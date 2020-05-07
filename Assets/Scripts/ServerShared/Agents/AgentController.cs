﻿// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using static Unity.Mathematics.math;
// using Random = Unity.Mathematics.Random;
//
// public class AgentController
// {
//     public Guid Entity { get; }
//     public EntityAgent EntityAgent { get; }
//     public GameContext Context { get; }
//     public Guid Zone { get; set; }
//
//     private Locomotion _locomotion;
//     private VelocityMatch _velocityMatch;
//     private Random _random = new Random((uint) (DateTime.Now.Ticks%uint.MaxValue));
//     private Guid _targetOrbit;
//
//     public AgentController(GameContext context, Guid zone, Guid entity)
//     {
//         Entity = entity;
//         Zone = zone;
//         Context = context;
//         EntityAgent = new EntityAgent(context, entity, zone, Guid.Empty);
//         _locomotion = new Locomotion(context, entity);
//         _velocityMatch = new VelocityMatch(context, entity);
//         _velocityMatch.OnMatch += () =>
//         {
//             EntityAgent.CurrentBehavior = _locomotion;
//             RandomTarget();
//         };
//         EntityAgent.CurrentBehavior = _locomotion;
//         RandomTarget();
//     }
//
//     public void Update(float delta)
//     {
//         EntityAgent.Update(delta);
//         // Context.Log(
//         //     $"Agent Mode: {EntityAgent.CurrentBehavior.GetType()} " +
//         //     $"Agent Distance: {distance} " +
//         //     $"Turnaround Distance: {_stoppingDistance + _turnaroundDistance} " +
//         //     $"Objective: {_objective.Key.ID.ToString().Substring(0, 8)}");
//         var entity = Context.Cache.Get<Entity>(Entity);
//
//         if (EntityAgent.CurrentBehavior == _locomotion)
//         {
//             var orbitData = Context.Cache.Get<OrbitData>(_targetOrbit);
//             _velocityMatch.TargetOrbit = _targetOrbit;
//             var matchDistanceTime = _velocityMatch.MatchDistanceTime;
//             _locomotion.Objective = Context.GetOrbitPosition(_targetOrbit) + Context.GetOrbitVelocity(_targetOrbit) * matchDistanceTime.y;
//             var distance = length(_locomotion.Objective - entity.Position);
//             if (distance < matchDistanceTime.x)
//                 EntityAgent.CurrentBehavior = _velocityMatch;
//         }
//     }
//
//     private void RandomTarget()
//     {
//         var entities = Context.ZonePlanets[Zone];
//         _targetOrbit = Context.Cache.Get<PlanetData>(entities[_random.NextInt(entities.Length)]).Orbit;
//     }
// }

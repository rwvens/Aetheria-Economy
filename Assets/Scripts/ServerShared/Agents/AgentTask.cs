﻿using System;
using System.Collections;
using System.Collections.Generic;
using JsonKnownTypes;
using MessagePack;
using Newtonsoft.Json;
using UnityEngine;

[MessagePackObject, 
 Union(0, typeof(StationTowing)),
 Union(1, typeof(Mining)),
 Union(2, typeof(Survey)),
 Union(3, typeof(HaulingTask)),
 JsonObject(MemberSerialization.OptIn), JsonConverter(typeof(JsonKnownTypesConverter<DatabaseEntry>))]
public abstract class AgentTask : DatabaseEntry
{
    [JsonProperty("priority"), Key(1)]
    public int Priority;
    
    [JsonProperty("zone"), Key(2)]
    public Guid Zone;
    
    [JsonProperty("reserved"), Key(3)]
    public bool Reserved;
    
    [IgnoreMember] public abstract TaskType Type { get; }
}

public enum TaskType
{
    None,
    Mine,
    Haul,
    Tow,
    Defend,
    Attack,
    Explore
}

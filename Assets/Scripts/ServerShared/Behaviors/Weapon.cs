/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using MessagePack;
using Newtonsoft.Json;

[Union(0, typeof(ProjectileWeaponData)),
 Union(1, typeof(LauncherData))]
public abstract class WeaponData : BehaviorData
{
    [InspectableField, JsonProperty("damageType"), Key(1)]
    public DamageType DamageType;

    [InspectableField, JsonProperty("damage"), Key(2)]
    public PerformanceStat Damage = new PerformanceStat();

    [InspectableField, JsonProperty("range"), Key(3)]
    public PerformanceStat Range = new PerformanceStat();

    [InspectableField, JsonProperty("burstCount"), Key(4)]
    public int BurstCount;

    [InspectableField, JsonProperty("burstTime"), Key(5)]
    public PerformanceStat BurstTime = new PerformanceStat();
}
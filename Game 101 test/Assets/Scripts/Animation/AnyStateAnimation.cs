using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RIG { BODY, LEGS, ARMS }

public class AnyStateAnimation
{
    public RIG AnimationRig { get; private set; }

    public string Name { get; set; }

    public bool Active { get; set; }

    public AnyStateAnimation(RIG rig, string name)
    {
        AnimationRig = rig;
        Name = name;
    }

    public AnyStateAnimation(string name)
    {
        Name = name;
    }
}

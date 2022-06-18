using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HouseAnimatorController
{
    public static class Params 
    {
        public const string IsThiefInsideHouse = nameof(IsThiefInsideHouse);
    }

    public static class States
    {
        public const string Idle = nameof(Idle); 
        public const string Run = nameof(Run);
    }
}
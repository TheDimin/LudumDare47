using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD47
{
    namespace Minigame
    {
        public enum ModuleType
        {
            None,
            Triangle,
            Circle,
            Diamond,
        }
        
        [System.Serializable]
        public class Module
        {
            public ModuleType type = ModuleType.Triangle;

            public int north;
            public int east;
            public int south;
            public int west;
        }
    }
}


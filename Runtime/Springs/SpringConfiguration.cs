using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Snowdrama.Spring
{
    [CreateAssetMenu(fileName = "Spring", menuName = "Snowdrama/Springs/SpringConfigurationObject", order = 1)]
    public class SpringConfiguration : ScriptableObject
    {
        public float Mass = 1f;
        public float Tension = 170f;
        public float Friction = 26f;
        public float Precision = 0.01f;
        public bool Clamp = true;
    }
}

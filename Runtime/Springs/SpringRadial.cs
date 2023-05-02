using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.Spring
{
    public class SpringRadial
    {
        SpringList springCollection;
        int ID;

        public float Value
        {
            get
            {
                return springCollection.GetValue(ID);
            }
            set
            {
                springCollection.SetValue(ID, value);
            }
        }
        public float Target
        {
            get
            {
                return springCollection.GetTarget(ID);
            }
            set
            {
                value %= 360;
                var delta = Mathf.DeltaAngle(springCollection.GetValue(ID), value);
                springCollection.SetTarget(ID, springCollection.GetValue(ID) + delta);
            }
        }
        public float Velocity
        {
            get
            {
                return springCollection.GetVelocity(ID);
            }
            set
            {
                springCollection.SetVelocity(ID, value);
            }
        }

        public SpringConfiguration SpringConfig
        {
            set
            {
                springCollection.SetSpringConfig(ID, value);
            }
        }

        public SpringRadial(SpringConfiguration config, float initialValue = default)
        {
            springCollection = new SpringList(1);
            ID = springCollection.Add(initialValue, config);
        }

        public void Update(float deltaTime)
        {
            springCollection.Update(deltaTime);
        }
    }
}
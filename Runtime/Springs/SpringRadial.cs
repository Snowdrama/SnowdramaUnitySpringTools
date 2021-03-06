using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.Spring
{
    public class SpringRadial
    {
        private SpringConfigurationData _spring;
        private SpringState _state;
        public SpringRadial(SpringConfiguration springConfig, float initialValue = 0)
        {
            _spring = springConfig.GetConfigData();
            _state = new SpringState(initialValue, initialValue, 0f);
        }
        public bool IsResting()
        {
            return _state.Resting;
        }

        public float GetValue()
        {
            return _state.Current;
        }

        public float GetTarget()
        {
            return _state.Target;
        }

        public float GetVelocity()
        {
            return _state.Velocity;
        }

        public void SetValue(float value)
        {
            var state = _state;
            state.Target = value;
            state.Current = value;
            state.Velocity = 0f;
            _state = state;
        }

        public void SetTarget(float value)
        {
            var state = _state;

            value %= 360;
            var delta = Mathf.DeltaAngle(state.Current, value);
            state.Target = state.Current + delta;

            _state = state;
        }

        public void SetVelocity(float value)
        {
            var state = _state;
            state.Velocity = value;
            _state = state;
        }

        public void SetSpringConfig(SpringConfiguration springConfig)
        {
            _spring = springConfig.GetConfigData();
        }

        public void Update(float deltaTime)
        {
            var state = _state;
            var config = _spring;
            while (deltaTime >= Mathf.Epsilon)
            {
                var dt = Mathf.Min(deltaTime, 0.016f);
                var force = -config.Tension * (state.Current - state.Target);
                var damping = -config.Friction * state.Velocity;
                var acceleration = (force + damping) / config.Mass;
                state.Velocity = state.Velocity + (acceleration * dt);
                state.Current = state.Current + (state.Velocity * dt);

                if (config.Clamp)
                {

                    if (state.Current < config.ClampRange.x)
                    {
                        state.Current = config.ClampRange.x;
                    }

                    if (state.Current > config.ClampRange.y)
                    {
                        state.Current = config.ClampRange.y;
                    }
                }
                else
                {
                    if (Mathf.Abs(state.Velocity) < config.Precision && Mathf.Abs(state.Current - state.Target) < config.Precision)
                    {
                        state.Current = state.Target;
                        state.Velocity = 0f;
                        state.Resting = true;
                        _state = state;
                        return;
                    }
                }
                deltaTime -= dt;

                //this keeps the value inside 0-360
                if(state.Current >= 360 && state.Target >= 360)
                {
                    state.Current %= 360;
                    state.Target %= 360;
                }

                if(state.Current < 0 && state.Target < 0)
                {
                    state.Current += 360;
                    state.Target += 360;
                }
            }

            state.Resting = false;
            _state = state;
        }
    }
}
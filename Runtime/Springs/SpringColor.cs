using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.Spring
{
    public class SpringColor
    {
        SpringList springCollection;
        Color value;
        Color target;
        Vector4 velocity;

        int rID;
        int gID;
        int bID;
        int aID;
        public SpringColor(SpringConfiguration config, Color initialValue = new Color())
        {
            springCollection = new SpringList(3);
            rID = springCollection.Add(initialValue.r, config);
            gID = springCollection.Add(initialValue.g, config);
            bID = springCollection.Add(initialValue.b, config);
            aID = springCollection.Add(initialValue.a, config);
        }

        public void Update(float deltaTime)
        {
            springCollection.Update(deltaTime);
            value.r = springCollection.GetValue(rID);
            value.g = springCollection.GetValue(gID);
            value.b = springCollection.GetValue(bID);
            value.a = springCollection.GetValue(aID);

            target.r = springCollection.GetTarget(rID);
            target.g = springCollection.GetTarget(gID);
            target.b = springCollection.GetTarget(bID);
            target.a = springCollection.GetTarget(aID);

            velocity.x = springCollection.GetVelocity(rID);
            velocity.y = springCollection.GetVelocity(gID);
            velocity.z = springCollection.GetVelocity(bID);
            velocity.w = springCollection.GetVelocity(aID);
        }

        public void SetTarget(Color target)
        {
            this.target = target;
            springCollection.SetTarget(rID, target.r);
            springCollection.SetTarget(gID, target.g);
            springCollection.SetTarget(bID, target.b);
            springCollection.SetTarget(aID, target.a);
        }

        public void SetValue(Color value)
        {
            this.value = value;
            springCollection.SetValue(rID, value.r);
            springCollection.SetValue(gID, value.g);
            springCollection.SetValue(bID, value.b);
            springCollection.SetValue(aID, value.a);
        }

        public void SetVelocity(Color velocity)
        {
            this.velocity = velocity;
            springCollection.SetVelocity(rID, velocity.r);
            springCollection.SetVelocity(gID, velocity.g);
            springCollection.SetVelocity(bID, velocity.b);
            springCollection.SetVelocity(aID, velocity.a);
        }

        public void SetSpringConfig(SpringConfiguration config)
        {
            springCollection.SetSpringConfig(rID, config);
            springCollection.SetSpringConfig(gID, config);
            springCollection.SetSpringConfig(bID, config);
            springCollection.SetSpringConfig(aID, config);
        }

        public Color GetTarget()
        {
            target.r = springCollection.GetTarget(rID);
            target.g = springCollection.GetTarget(gID);
            target.b = springCollection.GetTarget(bID);
            target.a = springCollection.GetTarget(aID);
            return value;
        }

        public Color GetValue()
        {
            value.r = springCollection.GetValue(rID);
            value.g = springCollection.GetValue(gID);
            value.b = springCollection.GetValue(bID);
            value.a = springCollection.GetValue(aID);
            return value;
        }

        public Vector4 GetVelocity()
        {
            velocity.x = springCollection.GetVelocity(rID);
            velocity.y = springCollection.GetVelocity(gID);
            velocity.z = springCollection.GetVelocity(bID);
            velocity.w = springCollection.GetVelocity(aID);
            return velocity;
        }
    }
}
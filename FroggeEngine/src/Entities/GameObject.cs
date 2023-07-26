using System;
using System.Collections.Generic;
using System.Drawing;

namespace Frogge.Objects
{
    public abstract class GameObject
    {
        private Dictionary<Type, Component> _components = new();

        // Position of the object
        public Single X { get; set; }
        public Single Y { get; set; }
        
        // Size of the object
        public Single Width { get; set; }
        public Single Height { get; set; }
        
        // Velocity of the object
        public Single VelX { get; set; }
        public Single VelY { get; set; }
        
        // Constructor
        public GameObject(Single x, Single y, Single width, Single height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        
        // Update method, to be overridden by child classes
        public virtual void Update(Single deltaTime)
        {
            // By default, for now, just move the object according to its velocity
            X += VelX * deltaTime;
            Y += VelY * deltaTime;
        }
        
        // Render method, to be overridden by child classes
        public abstract void Render(System.Drawing.Graphics graphics);

        public void AddComponent(Component component)
        {
            Type type = component.GetType();
            
            if (_components.ContainsKey(type))
            {
                throw new Exception($"Component of type {type} already exists on this GameObject");
            }

            _components[type] = component;
            component.Initialize();
        }
        
        public T? GetComponent<T>() where T : Component
        {
            Type type = typeof(T);
            if (_components.TryGetValue(type, out Component? component))
                return (T)component;

            return null;
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            Type type = typeof(T);
            if (_components.TryGetValue(type, out Component? component))
            {
                component.Finalize();
                _components.Remove(type);
            }
        }
    }
}
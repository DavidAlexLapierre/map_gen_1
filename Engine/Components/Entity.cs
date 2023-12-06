using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.Engine.Managers;
using System;
using System.Collections.Generic;

namespace ProjectEthereal.Engine.Components {
    abstract class Entity : IdElement {
        private  Dictionary<string, Component> Components { get; set; }
        private Dictionary<Guid, Entity> Children { get; set; }
        protected SceneEvents _events { get; set; }
        protected Game _game { get; set; }

        public Entity(Game game, SceneEvents events) : base() {
            _game = game;
            Children = new Dictionary<Guid, Entity>();
            var visualManager = (Camera)game.Services.GetService(typeof(Camera));
            Components = new Dictionary<String, Component>();
            _events = events;
        }

        public virtual void Update(GameTime gameTime) {
            foreach (var component in Components.Values) {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime) {
            foreach (var component in Components.Values) {
                component.Draw(gameTime);
            }
        }

        protected void AddChild(Entity child) {
            Children.Add(child.Id, child);
            AddEntity(child);
        }

        protected void RemoveChild(Guid id) {
            if (Children.ContainsKey(id)) {
                Children[id].Discard();
                Children.Remove(id);
            }
        }

        protected void AddComponent(Component component) {
            Components.Add(component.Type, component);
            component.Parent = this;
        }

        public virtual void Discard() {
            foreach (var child in Children.Values) {
                child.Discard();
            }
            _events.RemoveEntity?.Invoke(this, new SceneEventArgs(Id));
        }

        public virtual void AddEntity(Entity entity) {
            _events.AddEntity?.Invoke(this, new SceneEventArgs(entity));
        }

        public virtual Entity GetEntity(Guid id) {
            return _events.Scene.GetEntity(id);
        }

        /// Retrieves a specific component
        public T GetComponent<T>(string type) where T : Component {
            try {
                return (T)Components[type];
            } catch(Exception) {
                return null;
            }
        }
    }
}

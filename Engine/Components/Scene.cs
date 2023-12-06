
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.Engine.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectEthereal.Engine.Components {
    abstract class Scene : IdElement, IImplementsUpdate, IImplementsDraw {
        List<Entity> EntitiesToAdd { get; set; }
        protected Game _game { get; set; }
        SpriteBatch _spriteBatch { get; set; }

        public Color BackgroundColor { get; protected set; } = new Color(255, 0, 255);
        protected Dictionary<Guid, Entity> _entities { get; set; }
        protected SceneEvents _events { get; set; }
        Camera _camera { get; set; }


        public Scene() : base() {
            EntitiesToAdd = new List<Entity>();
            _entities = new Dictionary<Guid, Entity>();
            _events = new SceneEvents(this);
        }

        public void Initialize(Game game) {
            _spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            _camera = (Camera)game.Services.GetService<Camera>();
            _game = game;
            
            RegisterEvents();
        }

        private void RegisterEvents() {
            _events.AddEntity += AddEntity;
            _events.RemoveEntity += RemoveEntity;
        }

        protected void AddEntity(object sender, EventArgs args) {
            try {
                SceneEventArgs eventArgs = (SceneEventArgs) args;
                var entity = (Entity) eventArgs.Param_1;
                EntitiesToAdd.Add(entity);
            } catch(Exception) {
                // TODO: Do proper error handling
                Console.WriteLine("ERROR: Problem encountered while adding an entity");
            }
        }

        protected void AddEntity(Entity entity) {
            EntitiesToAdd.Add(entity);
        }

        void AddNewEntities() {
            foreach (var entity in EntitiesToAdd) {
                _entities.Add(entity.Id, entity);
            }
            EntitiesToAdd.Clear();
        }

        protected void RemoveEntity(object sender, EventArgs args) {
            try {
                SceneEventArgs eventArgs = (SceneEventArgs) args;
                var id = (Guid) eventArgs.Param_1;
                _entities.Remove(id);
            } catch (Exception) {
                // TODO: Do proper error handling
                Console.WriteLine("ERROR: Problem encountered while removing an entity");
            }
        }

        public Entity GetEntity(Guid id) {
            if (_entities.ContainsKey(id)) return _entities[id];

            return null;
        }

        public virtual void Update(GameTime gameTime) {
            foreach (var entity in _entities.Values) {
                entity.Update(gameTime);
            }
            AddNewEntities();
        }

        public virtual void Draw(GameTime gameTime) {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null,  _camera.Scale);
            foreach (var entity in _entities.Values) {
                entity.Draw(gameTime);
            }
            _spriteBatch.End();
        }

        public virtual void Init() {}
    }
}

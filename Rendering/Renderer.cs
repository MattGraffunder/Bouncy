using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy
{
    public class Renderer
    {
        private int _screenWidth;
        private int _screenHeight;

        private float _transformWidth;
        private float _transformHeight;

        private GraphicsDevice _graphicsDevice;
        SpriteBatch _spriteBatch;

        private IList<Disc> _discs;

        Dictionary<Type, Texture2D> _textureMap = new Dictionary<Type, Texture2D>();

        public void Initialize(GraphicsDevice graphicsDevice, int worldWidth, int worldHeight, IList<Disc> discs)
        {
            _graphicsDevice = graphicsDevice;

            _spriteBatch = new SpriteBatch(_graphicsDevice);

            _screenHeight = _graphicsDevice.Viewport.Height;
            _screenWidth = _graphicsDevice.Viewport.Width;

            _transformWidth = _screenWidth / worldWidth;
            _transformHeight = _screenHeight / worldHeight;

            _discs = discs;
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            foreach (var disc in _discs)
            {
                _spriteBatch.Draw(_textureMap[disc.GetType()], GetDiscRectangle(disc), Color.White);
            }

            _spriteBatch.End();
        }

        public void AddRenderItem(Type itemType, Texture2D texture)
        {
            _textureMap.Add(itemType, texture);
        }

        private Rectangle GetDiscRectangle(Disc _disc)
        {
            //Transform onto display 
            int offsetWidth = (int)(_disc.Radius * _transformWidth);
            int offsetHeight = (int)(_disc.Radius * _transformHeight);

            return new Rectangle((int)(_disc.Position.X * _transformWidth) - offsetWidth, (int)(_disc.Position.Y * _transformHeight) - offsetHeight, (int)(_disc.Radius * 2 * _transformWidth), (int)(_disc.Radius * 2 * _transformHeight));            
        }
    }
}
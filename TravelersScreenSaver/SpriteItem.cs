using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Travelers
{
    internal class SpriteItem
    {
        private int _Interval;
        private DateTime _LastUpdatedTime;
        private int _AlphabetPosition;

        private int _YOffset = 0;

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Invisible { get; private set; }

        public SpriteItem(int x, int y, bool invisible)
        {
            X = x;
            Y = y;
            Invisible = invisible;

            _Interval = TravelersScreenSaver.Random.Next(150, 251);
            _AlphabetPosition = TravelersScreenSaver.Random.Next(TravelersScreenSaver.AlphabetCharacterCount);
        }

        public bool IsPartiallyOffscreenTop()
        {
            return (Y + _YOffset) < 0;
        }

        private bool IsOffscreenTop()
        {
            return (Y + _YOffset + TravelersScreenSaver.AlphabetItemHeight) < 0;
        }

        public bool IsOffscreenBottom()
        {
            return (Y + _YOffset) >= TravelersScreenSaver.ScreenHeight;
        }

        public void Update(int yOffsetChange = 0)
        {
            var now = DateTime.Now;

            if (now.Subtract(_LastUpdatedTime).TotalMilliseconds > _Interval)
            {
                _LastUpdatedTime = DateTime.Now;
                _AlphabetPosition = TravelersScreenSaver.Random.Next(TravelersScreenSaver.AlphabetCharacterCount);
            }

            if (yOffsetChange > 0)
            {
                _YOffset += yOffsetChange;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Invisible || IsOffscreenTop() || IsOffscreenBottom())
            {
                return;
            }

            var source = new Rectangle(TravelersScreenSaver.AlphabetItemWidth * _AlphabetPosition, 0, TravelersScreenSaver.AlphabetItemWidth, TravelersScreenSaver.AlphabetItemHeight);

            spriteBatch.Draw(TravelersScreenSaver.TravelersAlphabet2, new Vector2(X + 10, Y + 5 + _YOffset), source, Color.White * 0.25f);
            spriteBatch.Draw(TravelersScreenSaver.TravelersAlphabet, new Vector2(X, Y + _YOffset), source, Color.White);
        }

        public override string ToString()
        {
            return $"({X}, {Y + _YOffset}): {_AlphabetPosition}";
        }
    }
}

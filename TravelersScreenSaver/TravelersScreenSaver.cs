using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Travelers
{
    internal class TravelersScreenSaver : Game
    {
        internal const int AlphabetItemWidth = 67;
        internal const int AlphabetItemHeight = 83;
        internal const int AlphabetCharacterCount = 26;

        internal static int ScreenWidth;
        internal static int ScreenHeight;

        internal static Texture2D TravelersAlphabet;
        internal static Texture2D TravelersAlphabet2;
        internal static Random Random = new Random();

        private static object _SyncRoot = new object();

        private const int _InvisibleChance = 3;
        private const int _MinimumCascadeTime = 10000;
        private const int _MaximumCascadeTime = 15000;

        private GraphicsDeviceManager _Graphics;
        private SpriteBatch _SpriteBatch;
        private IList<SpriteItem> _SpriteItems = new List<SpriteItem>();
        private Stage _Stage;
        private DateTime _NextCascade;

        public TravelersScreenSaver()
        {
            ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            if (Debugger.IsAttached)
            {
                ScreenWidth = 1024;
                ScreenHeight = 768;
            }

            SetSprites();
            _Stage = Stage.Alphabet;

            _Graphics = new GraphicsDeviceManager(this);
            _Graphics.PreferredBackBufferWidth = ScreenWidth;
            _Graphics.PreferredBackBufferHeight = ScreenHeight;

            if (!Debugger.IsAttached)
            {
                _Graphics.ToggleFullScreen();
            }

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            TravelersAlphabet = Content.Load<Texture2D>("TravelersAlphabet");
            TravelersAlphabet2 = Content.Load<Texture2D>("TravelersAlphabet2");

            _NextCascade = DateTime.Now.AddMilliseconds(Random.Next(_MinimumCascadeTime, _MaximumCascadeTime));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            switch (_Stage)
            {
                case Stage.Alphabet:
                    foreach (var spriteItem in _SpriteItems)
                    {
                        spriteItem.Update();
                    }

                    if (DateTime.Now >= _NextCascade)
                    {
                        _Stage = Stage.Cascade;
                    }

                    break;
                case Stage.Cascade:
                    var hasOffScreenTopItem = false;

                    foreach (var spriteItem in _SpriteItems)
                    {
                        var percentTimeElapsed = gameTime.ElapsedGameTime.TotalMilliseconds / 10;
                        var moveAmount = (int)(15 * percentTimeElapsed);

                        spriteItem.Update(moveAmount);
                        hasOffScreenTopItem = hasOffScreenTopItem || spriteItem.IsPartiallyOffscreenTop();
                    }

                    if (!hasOffScreenTopItem)
                    {
                        lock (_SyncRoot)
                        {
                            var remove = new List<SpriteItem>();

                            foreach (var spriteItem in _SpriteItems)
                            {
                                if (spriteItem.IsOffscreenBottom())
                                {
                                    remove.Add(spriteItem);
                                }
                            }

                            foreach (var spriteItem in remove)
                            {
                                _SpriteItems.Remove(spriteItem);
                            }

                            AddSprites(-(int)Math.Ceiling((double)ScreenHeight / AlphabetItemHeight), 0);
                        }

                        _NextCascade = DateTime.Now.AddMilliseconds(Random.Next(_MinimumCascadeTime, _MaximumCascadeTime));
                        _Stage = Stage.Alphabet;
                    }

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            foreach (var spriteItem in _SpriteItems)
            {
                spriteItem.Draw(_SpriteBatch);
            }

            _SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetSprites()
        {
            lock (_SyncRoot)
            {
                _SpriteItems.Clear();

                AddSprites(0, (int)Math.Ceiling((double)ScreenHeight / AlphabetItemHeight));
                AddSprites(-(int)Math.Ceiling((double)ScreenHeight / AlphabetItemHeight), 0);
            }
        }

        private void AddSprites(int startingRow, int endingRow)
        {
            var invisibleChance = false;
            var invisibleCount = 0;

            for (var y = startingRow; y < endingRow; y++)
            {
                for (var x = 0; x < (int)Math.Ceiling((double)ScreenWidth / AlphabetItemWidth); x++)
                {
                    if (!invisibleChance)
                    {
                        var invisibleRandom = Random.Next(100);

                        invisibleChance = (invisibleRandom > 20) && (invisibleRandom < 21 + _InvisibleChance);
                        invisibleCount = 0;

                        if (invisibleChance)
                        {
                            invisibleCount = Random.Next(1, 5);
                        }
                    }

                    var invisible = invisibleCount > 0;

                    _SpriteItems.Add(new SpriteItem(AlphabetItemWidth * x, AlphabetItemHeight * y, invisible));

                    if (invisibleCount > 0)
                    {
                        invisibleCount--;
                    }
                    else
                    {
                        invisibleChance = false;
                    }
                }
            }
        }
    }
}

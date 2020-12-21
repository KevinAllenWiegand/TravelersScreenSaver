using System;
using System.Collections.Generic;
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

        internal static Texture2D TravelersAlphabet;
        internal static Texture2D TravelersAlphabet2;
        internal static Random Random = new Random();

        private const int _InvisibleChance = 3;
        private const int _MinimumCascadeTime = 10000;
        private const int _MaximumCascadeTime = 15000;

        private bool _UseMultipleMonitors = false;
        private GraphicsDeviceManager _Graphics;
        private int _ScreenWidth;
        private int _ScreenHeight;
        private SpriteBatch _SpriteBatch;
        private IList<SpriteItem> _SpriteItems = new List<SpriteItem>();
        private Stage _Stage;
        private DateTime _NextCascade;

        public TravelersScreenSaver()
        {
            var point = new Point(0, 0);

            if (_UseMultipleMonitors)
            {
                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                {
                    _ScreenWidth += screen.WorkingArea.Width;

                    if (screen.WorkingArea.Height > _ScreenHeight)
                    {
                        _ScreenHeight = screen.WorkingArea.Height;
                    }

                    if (screen.WorkingArea.Y < point.Y)
                    {
                        var isNegative = screen.WorkingArea.Y < 0;

                        point.Y = (int)Math.Ceiling((double)Math.Abs(screen.WorkingArea.Y) / AlphabetItemHeight) * AlphabetItemHeight;

                        if (isNegative)
                        {
                            point.Y = -point.Y;
                        }
                    }
                }

                _ScreenHeight += Math.Abs(point.Y) * 2;
            }
            else
            {
                _ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            }

            _Graphics = new GraphicsDeviceManager(this);
            _Graphics.PreferredBackBufferWidth = _ScreenWidth;
            _Graphics.PreferredBackBufferHeight = _ScreenHeight;
            _Graphics.HardwareModeSwitch = false;
            _Graphics.GraphicsProfile = GraphicsProfile.HiDef;

            Window.Position = point;
            Window.IsBorderless = true;

            _Graphics.ApplyChanges();

            SetSprites();
            _Stage = Stage.Alphabet;

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
                        var remove = new List<SpriteItem>();

                        foreach (var spriteItem in _SpriteItems)
                        {
                            if (spriteItem.IsOffscreenBottom(_ScreenHeight))
                            {
                                remove.Add(spriteItem);
                            }
                        }

                        foreach (var spriteItem in remove)
                        {
                            _SpriteItems.Remove(spriteItem);
                        }

                        AddSprites(-(int)Math.Ceiling((double)_ScreenHeight / AlphabetItemHeight), 0);

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
                spriteItem.Draw(_SpriteBatch, _ScreenHeight);
            }

            _SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetSprites()
        {
            _SpriteItems.Clear();

            AddSprites(0, (int)Math.Ceiling((double)_ScreenHeight / AlphabetItemHeight));
            AddSprites(-(int)Math.Ceiling((double)_ScreenHeight / AlphabetItemHeight), 0);
        }

        private void AddSprites(int startingRow, int endingRow)
        {
            var invisibleChance = false;
            var invisibleCount = 0;

            for (var y = startingRow; y < endingRow; y++)
            {
                for (var x = 0; x < (int)Math.Ceiling((double)_ScreenWidth / AlphabetItemWidth); x++)
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
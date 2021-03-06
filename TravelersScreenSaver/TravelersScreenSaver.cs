﻿using System;
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

        internal static Texture2D TravelersAlphabetOrange;
        internal static Texture2D TravelersAlphabetRed;
        internal static Texture2D TravelersAlphabetYellow;
        internal static Random Random = new Random();

        private static SpriteFont _TitleFont;
        private static SpriteFont _MainFont;
        private static Color _TextColor = new Color(250, 110, 30);

        private const int _InvisibleChance = 3;
        private const int _MinimumCascadeTime = 10000;
        private const int _MaximumCascadeTime = 15000;
        private const float _TitleFadeInSpeed = 0.025f;
        private const float _TitleFadeOutSpeed = 0.05f;
        private const int _TitleFadeInterval = 100;
        private const string _WelcomeText = "Welcome to the 21st";

        private GraphicsDeviceManager _Graphics;
        private int _ScreenWidth;
        private int _ScreenHeight;
        private SpriteBatch _SpriteBatch;
        private IList<SpriteItem> _SpriteItems = new List<SpriteItem>();
        private Stage _Stage;
        private DateTime _NextCascade;
        private int _MouseXExitThreshold;
        private int _MouseYExitThreshold;
        private int _LastMouseX;
        private int _LastMouseY;

        // TODO:  Most of the following stuff really should be in wrapped objects...but I'm too lazy to do that right now.
        private DateTime _LastAlphaUpdate;
        private float _TitleAlpha = 0;
        private bool _TitleFadedIn = false;
        private bool _TitleFadedOut = false;
        private Vector2 _WelcomeTextUnscaledSize;
        private Vector2 _TravelerTextUnscaledSize;
        private string _TravelerText = $"Traveler {Random.Next(1000, 10000)}";
        private float _WelcomeTextScale;
        private float _TravelerTextScale;
        private Vector2 _WelcomeTextScaledSize;
        private Vector2 _TravelerTextScaledSize;
        private Vector2 _WelcomeTextPosition;
        private Vector2 _TravelerTextPosition;
        private bool _UseMultipleMonitors;
        private System.Windows.Forms.Screen _PrimaryScreen;
        private System.Windows.Forms.Screen _SelectedScreen;
        private int _HeightOffsetFromMultipleMonitorNegativeBounds;

        public TravelersScreenSaver()
        {
            var point = new Point(0, 0);
            
            _UseMultipleMonitors = AppSettings.GetBooleanSetting(AppSettings.UseMultipleMonitorsSetting) && System.Windows.Forms.Screen.AllScreens.Length > 1;

            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                if (screen.Primary)
                {
                    _PrimaryScreen = screen;
                    break;
                }
            }

            if (_UseMultipleMonitors)
            {
                foreach (var screen in System.Windows.Forms.Screen.AllScreens)
                {
                    _ScreenWidth += screen.Bounds.Width;

                    if (screen.Bounds.Height > _ScreenHeight)
                    {
                        _ScreenHeight = screen.Bounds.Height;
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
            }
            else
            {
                var monitor = AppSettings.GetIntSetting(AppSettings.MonitorSetting);
                var selectedScreen = System.Windows.Forms.Screen.AllScreens[0];

                if (monitor == 0)
                {
                    selectedScreen = _PrimaryScreen;
                    point.X = selectedScreen.WorkingArea.X;
                    point.Y = selectedScreen.WorkingArea.Y;
                }
                else
                {
                    if ((monitor - 1) < System.Windows.Forms.Screen.AllScreens.Length)
                    {
                        selectedScreen = System.Windows.Forms.Screen.AllScreens[monitor - 1];
                        point.X = selectedScreen.WorkingArea.X;
                        point.Y = selectedScreen.WorkingArea.Y;
                    }
                }

                _SelectedScreen = selectedScreen;
                _ScreenWidth = selectedScreen.Bounds.Width;
                _ScreenHeight = selectedScreen.Bounds.Height;

                var isNegative = selectedScreen.WorkingArea.Y < 0;

                point.Y = (int)Math.Ceiling((double)Math.Abs(selectedScreen.WorkingArea.Y) / AlphabetItemHeight) * AlphabetItemHeight;

                if (isNegative)
                {
                    point.Y = -point.Y;
                }
            }

            _ScreenHeight += Math.Abs(point.Y);
            _HeightOffsetFromMultipleMonitorNegativeBounds = Math.Abs(point.Y);

            _MouseXExitThreshold = (_ScreenWidth / 100) * 10;
            _MouseYExitThreshold = (_ScreenHeight / 100) * 10;

            _Graphics = new GraphicsDeviceManager(this);
            _Graphics.PreferredBackBufferWidth = _ScreenWidth;
            _Graphics.PreferredBackBufferHeight = _ScreenHeight;
            _Graphics.HardwareModeSwitch = false;
            _Graphics.GraphicsProfile = GraphicsProfile.HiDef;

            Window.Position = point;
            Window.IsBorderless = true;

            _Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _SpriteBatch = new SpriteBatch(GraphicsDevice);

            TravelersAlphabetOrange = Content.Load<Texture2D>("TravelersAlphabetOrange");
            TravelersAlphabetRed = Content.Load<Texture2D>("TravelersAlphabetRed");
            TravelersAlphabetYellow = Content.Load<Texture2D>("TravelersAlphabetYellow");
            _TitleFont = Content.Load<SpriteFont>("TitleFont");
            _MainFont = Content.Load<SpriteFont>("MainFont");

            // TODO:  Might need to adjust the scale depending on screen size.
            _WelcomeTextScale = 2.0f;
            _TravelerTextScale = 1.0f;

            _WelcomeTextUnscaledSize = _TitleFont.MeasureString(_WelcomeText);
            _TravelerTextUnscaledSize = _MainFont.MeasureString(_TravelerText);
            _WelcomeTextScaledSize = _WelcomeTextUnscaledSize * _WelcomeTextScale;
            _TravelerTextScaledSize = _TravelerTextUnscaledSize * _TravelerTextScale;

            // Only display this on the primary monitor.
            System.Windows.Forms.Screen primaryScreen = System.Windows.Forms.Screen.AllScreens[0];

            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                if (screen.Primary)
                {
                    primaryScreen = screen;
                    break;
                }
            }

            var screenWidth = _UseMultipleMonitors ? _PrimaryScreen.Bounds.Width : _SelectedScreen.Bounds.Width;
            var screenHeight = _UseMultipleMonitors ? _PrimaryScreen.Bounds.Height : _SelectedScreen.Bounds.Height;

            _WelcomeTextPosition = new Vector2((screenWidth - _WelcomeTextScaledSize.X) / 2, (screenHeight - _WelcomeTextScaledSize.Y) / 2);
            _TravelerTextPosition = new Vector2(screenWidth - _TravelerTextScaledSize.X - 5, screenHeight -_TravelerTextScaledSize.Y - 5);

            // If we are using multiple monitors, we had to adjust the screen height for negative y positions on other screens (potentially).
            // Add in that value for when we are drawing on the main monitor to get the correct centering.
            if (_UseMultipleMonitors)
            {
                _WelcomeTextPosition.Y += _HeightOffsetFromMultipleMonitorNegativeBounds;
                _TravelerTextPosition.Y += _HeightOffsetFromMultipleMonitorNegativeBounds;
            }

            SetSprites();
            _Stage = Stage.Title;
        }

        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState(Window);

            if (_LastMouseX > 0 && _LastMouseY > 0 && ((Math.Abs(mouseState.X - _LastMouseX) > _MouseXExitThreshold) || (Math.Abs(mouseState.Y - _LastMouseY) > _MouseYExitThreshold)))
            {
                Exit();
            }

            // Screensavers turn off on any keypress.
            if (Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                Exit();
            }

            _LastMouseX = mouseState.X;
            _LastMouseY = mouseState.Y;

            switch (_Stage)
            {
                case Stage.Title:
                    if (DateTime.Now.Subtract(_LastAlphaUpdate).TotalMilliseconds > _TitleFadeInterval)
                    {
                        _LastAlphaUpdate = DateTime.Now;

                        if (!_TitleFadedIn)
                        {
                            _TitleAlpha += _TitleFadeInSpeed;

                            if (_TitleAlpha > 1.0f)
                            {
                                _TitleAlpha = 1.0f;
                                _TitleFadedIn = true;
                            }
                        }
                        else if (!_TitleFadedOut)
                        {
                            _TitleAlpha -= _TitleFadeOutSpeed;

                            if (_TitleAlpha < 0)
                            {
                                _TitleAlpha = 0;
                                _TitleFadedOut = true;
                            }
                        }
                    }

                    break;
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

            _SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            switch (_Stage)
            {
                case Stage.Title:
                    if (_TitleFadedOut)
                    {
                        _Stage = Stage.Alphabet;
                        _NextCascade = DateTime.Now.AddMilliseconds(Random.Next(_MinimumCascadeTime, _MaximumCascadeTime));
                    }
                    else
                    {
                        _SpriteBatch.DrawString(_TitleFont, _WelcomeText, _WelcomeTextPosition, _TextColor * _TitleAlpha, 0f, new Vector2(0, 0), _WelcomeTextScale, SpriteEffects.None, 0f);
                        _SpriteBatch.DrawString(_MainFont, _TravelerText, _TravelerTextPosition, _TextColor * _TitleAlpha, 0f, new Vector2(0, 0), _TravelerTextScale, SpriteEffects.None, 0f);
                    }

                    break;
                case Stage.Alphabet:
                case Stage.Cascade:
                    foreach (var spriteItem in _SpriteItems)
                    {
                        spriteItem.Draw(_SpriteBatch, _ScreenHeight);
                    }

                    break;
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
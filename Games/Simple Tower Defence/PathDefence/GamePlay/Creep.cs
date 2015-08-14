using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.Screens;
using XNASimpleTemplates;

namespace PathDefence.GamePlay
{
    public class Creep : GameComponentBase<PathDefenceGame>
    {
        //Abstand zum Wegpunkt, bei dem das Ziel erreicht wurde
        private const float AtDestinationLimit = 0.1f;
        //Drehgeschwindigkeit
        private const float MaxAngularVelocity = 999;
        //Max Beschleunigung
        private const float MaxMoveSpeedDelta = 10;
        private readonly GamePlayScreen GameScreen;
        public readonly int InitialHealth;
        public readonly int InitialSpeed;
        //Max Geschwindigkeit
        private float maxMoveSpeed;
        //Tot, in Bewegung, außerhalb des Feldes...
        private CreepState creepState;
        //Richtung...^^
        private Vector2 direction;
        //Position auf dem virtuellen Spielfeld (für die Wegberechnung)
        public Vector2 GridPosition;

        private Texture2D HealthBar;
        private Color HealthColor;
        private Vector2 HealthPosition;
        private Vector2 HealthScale;
        private Vector2 HealthSize;
        private float moveSpeed;
        private SpriteBatch spriteBatch;
        //Liste aller Wegpunkte bis zum Ziel
        private Queue<Vector2> WayPoints;

        //Dieses Event kann von einem Turm abonniert werden um so Creep-spezifische Sachen zu machen
        public event Action<Creep, GameTime> CustomUpdate;

        public int Health { get; private set; }
        public float Speed { get { return maxMoveSpeed; } set { maxMoveSpeed = value; } }

        public CreepState CreepState
        {
            get { return creepState; }
        }

        public Vector2 MiddlePosition
        {
            get { return new Vector2(Position.X + Size.X / 2, Position.Y + Size.Y / 2); }
        }

        //Abstand zum aktuellen Wegpunkt
        private float DistanceToDestination
        {
            get { return Vector2.Distance(GridPosition, WayPoints.Peek()); }
        }

        //Am aktuellen Wegpunkt angekommen?
        private bool AtDestination
        {
            get { return DistanceToDestination < AtDestinationLimit; }
        }

        //Am Ende des Levels angekommen?
        private bool TargetReached
        {
            get
            {
                return ((WayPoints != null) && (WayPoints.Count == 0)) ||
                       (GridPosition.X >= LevelManager.GridCount.X - 1);
            }
        }

        public int Points { get; private set; }

        public Creep(Game game, GamePlayScreen gameScreen, string textur, int health, int speed, Vector2 gridPosition)
            : base(game)
        {
            GameScreen = gameScreen;
            TextureName = textur;
            Health = health;
            InitialHealth = health;
            maxMoveSpeed = speed;
            InitialSpeed = speed;
            GridPosition = gridPosition;
        }

        public override void Initialize()
        {
            SpriteBatch = CurrGame.SpriteBatch;
            TextureDirectory = "Creep/";
            OriginType = OriginType.Center;
            Size = new Vector2(GameScreen.LevelManager.GridSize.X * 1.5f, GameScreen.LevelManager.GridSize.Y);
            HealthSize = new Vector2(Size.X, 5);
            HealthPosition = new Vector2(Position.X - HealthSize.X / 2, Position.Y - Size.Y);
            spriteBatch = CurrGame.SpriteBatch;
            Position =
                new Vector2(GridPosition.X * GameScreen.LevelManager.GridSize.X + GameScreen.LevelManager.GridSize.X / 2,
                            GridPosition.Y * GameScreen.LevelManager.GridSize.Y + GameScreen.LevelManager.GridSize.Y / 2);
            //Weg zum Ziel suchen
            GridChanged(null);
            Points = (int)Math.Round(InitialHealth * maxMoveSpeed / WayPoints.Count, MidpointRounding.AwayFromZero);
            creepState = CreepState.Running;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            HealthBar = CurrGame.Content.Load<Texture2D>("Creep/healthbar");
            UpdateHealthBar();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (Health < InitialHealth)
            {
                spriteBatch.Begin();
                {
                    spriteBatch.Draw(HealthBar, HealthPosition, null, HealthColor, 0, Vector2.Zero, HealthScale,
                                     SpriteEffects.None, 0);
                }
                spriteBatch.End();
            }
        }

        //Fertige Methode aus den Xna-Beispielen, beschleunigt oder bremst den Gegner
        private float FindMaxMoveSpeed(Vector2 waypoint)
        {
            float finalSpeed = maxMoveSpeed;
            float turningRadius = maxMoveSpeed / MaxAngularVelocity;
            var orth = new Vector2(direction.Y, -direction.X);

            float closestDistance = Math.Min(Vector2.Distance(waypoint, GridPosition + (orth * turningRadius)),
                                             Vector2.Distance(waypoint, GridPosition - (orth * turningRadius)));

            if (closestDistance < turningRadius)
            {
                float radius = Vector2.Distance(GridPosition, waypoint) / 2;
                finalSpeed = MaxAngularVelocity * radius;
            }

            return finalSpeed;
        }

        //Zuständig für Drehungen
        private static float TurnToFace(Vector2 position, Vector2 faceThis, float currentAngle, float turnSpeed)
        {
            float x = faceThis.X - position.X;
            float y = faceThis.Y - position.Y;
            var desiredAngle = (float)Math.Atan2(y, x);
            float difference = WrapAngle(desiredAngle - currentAngle);
            difference = MathHelper.Clamp(difference, -turnSpeed, turnSpeed);
            return WrapAngle(currentAngle + difference);
        }

        //Auch für Drehung
        private static float WrapAngle(float radians)
        {
            while (radians < -MathHelper.Pi)
            {
                radians += MathHelper.TwoPi;
            }
            while (radians > MathHelper.Pi)
            {
                radians -= MathHelper.TwoPi;
            }
            return radians;
        }

        public override void Update(GameTime gameTime)
        {
            var elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Falls der Gegner noch in Bewegung ist, und auch noch Wegpunkte vor sich
            if ((creepState == CreepState.Running) && (WayPoints != null) && (WayPoints.Count > 0))
            {
                //Falls er einen Wegpunkt erreicht hat
                if (AtDestination)
                {
                    //Nächsten Wegpunkte zum aktuellen machen
                    WayPoints.Dequeue();
                    //Und die Gridposition richtig setzen
                    GridPosition.X = (float)Math.Round(GridPosition.X, 0, MidpointRounding.AwayFromZero);
                    GridPosition.Y = (float)Math.Round(GridPosition.Y, 0, MidpointRounding.AwayFromZero);
                    //Auch die Punkte müssen neu berechnet werden, da ein Creep kurz vor Ende seiner Reise mehr Punkte gibt
                    Points = (int)Math.Round(InitialHealth * maxMoveSpeed / (WayPoints.Count+1), MidpointRounding.AwayFromZero) + 1;
                }
                else
                {
                    //Blablabla, einfach die aktuelle Geschwindikeit errechnen
                    float previousMoveSpeed = moveSpeed;
                    float desiredMoveSpeed = FindMaxMoveSpeed(WayPoints.Peek());
                    moveSpeed = MathHelper.Clamp(desiredMoveSpeed, previousMoveSpeed - MaxMoveSpeedDelta * elapsedTime,
                                                 previousMoveSpeed + MaxMoveSpeedDelta * elapsedTime);

                    //Hier wird der Creep noch in die richtige Richtung gedreht
                    var facingDirection = (float)Math.Atan2(direction.Y, direction.X);
                    facingDirection = TurnToFace(GridPosition, WayPoints.Peek(), facingDirection,
                                                 MaxAngularVelocity * elapsedTime);
                    direction = new Vector2((float)Math.Cos(facingDirection), (float)Math.Sin(facingDirection));
                    Rotation = (float)Math.Atan2(direction.Y, direction.X);

                    //Und die Position aktualisiert
                    GridPosition = GridPosition + (direction * moveSpeed * elapsedTime);
                }
                //Jetzt noch die "richtige" Position ausrechnen, also die, die zum Zeichnen benötigt wird
                Position =
                    new Vector2(
                        GridPosition.X * GameScreen.LevelManager.GridSize.X + GameScreen.LevelManager.GridSize.X / 2,
                        GridPosition.Y * GameScreen.LevelManager.GridSize.Y + GameScreen.LevelManager.GridSize.Y / 2);
            }
            //SInd wir am Ende des levels?
            if (TargetReached)
            {
                creepState = CreepState.Out;
                GameScreen.CreepOut(this);
            }

            //Das CustomUpdate für die Türme...
            if (CustomUpdate != null)
            {
                CustomUpdate(this, gameTime);
            }

            HealthPosition = new Vector2(Position.X - HealthSize.X / 2, Position.Y - Size.Y);

            base.Update(gameTime);
        }

        //Hier sucht sich der Creep einen neuen Weg durch das Level, der Parameter kann angeben, 
        //welche Positionen gerade blockiert wurden (dient nur zur Optimierung)
        public void GridChanged(List<Vector2> positions)
        {
            //falls wir Punkte übergen haben
            if (positions != null)
            {
                //Falls eine der Positionen auf der eigenen Strecke liegt
                if (IsVectorOnPath(positions))
                    //Müssen wir uns einen neuen Weg suchen
                    WayPoints = GameScreen.LevelManager.FindPath(GridPosition);
            }
            else
            {
                //Einfach so einen neuen Weg suchen
                WayPoints = GameScreen.LevelManager.FindPath(GridPosition);
            }
        }

        public bool IsVectorOnPath(Vector2 pos)
        {
            if (WayPoints.Contains(pos))
                return true;
            return false;
        }

        public bool IsVectorOnPath(List<Vector2> posList)
        {
            foreach (var vector2 in posList)
            {
                if (IsVectorOnPath(vector2))
                {
                    return true;
                }
            }
            return false;
        }

        //Der Gegner wurde getroffen
        public void Hit(int damage)
        {
            Health -= damage;
            //Der Gui die Änderungen mitteilen
            GameScreen.ChangeInformation();
            UpdateHealthBar();
            if (Health <= 0)
            {
                Kill();
            }
        }

        private void UpdateHealthBar()
        {
            HealthScale = new Vector2(HealthSize.X / HealthBar.Width, HealthSize.Y / HealthBar.Height);
            float energy = ((float)Health) / InitialHealth;
            HealthScale = new Vector2(HealthScale.X * energy, HealthScale.Y);
            HealthColor = Color.Green;
            if (energy < 0.2f)
            {
                HealthColor = Color.Red;
                return;
            }
            if (energy < 0.5f)
            {
                HealthColor = Color.Yellow;
            }
        }

        public void Kill()
        {
            creepState = CreepState.Killed;
            GameScreen.CreepOut(this);
        }
    }

    public enum CreepState
    {
        Out,
        Killed,
        Running
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Pacman.Objects;
using Pacman.Objects.Items;
using Pacman.Objects.Items.MoveItems;
using Barrier = Pacman.Objects.Items.Barrier;

namespace Pacman
{
    public class Game
    {
        Random random = new Random();
        public List<Barrier> Barriers { get; private set; }
        public List<DammageableBarrier> DammageableBarriers { get; private set; }
        private bool IsActive;

        public event EventHandler GameOver;

        public Player Player;

        public List<Bullet> Bullets { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public List<Bonus> Bonuses { get; private set; }
        public IEnumerable<Item> ItemsToDisplay
        {
            get
            {
                var items = new List<Item>(Barriers.Count + DammageableBarriers.Count + Bonuses.Count + Enemies.Count + Bullets.Count + 1);
                items.AddRange(Barriers);
                items.AddRange(DammageableBarriers);
                items.AddRange(Bonuses);
                items.AddRange(Bullets);
                items.AddRange(Enemies);
                items.Add(Player);
                return items;
            }
        }
        public GameConfiguration Configuration { get; private set; }
        internal List<EnemySpawn> EnemySpawns { get; private set; }

        public Game(int[,] map, GameConfiguration configuration)
        {
            Configuration = configuration;
            Bullets = new List<Bullet>();
            Enemies = new List<Enemy>();
            Bonuses = new List<Bonus>();
            Initialize(map);
        }

        public void Start()
        {
            IsActive = true;
            var thread = new Thread(Process);
            thread.Start();
        }

        public void Stop()
        {
            IsActive = false;
        }

        private void Initialize(int[,] matrix)
        {
            Barriers = new List<Barrier>();
            DammageableBarriers = new List<DammageableBarrier>();
            EnemySpawns = new List<EnemySpawn>();
            Configuration.Width = matrix.GetLength(1);
            Configuration.Height = matrix.GetLength(0);
            for (int i = 0; i < Configuration.Height; i++)
            {
                for (int j = 0; j < Configuration.Width; j++)
                {
                    var item = DefineItem(matrix[i, j], i, j);
                    if (item.Type == ItemType.Wall)
                    {
                        Barriers.Add((Barrier) item);
                    }
                    else if (item.Type == ItemType.DammageableWall)
                    {
                        DammageableBarriers.Add((DammageableBarrier)item);
                    }
                    else if (item.Type == ItemType.EnemySpawn)
                    {
                        EnemySpawns.Add((EnemySpawn)item);
                    }
                    else if (item.Type == ItemType.Enemy)
                    {
                        Enemies.Add((Enemy)item);
                    }
                    else if (item.Type == ItemType.Bonus)
                    {
                        Bonuses.Add((Bonus)item);
                    }
                }
            }
            GenerateEnemies();
            GenerateBonuses();
        }

        private void GenerateEnemies()
        {
            if (EnemySpawns != null)
            {
                for (int i = 0; i < (Configuration.Ghosts - Enemies.Count); i++)
                {
                    var index = random.Next(EnemySpawns.Count);
                    var item = new Enemy(EnemySpawns[index].Position.X, EnemySpawns[index].Position.Y, (int)Configuration.Speed)
                    {
                        CurrentDirection = Direction.Right
                    };
                    Enemies.Add(item);
                }
            }
        }

        private void GenerateBonuses()
        {
            if (Bonuses != null)
            {
                var bonuses = Configuration.Apples - Bonuses.Count;
                while (bonuses > 0)
                {
                    var x = random.Next(1, Configuration.Width);
                    var y = random.Next(1, Configuration.Height);
                    var checkedCell = CheckCell(ItemType.Bonus, Point.FromRelative(x, y));
                    if (checkedCell)
                    {
                        var item = new Bonus(x, y);
                        Bonuses.Add(item);
                        bonuses--;
                    }
                }
            }
        }

        public void Process()
        {
            while (IsActive)
            {
                ProcessBullets();
                ProcessEnemies();
                ProcessBonuses();
                ProcessPlayer();
                ProcessInteractions();
                Thread.Sleep(1000 / 30);
            }
        }

        public void SetDirectionToPlayer(Direction direction)
        {
            Player.NextDirection = direction;
        }

        private void ProcessPlayer()
        {
            if (IsFullyInCell(Player.Position))
            {
                Player.CurrentDirection = Player.NextDirection;
            }
            Move(Player);
        }

        private void ProcessBullets()
        {
            foreach (var item in Bullets)
            {
                Move(item);
            }
        }

        private void ProcessBonuses()
        {
            if (Bonuses.Count < Configuration.Apples)
            {
                GenerateBonuses();
            }
        }

        private void ProcessEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                var enemy = Enemies[i];
                if (!Move(enemy))
                {
                    enemy.CurrentDirection = ChangeDirection(enemy.CurrentDirection);
                }
            }
            if (Enemies.Count < Configuration.Ghosts)
            {
                GenerateEnemies();
            }
        }

        private void ProcessInteractions()
        {
            var groupedItems = ItemsToDisplay.GroupBy(i => i.Position);
                foreach (var items in groupedItems)
                {
                    if (items.Count() > 1)
                    {
                        if (items.Any(i => i.Type == ItemType.Bullet))
                        {
                            if (items.Any(i => i.Type == ItemType.Player))
                            {
                                IsActive = false;
                                GameOver?.Invoke(this, null);
                            }
                            else if (items.Any(i => i.Type == ItemType.Enemy))
                            {
                                Player.Score += 20;
                                var enemies = items.Where(i => i.Type == ItemType.Enemy).ToArray();
                                KillEnemy(enemies);
                            }
                            else if (items.Any(i => i.Type == ItemType.DammageableWall))
                            {
                                var item = (DammageableBarrier)items.FirstOrDefault(i => i.Type == ItemType.DammageableWall);
                                item.Dammaged = true;
                            }
                            var bullets = items.Where(i => i.Type == ItemType.Bullet).ToArray();
                            KillBullet(bullets);
                        }
                        else if(items.Any(i => i.Type == ItemType.Player))
                        {
                            if (items.Any(i => i.Type == ItemType.Enemy))
                            {
                                IsActive = false;
                                GameOver?.Invoke(this, null);
                            }
                            else if (items.Any(i => i.Type == ItemType.Bonus))
                            {
                                Player.Score += 50;
                                var bonuses = items.Where(i => i.Type == ItemType.Bonus).ToArray();
                                DeleteBonus(bonuses);
                            }
                        }
                    }
                }
        }

        private void KillEnemy(Item[] enemies)
        {
            if (enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    Enemies.Remove((Enemy)enemies[i]);
                }
            }
        }

        private void KillBullet(Item[] bullets)
        {
            if (bullets != null)
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    Bullets.Remove((Bullet)bullets[i]);
                }
            }
        }

        private void DeleteBonus(Item[] bonuses)
        {
            if (bonuses != null)
            {
                for (int i = 0; i < bonuses.Length; i++)
                {
                    Bonuses.Remove((Bonus)bonuses[i]);
                }
            }
        }

        private Direction ChangeDirection(Direction oldDirection)
        {
            Direction newDirection;
            do
            {
                newDirection = (Direction)random.Next(4);
            } while (newDirection == oldDirection);
            return newDirection;
        }

        private bool IsFullyInCell(Point position) => position.AbsX % Point.CellSize == 0
                                                      && position.AbsY % Point.CellSize == 0;

        public void CreateBullet(Point position, Direction direction)
        {
            var bullet = new Bullet(position.X, position.Y, (int)Speed.High * 2)
            {
                CurrentDirection = direction,
                NextDirection = direction
            };
            bullet.Position = DefinePosition(bullet, direction);
            Bullets.Add(bullet);
        }

        private Item DefineItem(int numberOfItem, int x, int y)
        {
            Item item;
            switch (numberOfItem)
            {
                case 0:
                    item = new Empty(x, y);
                    break;
                case 1:
                    item = new Barrier(x, y);
                    break;
                case 2:
                    item = new DammageableBarrier(x, y);
                    break;
                case 3:
                    Player = new Player(x, y, ((int)Configuration.Speed), this);
                    item = Player;
                    break;
                case 4:
                    item = new Enemy(x, y, (int)Configuration.Speed);
                    break;
                case 5:
                    item = new EnemySpawn(x, y);
                    break;
                case 6:
                    item = new Bonus(x, y);
                    break;
                default:
                    throw new ArgumentException("unknown number of item");
            }
            return item;
        }

        private bool Move(MovingItem item)
        {
            if (IsFullyInCell(item.Position) && !TestStep(item))
            {
                return false;
            }
            item.Move();
            return true;
        }

        private bool TestStep(MovingItem item)
        {
            var currentPoint = DefinePosition(item, item.CurrentDirection);
            var result = CheckCell(item.Type, currentPoint);
            return result;
        }

        private bool CheckCell(ItemType itemType, Point currentPoint)
        {
            if (itemType == ItemType.Bullet)
            {
                var result = Barriers.FirstOrDefault(i => (i.Position.X == currentPoint.X && i.Position.Y == currentPoint.Y));
                return result == null;
            }
            var result1 = Barriers.FirstOrDefault(i => (i.Position.X == currentPoint.X && i.Position.Y == currentPoint.Y));
            var result2 = DammageableBarriers.FirstOrDefault(i => (i.Position.X == currentPoint.X && i.Position.Y == currentPoint.Y));
            return result1 == null && result2 == null;
        }

        private Point DefinePosition(MovingItem item, Direction direction)
        {
            Point currentPoint;
            switch (direction)
            {
                case Direction.Up:
                    currentPoint = Point.FromRelative(item.Position.X, item.Position.Y - 1);
                    break;
                case Direction.Down:
                    currentPoint = Point.FromRelative(item.Position.X, item.Position.Y + 1);
                    break;
                case Direction.Left:
                    currentPoint = Point.FromRelative(item.Position.X - 1, item.Position.Y);
                    break;
                case Direction.Right:
                    currentPoint = Point.FromRelative(item.Position.X + 1, item.Position.Y);
                    break;
                default:
                    throw new ArgumentException("unknown direction");
            }
            return currentPoint;
        }
    }
}

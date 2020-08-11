using System.Windows.Forms;

namespace Digger
{
    //Класс, содержащий игрока
    public class Player : ICreature
    {
        //Передвигает Digger в зависимости от нажатия клавиш,
        //расположения на карте и блока перед ним
        public CreatureCommand Act(int x, int y)
        {
            var player = new CreatureCommand();

            switch (Game.KeyPressed)
            {
                case Keys.Left:
                    if (x - 1 >= 0 && !(Game.Map[x - 1, y] is Sack))
                        player.DeltaX -= 1;
                    break;
                case Keys.Right:
                    if (x + 1 < Game.MapWidth && !(Game.Map[x + 1, y] is Sack))
                        player.DeltaX = 1;
                    break;
                case Keys.Up:
                    if (y - 1 >= 0 && !(Game.Map[x, y - 1] is Sack))
                        player.DeltaY -= 1;
                    break;
                case Keys.Down:
                    if (y + 1 < Game.MapHeight && !(Game.Map[x, y + 1] is Sack))
                        player.DeltaY = 1;
                    break;
                default:
                    break;
            }
            return player;
        }

        //Исчезает ли при пересечении с объектами
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return (conflictedObject is Sack) || (conflictedObject is Monster);
        }

        public int GetDrawingPriority() //Приоритет рисования
        {
            return 1;
        }

        public string GetImageFileName() //Изображение для рисования
        {
            return "Digger.png";
        }
    }


    //Класс, содержащий блоки земли
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y) //Передвижение блоков земли
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        //Исчезает ли при пересечении с объектами
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority() //Приоритет рисования
        {
            return 2;
        }

        public string GetImageFileName() //Изображение для рисования
        {
            return "Terrain.png";
        }
    }

    //Класс, содержащий мешок с золотом
    public class Sack : ICreature
    {
        private int offsetY = 0; //Смещение по оси Y

        public CreatureCommand Act(int x, int y) //Передвижение мешка с золотом
        {
            if (HasOpportunityToFall(x, y))
            {
                offsetY++;
                return new CreatureCommand() { DeltaY = 1 };
            }
            else if (offsetY > 1)
            {
                offsetY = 0;
                return new CreatureCommand() { TransformTo = new Gold() };
            }
            else
            {
                offsetY = 0;
                return new CreatureCommand();
            }
        }

        //Проверка, может ли мешок упасть вниз
        public bool HasOpportunityToFall(int x, int y)
        {
            if (y + 1 < Game.MapHeight)
            {
                var belowObject = Game.Map[x, y + 1];
                return ((belowObject is Player || belowObject is Monster)
                && offsetY >= 1) || (belowObject == null);
            }
            return false;
        }

        //Исчезает ли при пересечении с объектами
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority() //Приоритет рисования
        {
            return 2;
        }

        public string GetImageFileName() //Изображение для рисования
        {
            return "Sack.png";
        }
    }

    //Класс, содержащий золото
    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y) //Передвижение золота
        {
            return new CreatureCommand();
        }

        //Исчезает ли при пересечении с объектами
        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
            {
                Game.Scores += 10;
                return true;
            }
            return conflictedObject is Monster;
        }

        public int GetDrawingPriority() //Приоритет рисования
        {
            return 2;
        }

        public string GetImageFileName() //Изображения для рисования
        {
            return "Gold.png";
        }
    }

    //Класс, содержащий монстра
    public class Monster : ICreature
    {
        int playerX = 0; //Координаты игрока
        int playerY = 0;

        //Передвижение монстра
        public CreatureCommand Act(int x, int y)
        {
            var monster = new CreatureCommand();
            if (PlayerIsAlive())
            {
                if (playerY < y && !HasAbilityToMove(Game.Map[x, y - 1]))
                    monster.DeltaY -= 1;
                else if (playerY > y && !HasAbilityToMove(Game.Map[x, y + 1]))
                    monster.DeltaY = 1;
                else if (playerX < x && !HasAbilityToMove(Game.Map[x - 1, y]))
                    monster.DeltaX -= 1;
                else if (playerX > x && !HasAbilityToMove(Game.Map[x + 1, y]))
                    monster.DeltaX = 1;
            }
            return monster;
        }

        //Проверяет возможность движения дальше
        public bool HasAbilityToMove(ICreature point)
        {
            return (point is Monster) || (point is Sack) || (point is Terrain);
        }

        //Проверяет, жив ли Digger
        public bool PlayerIsAlive()
        {
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                {
                    if (Game.Map[x, y] is Player)
                    {
                        playerX = x;
                        playerY = y;
                        return true;
                    }
                }
            return false;
        }

        //Исчезает ли при пересечении с объектами
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return (conflictedObject is Sack) || (conflictedObject is Monster);
        }

        public int GetDrawingPriority() //Приоритет рисования
        {
            return 1;
        }

        public string GetImageFileName() //Изображения для рисования
        {
            return "Monster.png";
        }
    }
}

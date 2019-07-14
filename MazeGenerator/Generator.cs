using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class Generator
    {
        private int x_size;

        private int y_size;

        private Field start;

        private Field end;

        private Field[,] board;

        private int length;
        public Generator(int x, int y)
        {
            this.x_size = x;
            this.y_size = y;
        }
        public void Start()
        {
            this.board = new Field[x_size, y_size];

            //Ustawianie mapy na 0
            InitMaze();

            SetEntryAndExitPoint();

            board[start.point.X, start.point.Y].text = start.text;
            board[end.point.X, end.point.Y].text = end.text;

            // DrawCorrectPath();

            DrawMaze();
        }

        private void DrawCorrectPath()
        {
            List<Field> correctPathFromBegin = new List<Field>();
            List<Field> correctPathFromEnd = new List<Field>();

            correctPathFromBegin.Add(start);
            correctPathFromEnd.Add(end);
            int i = 0;
            while (true)
            {
                bla(correctPathFromBegin[i], '+');
                bla(correctPathFromEnd[i], '-');
                i++;


                break;
            }

            correctPathFromBegin.AddRange(correctPathFromEnd);
            List<Field> fullCorrectPath = new List<Field>(correctPathFromBegin);
        }

        private void bla(Field field, char operation)
        {
            Random random = new Random();
            var seed = random.Next(1, 4);

            switch (seed)
            {
                case 1: // lewo
                    if (!field.leftWall)
                    {
                        if (!board[field.point.X - 1, field.point.Y].Visited)
                        {

                        }
                        else
                        {
                            bla(field, operation);
                        }
                    }
                    else
                    {
                        bla(field, operation);
                    }
                    break;
                case 2: // gora
                    if (!field.topWall)
                    {
                        if (!board[field.point.X, field.point.Y + 1].Visited)
                        {

                        }
                        else
                        {
                            bla(field, operation);
                        }
                    }
                    else
                    {
                        bla(field, operation);
                    }
                    break;
                case 3: //prawo
                    if (!field.rightWall)
                    {
                        if (!board[field.point.X + 1, field.point.Y].Visited)
                        {

                        }
                        else
                        {
                            bla(field, operation);
                        }
                    }
                    else
                    {
                        bla(field, operation);
                    }
                    break;
                case 4: //dol
                    if (!field.bottomWall)
                    {
                        if (!board[field.point.X, field.point.Y - 1].Visited)
                        {

                        }
                        else
                        {
                            bla(field, operation);
                        }
                    }
                    else
                    {
                        bla(field, operation);
                    }
                    break;
                default:
                    break;
            }

        }

        private void InitMaze()
        {
            for (int y_axis = 0; y_axis < y_size; y_axis++)
            {
                for (int x_axis = 0; x_axis < x_size; x_axis++)
                {
                    board[y_axis, x_axis] = new Field(new Point(y_axis, x_axis), "0");
                    if (y_axis == 0)
                    {
                        board[y_axis, x_axis].leftWall = true;
                    }
                    if (y_axis == y_size - 1)
                    {
                        board[y_axis, x_axis].rightWall = true;
                    }
                    if (x_axis == 0)
                    {
                        board[y_axis, x_axis].topWall = true;
                    }
                    if (x_axis == x_size - 1)
                    {
                        board[y_axis, x_axis].bottomWall = true;
                    }
                }
            }
        }

        private void SetEntryAndExitPoint()
        {
            // 1 - lewo 2 - gora 3 - prawo 4 - dol
            Random random = new Random();

            int startSeed = random.Next(1, 4);
            int exitSeed = random.Next(1, 4);

            switch (startSeed)
            {
                case 1: // x = 0
                    start = new Field(new Point(0, random.Next(1, y_size - 2)), "1");
                    start.topWall = true;
                    break;
                case 2: // y = 0 
                    start = new Field(new Point(random.Next(1, x_size - 2), 0), "1");
                    start.leftWall = true;
                    break;
                case 3: // x = max
                    start = new Field(new Point(x_size - 1, random.Next(1, y_size - 2)), "1");
                    start.bottomWall = true;
                    break;
                case 4: // y = max
                    start = new Field(new Point(random.Next(1, x_size - 2), y_size - 1), "1");
                    start.rightWall = true;
                    break;
                default:
                    break;
            }
            if (startSeed == exitSeed)
            {
                List<int> AvaliableX = new List<int>();
                List<int> AvaliableY = new List<int>();

                for (int i = 1; i < x_size - 1; i++)
                {
                    if (i != start.point.X)
                        if (i != start.point.X - 1)
                            if (i != start.point.X + 1)
                                AvaliableX.Add(i);
                }

                for (int i = 1; i < y_size - 1; i++)
                {
                    if (i != start.point.Y)
                        if (i != start.point.Y - 1)
                            if (i != start.point.Y + 1)
                                AvaliableY.Add(i);
                }

                switch (exitSeed)
                {
                    case 1: // x = 0
                        end = new Field(new Point(0, AvaliableY[random.Next(0, AvaliableY.Count - 1)]), String.Empty);
                        end.topWall = true;
                        break;
                    case 2: // y = 0 
                        end = new Field(new Point(AvaliableX[random.Next(0, AvaliableX.Count - 1)], 0), String.Empty);
                        end.leftWall = true;
                        break;
                    case 3: // x = max
                        end = new Field(new Point(x_size - 1, AvaliableY[random.Next(0, AvaliableY.Count - 1)]), String.Empty);
                        end.bottomWall = true;
                        break;
                    case 4: // y = max
                        end = new Field(new Point(AvaliableX[random.Next(0, AvaliableX.Count - 1)], y_size - 1), String.Empty);
                        end.rightWall = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (exitSeed)
                {
                    case 1: // x = 0
                        end = new Field(new Point(0, random.Next(1, y_size - 2)), "");
                        end.topWall = true;
                        break;
                    case 2: // y = 0 
                        end = new Field(new Point(random.Next(1, x_size - 2), 0), "");
                        end.leftWall = true;
                        break;
                    case 3: // x = max
                        end = new Field(new Point(x_size - 1, random.Next(1, y_size - 2)), "");
                        end.bottomWall = true;
                        break;
                    case 4: // y = max
                        end = new Field(new Point(random.Next(1, x_size - 2), y_size - 1), "");
                        end.rightWall = true;
                        break;
                    default:
                        break;
                }
            }

            SetCorrectPathLength(random);
            end.text = length.ToString();
        }

        private void SetCorrectPathLength(Random random)
        {
            length = (int)Math.Round((x_size * y_size) * (0.01 * random.Next(25, 35)));
        }

        private void DrawMaze()
        {
            for (int i = 0; i < y_size; i++)
            {
                for (int j = 0; j < x_size; j++)
                {
                    Console.Write(board[i, j].text + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

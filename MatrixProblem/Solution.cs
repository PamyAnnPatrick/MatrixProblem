using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProblem
{
    public class Solution
    {
        int[,] flows;
        HashSet<(int, int)> res = new();
        HashSet<(int, int)> queueHash = new();
        int rows, cols;
        public HashSet<(int, int)> PacificAtlantic(int[][] heights)
        {
            rows = heights.Length;
            cols = heights[0].Length;
            flows = new int[rows, cols];

            Queue<(int r, int c)> queue = new();

            //Pacific Flows  
            for (int r = 1; r < rows; r++)
            {
                queue.Enqueue((r, 0));
                queueHash.Add((r, 0));
            }

            for (int c = 0; c < cols; c++)
            {
                queue.Enqueue((0, c));
                queueHash.Add((0, c));
            }
            queue = BFS(queue, heights, true);

            //Atlantic Flows  
            for (int r = 0; r < rows; r++)
            {
                queue.Enqueue((r, cols - 1));
                queueHash.Add((r, cols - 1));
            }

            for (int c = 0; c < cols - 1; c++)
            {
                queue.Enqueue((rows - 1, c));
                queueHash.Add((rows - 1, c));
            }

            queue = BFS(queue, heights, false);

         
            return res;
        }

        private Queue<(int r, int c)> BFS(Queue<(int r, int c)> queue, int[][] heights, bool IsPacific)
        {
            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                queueHash.Remove(cell);

                if (IsPacific)
                    MakePacific(cell.r, cell.c);
                else
                    MakeAtlantic(cell.r, cell.c);

                //bottom of the cell
                if (CanMark((cell.r + 1, cell.c), heights, IsPacific))
                {
                    queue.Enqueue((cell.r + 1, cell.c));
                    queueHash.Add((cell.r + 1, cell.c));
                }

                //right of the cell
                if (CanMark((cell.r, cell.c + 1), heights, IsPacific))
                {
                    queue.Enqueue((cell.r, cell.c + 1));
                    queueHash.Add((cell.r, cell.c + 1));
                }

                //top of the cell
                if (CanMark((cell.r - 1, cell.c), heights, IsPacific))
                {
                    queue.Enqueue((cell.r - 1, cell.c));
                    queueHash.Add((cell.r - 1, cell.c));
                }

                //left of the cell
                if (CanMark((cell.r, cell.c - 1), heights, IsPacific))
                {
                    queue.Enqueue((cell.r, cell.c - 1));
                    queueHash.Add((cell.r, cell.c - 1));
                }
            }
            return queue;
        }
        private bool CanMark((int r, int c) cell, int[][] heights, bool IsPacific)
        {

            if (!CheckCellValid(cell) || AlreadyMarked(cell, IsPacific) || queueHash.Contains(cell))
                return false;

            var topCell = (cell.r - 1, cell.c);
            if (CheckCellValid(topCell) && AlreadyMarked(topCell, IsPacific) && FlowToOcean(topCell, cell, heights))
                return true;

            var bottomCell = (cell.r + 1, cell.c);
            if (CheckCellValid(bottomCell) && AlreadyMarked(bottomCell, IsPacific) && FlowToOcean(bottomCell, cell, heights))
                return true;

            var leftCell = (cell.r, cell.c - 1);
            if (CheckCellValid(leftCell) && AlreadyMarked(leftCell, IsPacific) && FlowToOcean(leftCell, cell, heights))
                return true;

            var rightCell = (cell.r, cell.c + 1);
            if (CheckCellValid(rightCell) && AlreadyMarked(rightCell, IsPacific) && FlowToOcean(rightCell, cell, heights))
                return true;

            return false;
        }

        private bool FlowToOcean((int r, int c) from, (int r, int c) to, int[][] heights)
        {
            return heights[from.r][from.c] <= heights[to.r][to.c];
        }

        private bool AlreadyMarked((int r, int c) cell, bool IsPacific)
        {
            if (flows[cell.r, cell.c] == 3)
                return true;

            if (IsPacific && flows[cell.r, cell.c] == 1)
                return true;

            if (!IsPacific && flows[cell.r, cell.c] == 2)
                return true;

            return false;
        }

        private bool CheckCellValid((int r, int c) cell)
        {
            return (cell.r >= 0 && cell.r < rows && cell.c >= 0 && cell.c < cols);
        }

        private void MakePacific(int r, int c)
        {
            if (flows[r, c] == 3)
                return;

            if (flows[r, c] == 0 || flows[r, c] == 2)
                flows[r, c]++;

            if (flows[r, c] == 3)
                res.Add((r, c));
        }

        private void MakeAtlantic(int r, int c)
        {
            if (flows[r, c] == 3)
                return;

            if (flows[r, c] == 0 || flows[r, c] == 1)
                flows[r, c] += 2;

            if (flows[r, c] == 3)
                res.Add((r, c));
        }


    }
}

// See https://aka.ms/new-console-template for more information
using MatrixProblem;


Solution s = new();
//int[][] a = new int[5][];
//a[0] = new int[5] { 1, 2, 2, 3, 5 };
//a[1] = new int[5] { 3, 2, 3, 4, 4 };
//a[2] = new int[5] { 2, 4, 5, 3, 1 };
//a[3] = new int[5] { 6, 7, 1, 4, 5 };
//a[4] = new int[5] { 5, 1, 1, 2, 4 };

int[][] a = new int[3][];
a[0] = new int[3] { 10, 10, 10 };
a[1] = new int[3] { 10, 1, 10 };
a[2] = new int[3] { 10, 10, 10 };

//[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]
//int[][] a = new int[5][];
//a[0] = new int[5] { 1, 2, 2, 3, 5 };
//a[1] = new int[5] { 3, 2, 3, 4, 4 };
//a[2] = new int[5] { 2, 4, 5, 3, 1 };
//a[3] = new int[5] { 6, 7, 1, 4, 5 };
//a[4] = new int[5] { 5, 1, 1, 2, 4 };
var r=s.PacificAtlantic(a);
r.ToList().ForEach(x => Console.WriteLine($"{x.Item1},{x.Item2}"));

Console.ReadLine();

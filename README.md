# MatrixProblem

There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).

The island receives a lot of rain, and the rain water can flow to neighboring cells directly north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.

Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.

Example 

 ![image](https://user-images.githubusercontent.com/51465563/212207006-91086acc-593f-4d91-bdc9-30c4d73b30fb.png)
 
 input : [2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
 
Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]

Explanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:

[0,4]: [0,4] -> Pacific Ocean 
       [0,4] -> Atlantic Ocean
       
[1,3]: [1,3] -> [0,3] -> Pacific Ocean 
       [1,3] -> [1,4] -> Atlantic Ocean
       
[1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean 
       [1,4] -> Atlantic Ocean
       
[2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean 
       [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
       
[3,0]: [3,0] -> Pacific Ocean 
       [3,0] -> [4,0] -> Atlantic Ocean
       
[3,1]: [3,1] -> [3,0] -> Pacific Ocean 
       [3,1] -> [4,1] -> Atlantic Ocean
       
[4,0]: [4,0] -> Pacific Ocean 
       [4,0] -> Atlantic Ocean
       
Note that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.

Approach

The main concept is to do BFS from the elements at the borders.

Flows is a jagged array that keeps the state of each cell.
If the value is 1 , then rain flows from the cell to pacific.
If 2, rain flows from the cell to atlantic.
If 3, then it reaches to both oceans. In such case add the result to a hashtable.

Additional hashtable is used for queue in order to save time complexity of O(n) to search for elements in queue. Its O(1) in a hashset.

Code is split into multiple functions to improve readability.

Complexity

Time complexity:
O(n), where n is the number of elements in the matrics




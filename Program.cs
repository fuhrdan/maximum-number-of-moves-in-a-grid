//*****************************************************************************
//** 2684. Maximum Number of Moves in a Grid    leetcode                     **
//*****************************************************************************


int dfs(int** grid, int** memo, int m, int n, int row, int col) {
    if (memo[row][col] != -1) {
        return memo[row][col];
    }

    int maxMoves = 0;
    int directions[3][2] = {{-1, 1}, {0, 1}, {1, 1}};

    for (int i = 0; i < 3; i++) {
        int newRow = row + directions[i][0];
        int newCol = col + directions[i][1];

        if (newRow >= 0 && newRow < m && newCol < n && grid[newRow][newCol] > grid[row][col]) {
            maxMoves = (maxMoves > 1 + dfs(grid, memo, m, n, newRow, newCol)) ? maxMoves : 1 + dfs(grid, memo, m, n, newRow, newCol);
        }
    }

    memo[row][col] = maxMoves;
    return maxMoves;
}

int maxMoves(int** grid, int gridSize, int* gridColSize) {
    int m = gridSize;
    int n = gridColSize[0];
    int** memo = (int**)malloc(m * sizeof(int*));
    for (int i = 0; i < m; i++) {
        memo[i] = (int*)malloc(n * sizeof(int));
        for (int j = 0; j < n; j++) {
            memo[i][j] = -1;  // Initialize memoization array to -1 (indicating uncomputed cells)
        }
    }

    int maxResult = 0;
    for (int row = 0; row < m; row++) {
        maxResult = (maxResult > dfs(grid, memo, m, n, row, 0)) ? maxResult : dfs(grid, memo, m, n, row, 0);
    }

    // Free memoization array
    for (int i = 0; i < m; i++) {
        free(memo[i]);
    }
    free(memo);

    return maxResult;
}
namespace PracticalExamRefactoring
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    class Task4
    {
        internal void Execute()
        {
            int heightCoefficient = int.Parse(Console.ReadLine());
            int height = heightCoefficient * 2 + 1;
            int xWidth = int.Parse(Console.ReadLine());
            int width = (xWidth + 2) + (2 * heightCoefficient);
            var grid = new List<string>();
            var topTriangleWidth = width - 2 * xWidth - 4;

            string leftfragment = '\\' + new String('#', xWidth) + '\\';
            string rightfragment = '/' + new String('#', xWidth) + '/';
            int currentRow = 0;
            while (topTriangleWidth > 0)
            {
                grid.Add(
                    new String('.', currentRow) + leftfragment +
                    new String('.', topTriangleWidth) +
                    rightfragment + new String('.', currentRow)
                    );
                topTriangleWidth -= 2;
                currentRow++;
            }

            grid.Add(
                    new String('.', currentRow) +
                    '\\' + new String('#', xWidth) + 'X' + new String('#', xWidth) + '/' +
                    new String('.', currentRow)
                    );
            currentRow++;

            var decrement = 1;
            var middleWidth = xWidth * 2 - decrement;
            while (middleWidth != xWidth)
            {
                grid.Add(
                         new String('.', currentRow) + '\\' + new String('#', middleWidth) + '/' +
                         new String('.', currentRow)
                         );
                decrement += 2;
                middleWidth = xWidth * 2 - decrement;
                currentRow++;
            }

            var middleRow = new String('.', currentRow) + 'X' + new String('#', xWidth) + 'X' + 
                new String('.', currentRow);

            var totalGrid = new List<string>();
            totalGrid.AddRange(grid);
            totalGrid.Add(middleRow);

            for (int i = grid.Count - 1; i >= 0; i--)
            {
                var reverrsedRow = new StringBuilder();
                for (int j = grid[i].Length - 1; j >= 0; j--)
                {
                    reverrsedRow.Append(grid[i][j]);
                }

                totalGrid.Add(reverrsedRow.ToString());
            }

            foreach (var row in totalGrid)
            {
                Console.WriteLine(row.Substring(width / 2 - heightCoefficient, 2 * heightCoefficient + 1));
                Console.WriteLine(row);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public static class TableParser
    {
        public static string GetTable(IEnumerable<Block> shapes, string[] headers)
        {
            IEnumerable<Tuple<string, string, string, string>> shapeToPrint =
              new[]
              {
                          Tuple.Create(ShapeName.Square.ToString(),
                            ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Red, ShapeName.Square),
                               ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Blue, ShapeName.Square),
                                 ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Yellow, ShapeName.Square)),

                           Tuple.Create(ShapeName.Triangle.ToString(),
                            ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Red, ShapeName.Triangle),
                               ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Blue, ShapeName.Triangle),
                                 ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Yellow, ShapeName.Triangle)),

                            Tuple.Create(ShapeName.Circle.ToString(),
                             ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Red, ShapeName.Circle),
                               ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Blue, ShapeName.Circle),
                                 ShapeProcessor.GenerateStringShapeCounterFormatted(shapes, ColorName.Yellow, ShapeName.Circle)),
              };

            return shapeToPrint.ToStringTable(headers,
             a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4);
        }
        public static string ToStringTable<T>(
          this IEnumerable<T> values,
          string[] columnHeaders,
          params Func<T, object>[] valueSelectors)
        {
            return ToStringTable(values.ToArray(), columnHeaders, valueSelectors);
        }

        private static string ToStringTable<T>(
          this T[] values,
          string[] columnHeaders,
          params Func<T, object>[] valueSelectors)
        {

            int rowNumberForHeader = 1;
            bool hasHeader = true;
            if (columnHeaders == null)// means no header, no separator
            {
                rowNumberForHeader = 0;
                hasHeader = false;
            }

            var arrValues = new string[values.Length + rowNumberForHeader, valueSelectors.Length];

            // Fill headers
            if (hasHeader)
            {
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                {
                    arrValues[0, colIndex] = columnHeaders[colIndex];
                }
            }

            // Fill table rows
            for (int rowIndex = rowNumberForHeader; rowIndex < arrValues.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                {
                    arrValues[rowIndex, colIndex] = valueSelectors[colIndex]
                      .Invoke(values[rowIndex - rowNumberForHeader]).ToString();
                }
            }

            return ToStringTable(arrValues, hasHeader);
        }

        private static string ToStringTable(this string[,] arrValues, bool hasHeader)
        {
            int[] maxColumnsWidth = GetMaxColumnsWidth(arrValues);
            string headerSpliter = string.Empty;
            string verticalSeparator = string.Empty;
            if (hasHeader)
            {
                headerSpliter = new string('-', maxColumnsWidth.Sum(i => i + 3) - 1);
                verticalSeparator = "|";
            }

            var sb = new StringBuilder();
            for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
                {
                    // Print cell
                    string cell = arrValues[rowIndex, colIndex];
                    cell = cell.PadRight(maxColumnsWidth[colIndex]);
                    sb.Append($" {verticalSeparator} ");
                    sb.Append(cell);
                }

                // Print end of line
                sb.Append($" {verticalSeparator} ");
                sb.AppendLine();

                if (hasHeader)
                {
                    // Print splitter
                    if (rowIndex == 0)
                    {
                        sb.AppendFormat(" |{0}| ", headerSpliter);
                        sb.AppendLine();
                    }
                }

            }

            return sb.ToString();
        }

        private static int[] GetMaxColumnsWidth(string[,] arrValues)
        {
            var maxColumnsWidth = new int[arrValues.GetLength(1)];
            for (int colIndex = 0; colIndex < arrValues.GetLength(1); colIndex++)
            {
                for (int rowIndex = 0; rowIndex < arrValues.GetLength(0); rowIndex++)
                {
                    int newLength = arrValues[rowIndex, colIndex].Length;
                    int oldLength = maxColumnsWidth[colIndex];

                    if (newLength > oldLength)
                    {
                        maxColumnsWidth[colIndex] = newLength;
                    }
                }
            }

            return maxColumnsWidth;
        }
    }
}

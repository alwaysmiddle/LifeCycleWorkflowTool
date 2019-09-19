using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace LifeCycleWorkflowLibrary
{
    public static class DataImporter
    {
        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.
        public static object[,] ReadCsvFile(string filename, bool skipFirstLine = false)
        {
            List<string[]> allLines = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                bool firstLine = true;

                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();
                    if(line != null && line.Length > 0)
                    {
                        if(skipFirstLine && firstLine)
                        {
                            firstLine = false;
                        }
                        else
                        {
                            allLines.Add(line);
                        }
                    }
                }
            }

            // See how many rows and columns there are.
            int num_rows = allLines.Count;
            int num_cols = allLines[0].Length;

            // Allocate the data array.
            object[,] values = new object[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = allLines[r][c];
                }
            }

            // Return the values.
            return values;
        }
    }
}

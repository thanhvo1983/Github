using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Kvics.Utility
{
    public class CSVFileManager
    {
        public static DataTable Read(string filePath, System.Text.Encoding encoding, string valuesSeparator)
        {
            System.IO.StreamReader rd = null;
            try
            {
                DataTable table = new DataTable();
                rd = new System.IO.StreamReader(filePath, encoding);

                while (!rd.EndOfStream)
                {
                    String rowString = rd.ReadLine();
                    if (rowString != null && !rowString.Trim().Equals("", StringComparison.OrdinalIgnoreCase))
                    {
                        string[] cellsString = rowString.Split(new string[] { valuesSeparator }, StringSplitOptions.None);
                        while (table.Columns.Count < cellsString.Length)
                        {
                            table.Columns.Add();
                        }

                        DataRow rowData = table.NewRow();
                        for (int i = 0; i < cellsString.Length; i++)
                        {
                            rowData[i] = cellsString[i];
                        }

                        table.Rows.Add(rowData);
                    }
                }

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }
            }
        }

        public static string GetCSVString(DataTable tb, bool headerView, string valuesSeparator)
        {
            String header = "";
            string lineBreak = System.Environment.NewLine;
            System.Text.StringBuilder stringBuider = new System.Text.StringBuilder();
            if (headerView)
            {
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    header += tb.Columns[i].ColumnName + valuesSeparator;
                }
                if (header.Length > 0)
                {
                    header = header.Substring(0, header.Length - 1);
                }
                stringBuider.Append(header);
            }

            if (tb != null)
            {
                int rowCount = tb.Rows.Count;
                int columnCount = tb.Columns.Count;

                for (int i = 0; i < rowCount; i++)
                {
                    if (i > 0)
                    {
                        stringBuider.Append(lineBreak);
                    }
                    DataRow row = tb.Rows[i];

                    for (int j = 0; j < columnCount; j++)
                    {
                        stringBuider.Append(row[j]);
                        stringBuider.Append(j < columnCount - 1 ? valuesSeparator : "");
                    }
                }
            }

            return stringBuider.ToString();
        }

        public static bool WriteToFile(string filePath, string data, Encoding encoding)
        {
            Stream stm = null;
            System.IO.StreamWriter sr = null;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                stm = System.IO.File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                sr = new System.IO.StreamWriter(stm, encoding);
                sr.Write(data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (stm != null)
                {
                    stm.Close();
                }
            }
        }
    }
}

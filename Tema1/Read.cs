using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Tema1
{
    public class Read
    {

        public void ChangeFile(string strToFind, string strToChangeWith)
        {
            int index = int.Parse(strToFind);
            string fileName = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[index - 1] = strToChangeWith;
            File.WriteAllLines(fileName, arrLine);
        }
        public void DeleteItem(string condition)
        {
            string fileName = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";

            string[] arrLine = File.ReadAllLines(fileName);
            int index = 0;
            while (index < arrLine.Length)
            {
                string[] textLine;
                textLine = arrLine[index].Split('|');

                if (textLine[0] == condition)
                {
                    for (int i = index; i < arrLine.Length - 1; i++)
                    {
                        textLine = arrLine[i].Split('|');

                        string[] Line = arrLine[i + 1].Split('|');
                        string str = textLine[0] + "|" + Line[1] + "|" + Line[2] + "|" + Line[3] + "|" + Line[4];

                        ChangeFile(textLine[0], str);
                    }
                    break;
                }
                index++;
            }
            arrLine = File.ReadAllLines(fileName);
            StringBuilder sb = new StringBuilder();
            int count = arrLine.Length - 1; // except last line
            for (int i = 0; i < count; i++)
            {
                sb.AppendLine(arrLine[i]);
            }
            File.WriteAllText(fileName, sb.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;


namespace Tema1
{
    class Dictionary
    {
        public ObservableCollection<Word> DictionaryItems
        {
            get;

            set;
        }

        public Dictionary()

        {
            DictionaryItems = new ObservableCollection<Word>()
            {
                new Word()
            };
        }

        public List<string> Read()
        {
            List<string> comboBox = new List<string>();
            string pathToRead = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";
            using (StreamReader sr = new StreamReader(pathToRead))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] Line;
                    str = sr.ReadLine();

                    Line = str.Split('|');
                    comboBox.Add(Line[2]);
                    DictionaryItems.Add(new Word()
                    {
                        Id = Line[0],
                        WordName = Line[1],
                        Category = Line[2],
                        Description = Line[3],
                        Path = Line[4]
                    });
                }
                sr.Close();
            }
            return comboBox;
        }

      
    }
}

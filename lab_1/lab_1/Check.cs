﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class CheckPrinting
    {

        public void ShowCheck(string path)
        {
            string s = File.ReadAllText(path);
            Console.WriteLine(s);
        }
        

    }
}

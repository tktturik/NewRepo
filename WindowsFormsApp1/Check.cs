using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Check
    {
        string _value;
        string _result;
        public Check(string value)
        {
            _value=value;
        }
        public string CheckDigit(string text)
        {
            int OnTheSpot = 0;
            int OutThePlace = 0;
            for (int i= 0;i < text.Length;i++)
            {
                if(text[i] == _value[i])
                {
                    OnTheSpot++;
                }else if (SymbolInText(text[i]))
                {
                    OutThePlace++;
                } 
                
            }
            _result = $"Совпали {OnTheSpot} позиции\nСовпали {OutThePlace} цифры";
            if (OnTheSpot == 4) _result = "Pobeda";

            Console.WriteLine(_value);
            Console.WriteLine(_result);
            return _result;

        }
        private bool SymbolInText(char ch) 
        {
                foreach (char c2 in _value) 
                {
                    if (ch == c2) 
                    {
                        return true;
                    }
                } 
                return false;
           
        }



    }
}

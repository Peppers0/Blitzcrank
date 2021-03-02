using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlitzcrankClient.Reconocimiento
{
    class KeyboardMapper
    {
        public static Keys GetKey(char value)
        {
            switch (value.ToString().ToLower())
            {
                case "a":
                    return Keys.A;
                case "b":
                    return Keys.B;
                case "c":
                    return Keys.C;
                case "d":
                    return Keys.D;
                case "e":
                    return Keys.E;
                case "f":
                    return Keys.F;
                case "g":
                    return Keys.G;
                case "h":
                    return Keys.H;
                case "i":
                    return Keys.I;
                case "j":
                    return Keys.J;
                case "k":
                    return Keys.K;
                case "l":
                    return Keys.L;
                case "m":
                    return Keys.M;
                case "n":
                    return Keys.N;
                case "o":
                    return Keys.O;
                case "p":
                    return Keys.P;
                case "q":
                    return Keys.Q;
                case "r":
                    return Keys.R;
                case "s":
                    return Keys.S;
                case "t":
                    return Keys.T;
                case "u":
                    return Keys.U;
                case "v":
                    return Keys.V;
                case "w":
                    return Keys.W;
                case "x":
                    return Keys.X;
                case "y":
                    return Keys.Y;
                case "z":
                    return Keys.Z;
                case "0":
                    return Keys.D0;
                case "1":
                    return Keys.D1;
                case "2":
                    return Keys.D2;
                case "3":
                    return Keys.D3;
                case "4":
                    return Keys.D4;
                case "5":
                    return Keys.D5;
                case "6":
                    return Keys.D6;
                case "7":
                    return Keys.D7;
                case "8":
                    return Keys.D8;
                case "9":
                    return Keys.D9;
                case " ":
                    return Keys.Space;
                default:
                    throw new Exception("Not handled key " + value);
            }
        }
    }
}

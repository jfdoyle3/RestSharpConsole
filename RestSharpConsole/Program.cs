﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            YahooSite.YahooAPI_SQLWrite();

        }
    }
}

﻿using System.IO;
using System.Threading;

using EliteAPI;

namespace Example
{
    class Program
    {
        private static EliteDangerousAPI EliteAPI;

        static void Main(string[] args)
        {
            EliteAPI = new EliteDangerousAPI(EliteDangerousAPI.StandardDirectory);
            EliteAPI.Logger.UseConsole().UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            //EliteAPI.Events.AllEvent += (sender, e) => EliteAPI.Logger.LogInfo(Newtonsoft.Json.JsonConvert.SerializeObject(e));
            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}
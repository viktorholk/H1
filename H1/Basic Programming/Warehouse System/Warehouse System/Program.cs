﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Warehouse_System.Classes;
using Warehouse_System.Classes.Warehouse;
using Warehouse_System.Classes.Application;
using System.Linq;
namespace Warehouse_System
{
    class Program
    {

        static void Main(string[] args)
        {
            Application application = new Application("Warehouse System", 120, 25);
            application.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BetterTimer.Droid
{
    class DatabaseConnectionAndroid : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "AlarmsDb.db3";
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
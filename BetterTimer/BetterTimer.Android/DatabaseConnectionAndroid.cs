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
using BetterTimer.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace BetterTimer.Droid
{
    public class DatabaseConnectionAndroid : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "AlarmsDb.db3";
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
using System;

namespace OnlineMedicineShopping.DataLayer
{
    public class Mongosettings
    {
        //Using this two property we are try o get connection and databse name into DbContext
        public string Connection { get; set; }
        public string DatabaseName { get; set; }
    }
}

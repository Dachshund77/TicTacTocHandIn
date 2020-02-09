using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacTocHandIn
{
    public class Options
    {

       private static readonly Lazy<Options> lazy = new Lazy<Options>(() => new Options());

        public static Options Instance
        {
            get { return lazy.Value; }
        }


        //Value go here 

        private Options()
        {
            //private constructor
            //This should load 
        }

        //TODO SAVE DATA
    }
}


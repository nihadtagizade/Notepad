using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class StoreData
    {
        private static int current;
        private static int lineNumber;
        private static string Find_findWhat;
        private static int direction;
        private static string Replace_findWhat;
        private static string Replace_replaceWith;
        private static string allText;
        /// <summary>
        /// ///////////////////////////////////////////////////////
        /// </summary>
        public StoreData()
        {
            lineNumber = 1;
            Find_findWhat = "";
            direction = 0;
            Replace_findWhat = "";
            Replace_replaceWith = "";
            allText = "";
            current = 0;
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="text"></param>
        public static void setAllText(string text)
        {
            allText = text;
        }
        public static string getAllText()
        {
            return allText;
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="lineNumber"></param>
        public void setLineNumber(int linenumber)
        {
            lineNumber = linenumber;
        }
        public static int getLineNumber()
        {
            return lineNumber;
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Find_findWhat"></param>
        public void setFind_findWhat(string Find_findwhat)
        {
            Find_findWhat = Find_findwhat;
        }
        public static string getFind_findWhat()
        {
            return Find_findWhat;
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="direction"></param>
        public void setDirection(int Direction)
        {
            direction = Direction;
        }
        public static int getDirection()
        {
            return direction;
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Replace_findWhat"></param>
        public void setReplace_findWhat(string Replace_findwhat)
        {
            Replace_findWhat = Replace_findwhat;
        }
        public static string getReplace_findWhat()
        {
            return Replace_findWhat;
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="Replace_replaceWith"></param>
        public void setReplace_replaceWith(string Replace_replacewith)
        {
            Replace_replaceWith = Replace_replacewith;
        }
        public static string getReplace_replaceWith()
        {
            return Replace_replaceWith;
        }
        //////////////////////////////////////////////////////////////////////////
        public static void setCurrent(int x)
        {
            current = x;
        }
        public static int getCurrent()
        {
            return current;
        }
        ///////////////////////////////////////////////////////////////////////////
    }
}

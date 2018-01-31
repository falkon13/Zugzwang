// <copyright file="Program.cs" company="Jonathan le Grange">
//     Program file for Zugszwang chess engine
// </copyright>
namespace Zugzwang
{
    using System;

    /// <summary>
    /// Program entry class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry class
        /// </summary>
        /// <param name="args"> Arguments passed in</param>
       public static void Main(string[] args)
        {
            BoardGeneration.InitateBoard();
            Console.ReadLine();
        }
    }
}

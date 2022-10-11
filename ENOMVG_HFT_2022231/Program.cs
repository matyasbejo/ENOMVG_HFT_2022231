using ENOMVG_HFT_2022231.Models;
using ENOMVG_HFT_2022231.Repository;
using System;
using System.Linq;

namespace ENOMVG_HFT_2022231
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //commit test (first commit)
            SchollingDbContext ctx = new SchollingDbContext();
            var items = ctx.Schools.ToArray();
            ;
        }
    }
}

using ENOMVG_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ENOMVG_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

        static void Main(string[] args)
        {
            rest = new RestService("");
        }
    }
}

using System;
using Compulsory1.Petshop.Core.IRepositories;
using Compulsory1.Petshop.Core.Services;
using Compulsory1.Petshop.DataAccess;
using Compulsory1.Petshop.DataAccess.Repositories;
using Compulsory1.Petshop.Domain.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace Compulsory1.Petshop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();



        }
    }
}
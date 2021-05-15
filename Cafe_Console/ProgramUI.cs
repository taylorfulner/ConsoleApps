using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedItems();
            Menu();
        }

        public void Menu()
        {

        }

        public void SeedItems()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_Joppes
{
    class Program
    {
        static void Main(string[] args)
        {
            var joppe = new PetOwner(15);
            Console.WriteLine($"I am Jeppe. I am {joppe.Age} and I love animals!");
            joppe.ShowMenu();
        }
    }
}

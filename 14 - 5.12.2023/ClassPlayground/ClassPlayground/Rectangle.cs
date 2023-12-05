using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassPlayground
{
    internal class Rectangle
    {
        public float width;
        public float height;

        public Rectangle (float width, float height) 
        { 
            this.width = width;
            this.height = height;                         
        }

        public float CalculateArea() 
        { 
         float area = width * height;
            return area;           
        }
                                
        public void CalculateAspectRation () 
        { 
         if ( (width/height) < 1 ) 
         {                
                Console.WriteLine("Vysoký obdelník");           
         }
         else if ( (width/height) > 1 ) 
         {
                Console.WriteLine("Široký obdelník");

         }
         else if ( (height/width) == 1) 
         {
                Console.WriteLine("Čtverec");

         }
        } 

        public void PrintRectangle() 
        {
            float printedRectangle = CalculateArea();
            Console.WriteLine($"Obsah obdelníku je {printedRectangle} cm2");
        }

        public bool ContainsPoint() //může být i void
        { 
            Console.WriteLine("Zadej x");           
            int x = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Zadej y");
            int y = Convert.ToInt32(Console.ReadLine());

            if ( (x < 0 || x > width) || (y < 0 || y > height)) 
            { 
                Console.WriteLine("Bod neleží v obdelníku");
                return false;
            }
            else 
            { 
                Console.WriteLine("Bod leží v obdelníku");
                return true;
            } 
        }
    }
}

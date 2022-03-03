using System.Linq;
using Triangle.Types;

namespace TriangleShape
{
    public sealed class TriangleType
    {
        private static TriangleType? instance = null ;
        private TriangleType()
        {

        }
        public static TriangleType Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TriangleType();
                }

                return instance;
            }
        }
        public string getTrigType(params int[] sides)
        {
            enumTriangleTypes trigType = enumTriangleTypes.ERROR;

            // Check to see if all three sides are > 0 and the array contains 3 lengths
            bool validTriangle = (sides.Where (x=>x==0).Count() == 0) && (sides.Length == 3);
            if (validTriangle)
            {
                var sidesAreEqual = sides.GroupBy(x=>x).Count();

                if (sidesAreEqual == 1) // sides contain just 1 group therefore is equalateral
                {
                   trigType = enumTriangleTypes.EQUALATERAL; 
                }
                else if (sidesAreEqual == 2)
                {
                    trigType = enumTriangleTypes.ISOSCELES;
                }
                else
                {
                    trigType = enumTriangleTypes.SCALENE;
                }
            }
            return trigType.ToString();
        }

        // public string getTrigType(int a, int b, int c)
        // {

        //     return getTrigType(a, b, c);
        // }
    }
}
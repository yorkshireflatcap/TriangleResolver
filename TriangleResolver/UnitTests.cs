using NUnit.Framework;
using System;
using TriangleShape;
using Triangle.Types;

namespace Triangle.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        TriangleType? trig = null;
        
        [SetUp]
        public void Setup() 
        {
            trig = TriangleType.Instance;
        }

        [Test(Description="Any side that contains a where any side <= 0 is considered as an error")]
        [TestCase(new int[] {0,2,3})]
        [TestCase(new int[] {1,2,0})]
        [TestCase(new int[] {0,1,0})]
        [TestCase(new int[] {0,0,0})]
        [TestCase(new int[] {1,0,1})]
        public void TestForInvalidValues(int[] sides)
        {
            if (trig != null)
            {
                var t = trig.getTrigType(sides);
                Assert.That(t, Is.EqualTo(Enum.GetName(enumTriangleTypes.ERROR)));
            }
        }

        [Test(Description="Scalene where no sides are equal")]
        [TestCase(new int[] {1,2,3})]
        [TestCase(new int[] {2,3,1})]
        [TestCase(new int[] {3,2,1})]
        public void TestIfScalene(int[] sides)
        {
            if (trig != null)
            {
                var t = trig.getTrigType(sides);
                Assert.That(t, Is.EqualTo(Enum.GetName(enumTriangleTypes.SCALENE)));
            }
        }
        [Test(Description="Isosceles where any two sides are equal")]
        [TestCase(new int[] {5,5,6})]
        [TestCase(new int[] {5,6,5})]
        [TestCase(new int[] {6,5,5})]
        public void TestIfIsosceles(int[] sides)
        {
            if (trig != null)
            {
                var t = trig.getTrigType(sides);
                Assert.That(t, Is.EqualTo(Enum.GetName(enumTriangleTypes.ISOSCELES)));
            }
        }

        [Test(Description="Equalateral where all sides are equal")]
        [TestCaseSource(nameof(lengthOfSides))]
        public void TestIfEqualateral(int a, int b, int c)
        {
            if (trig != null)
            {
                var t = trig.getTrigType(a, b, c);
                Assert.That(t, Is.EqualTo(Enum.GetName(enumTriangleTypes.EQUALATERAL)));
            }
            
        }

        static object[] lengthOfSides = {
            new int[] {5,5,5},
            new int[] {6,6,6},
            new int[] {10,10,10}
        };


    }
}
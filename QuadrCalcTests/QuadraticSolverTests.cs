// Unit Tests for the QuadraticSolver class
using System;
using Xunit;
using QuadrCalc;

namespace QuadrCalcTests
{
    public class QuadraticSolverTests
    {
        [Theory]
        [InlineData(1, -3, 2, 2, new double[] { 2, 1 })]
        [InlineData(1, 2, 1, 1, new double[] { -1 })]
        [InlineData(1, 0, 1, 0, new double[] { })]
        public void Solve_ValidInputs_CorrectResults(double a, double b, double c, int expectedRootCount, double[] expectedRoots)
        {
            // Act
            var (rootCount, roots, message) = QuadraticSolver.Solve(a, b, c);

            // Assert
            Assert.Equal(expectedRootCount, rootCount);
            Assert.Equal(expectedRoots, roots, new DoubleArrayComparer());
        }

        [Fact]
        public void Solve_CoefficientAIsZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 0, b = 2, c = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => QuadraticSolver.Solve(a, b, c));
        }
    }

    public class DoubleArrayComparer : IEqualityComparer<double[]>
    {
        public bool Equals(double[] x, double[] y)
        {
            if (x.Length != y.Length) return false;

            for (int i = 0; i < x.Length; i++)
            {
                if (!x[i].Equals(y[i])) return false;
            }

            return true;
        }

        public int GetHashCode(double[] obj)
        {
            return obj.Length.GetHashCode();
        }
    }
}
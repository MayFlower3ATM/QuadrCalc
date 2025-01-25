// Program solving quadratic equations
using System;

namespace QuadrCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj współczynniki równania kwadratowego (ax^2 + bx + c = 0):");

                Console.Write("Podaj a: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("Podaj b: ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.Write("Podaj c: ");
                double c = Convert.ToDouble(Console.ReadLine());

                var (rootCount, roots, message) = QuadraticSolver.Solve(a, b, c);

                Console.WriteLine(message);
                if (rootCount > 0)
                {
                    Console.WriteLine("Pierwiastki: " + string.Join(", ", roots));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
        }
    }
    public class QuadraticSolver
    {
        public static (int, double[], string) Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Współczynnik 'a' nie może się równać zero w równaniu kwadratowym.");
            }

            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
            {
                return (0, Array.Empty<double>(), "Brak pierwiastków rzeczywistych");
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return (1, new double[] { root }, "1 pierwiastek rzeczywisty");
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-b + sqrtDiscriminant) / (2 * a);
                double root2 = (-b - sqrtDiscriminant) / (2 * a);
                return (2, new double[] { root1, root2 }, "2 pierwiastki rzeczywiste");
            }
        }
    }
}
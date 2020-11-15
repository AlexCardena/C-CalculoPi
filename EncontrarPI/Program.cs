using System;

namespace EncontrarPI
{
    class Program
    {
        static void Main(string[] args)
        {
			long num_pasos = 10000000;
			double paso;
			double sum,pi;
			paso = 1.0 / (double)num_pasos;
			double x;
			sum = 0.0;	
            #pragma omp parallel for private(i) reduction(+:sum) reduction(+:x)
			for (int i = 0; i < num_pasos; i++)
			{
				x = (i + 0.5) * paso;
				sum = sum + 4.0 / (1.0 + x * x);
			}
			pi = paso * sum;
			Console.WriteLine("El valor de pi es "+ pi);
		}
    }
}

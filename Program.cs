using System;

namespace Examen
{
    internal class Program
    {
        static double Precio;
        static int cantidad;
        static int Pro = 6;
        static string[] Proovedores = new string[Pro];
        static double[] Montos_Netos = new double[Pro];
        static string[] codigos = new string[Pro];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("       Sistema de Control de Ordenes de Compra       ");
            Console.WriteLine("=====================================================");
        }

        static public void Ingresar_Proovedores()
        {
            if (contador >= Pro)
            {
                Console.WriteLine("No se pueden ingresar mas proveedores.");
                return;
            }

            Console.WriteLine("Ingrese el nombre del proveedor:");
            string Proovedor = Console.ReadLine();

            Console.WriteLine("Ingrese el codigo del proveedor:");
            string codigo = Console.ReadLine();

            Console.WriteLine("Ingrese el precio:");
            Precio = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad:");
            cantidad = int.Parse(Console.ReadLine());

            double Monto_Neto = Precio * cantidad;

            Proovedores[contador] = Proovedor;
            Montos_Netos[contador] = Monto_Neto;
            codigos[contador] = codigo;

            contador++;

            Console.WriteLine("Proveedor registrado correctamente.");
            Console.WriteLine("Monto Neto: " + Monto_Neto);
        }

        static public void Buscar_Proovedor()
        {
            Console.WriteLine("Ingrese el nombre del proveedor a buscar:");
            string Proovedor = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (Proovedores[i] == Proovedor)
                {
                    Console.WriteLine("Proveedor: " + Proovedores[i]);
                    Console.WriteLine("Codigo: " + codigos[i]);
                    Console.WriteLine("Monto Neto: " + Montos_Netos[i]);

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }

        static public void Mostrar()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("--------> Reporte Ordenado Por Monto Neto <----------");
            Console.WriteLine("=====================================================");

            Console.WriteLine("Codigos\t\tProveedores\t\tMonto Neto\t\t");

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(
                    codigos[i] + "\t\t" +
                    Proovedores[i] + "\t\t" +
                    Montos_Netos[i] + "\t\t");
            }
        }

        static public void Ordenar()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("--------> Ordenamiento Burbuja <-------");
            Console.WriteLine("***************************************");

            double tempMonto;
            string tempProveedor;
            string tempCodigo;

            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (Montos_Netos[j] < Montos_Netos[j + 1])
                    {
                        tempMonto = Montos_Netos[j];
                        Montos_Netos[j] = Montos_Netos[j + 1];
                        Montos_Netos[j + 1] = tempMonto;

                        tempProveedor = Proovedores[j];
                        Proovedores[j] = Proovedores[j + 1];
                        Proovedores[j + 1] = tempProveedor;

                        tempCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCodigo;
                    }
                }
            }

            Mostrar();
        }

        static void Main(string[] args)
        {
            int Opcion = 0;

            Titulo();

            while (Opcion != 4)
            {
                Console.WriteLine("\n----------> MENU PRINCIPAL <----------");
                Console.WriteLine("[1] Ingresar Monto Neto");
                Console.WriteLine("[2] Buscar Proveedor");
                Console.WriteLine("[3] Mostrar Reporte por Monto Neto (Burbuja)");
                Console.WriteLine("[4] Salir");

                Console.Write("Ingresar opcion: ");
                Opcion = int.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        Ingresar_Proovedores();
                        break;

                    case 2:
                        Buscar_Proovedor();
                        break;

                    case 3:
                        Ordenar();
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnoo
{
    using System;

    class Vehiculos
    {
        static int tamano = 2;
        static int[] numeroFactura = new int[tamano];
        static int[] tipoVehiculo = new int[tamano];
        static int[] numeroCaseta = new int[tamano];
        static string[] numeroPlaca = new string[tamano];
        static string[] pagaCon = new string[tamano];
        static DateTime fecha = DateTime.Now;
        static DateTime hora = DateTime.Now;
        static double[] montoPagar = new double[tamano];
        static double[] vuelto = new double[tamano];

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú Principal del Sistema:");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Ingresar Paso Vehicular");
                Console.WriteLine("3. Consulta de vehículos x Número de Placa");
                Console.WriteLine("4. Modificar Datos Vehículos x número de Placa");
                Console.WriteLine("5. Reporte Todos los Datos de los vectores");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;
                    case 2:
                        IngresarPasoVehicular();
                        break;
                    case 3:
                        ConsultarPorPlaca();
                        break;
                    case 4:
                        ModificarPorPlaca();
                        break;
                    case 5:
                        ReporteTodosDatos();
                        break;
                    case 6:
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            } while (opcion != 6);
        }

        static void InicializarVectores()
        {
            for (int i = 0; i < tamano; i++)
            {
                numeroFactura[i] = 0;
                tipoVehiculo[i] = 0;
                numeroCaseta[i] = 0;
                numeroPlaca[i] = "";
                pagaCon[i] = "";
                montoPagar[i] = 0;
                vuelto[i] = 0;
            }
            Console.WriteLine("Vectores inicializados correctamente.");
        }

        static void IngresarPasoVehicular()
        {
            Console.WriteLine("Ingrese los datos del vehículo:");
            Console.Write("Número de factura: ");
            numeroFactura[0] = int.Parse(Console.ReadLine());
            Console.Write("Número de placa: ");
            numeroPlaca[0] = Console.ReadLine();
            Console.WriteLine("Tipo de vehículo (1=Moto, 2=Vehículo Liviano, 3=Camión o Pesado, 4=Autobús): ");
            tipoVehiculo[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("Número de caseta (1, 2, 3): ");
            numeroCaseta[0] = int.Parse(Console.ReadLine());
            montoPagar[0] = CalcularMontoPagar(tipoVehiculo[0]);
            Console.WriteLine("Monto a pagar: " + montoPagar[0]);
            Console.Write("Paga con: ");
            pagaCon[0] = Console.ReadLine();
            vuelto[0] = CalcularVuelto(montoPagar[0], pagaCon[0]);
            Console.WriteLine("Vuelto: " + vuelto[0]);
            Console.WriteLine("Datos ingresados correctamente.");
        }

        static double CalcularMontoPagar(int tipoVehiculo)
        {
            switch (tipoVehiculo)
            {
                case 1:
                    return 500;
                case 2:
                    return 700;
                case 3:
                    return 2700;
                case 4:
                    return 3700;
                default:
                    return 0;
            }
        }

        static double CalcularVuelto(double montoPagar, string pagaCon)
        {
            double cantidadPagada = double.Parse(pagaCon);
            return cantidadPagada - montoPagar;
        }

        static void ConsultarPorPlaca()
        {
            Console.WriteLine("Ingrese el número de placa:");
            string placa = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < tamano; i++)
            {
                if (numeroPlaca[i] == placa)
                {
                    Console.WriteLine("Número de factura: " + numeroFactura[i]);
                    Console.WriteLine("Número de placa: " + numeroPlaca[i]);
                    Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                    Console.WriteLine("Número de caseta: " + numeroCaseta[i]);
                    Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                    Console.WriteLine("Paga con: " + pagaCon[i]);
                    Console.WriteLine("Vuelto: " + vuelto[i]);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron vehículos con el número de placa proporcionado.");
            }
        }

        static void ModificarPorPlaca()
        {
            Console.WriteLine("Ingrese el número de placa del vehículo que desea modificar:");
            string placa = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < tamano; i++)
            {
                if (numeroPlaca[i] == placa)
                {
                    Console.WriteLine("Datos del vehículo encontrado:");
                    Console.WriteLine("Número de factura: " + numeroFactura[i]);
                    Console.WriteLine("Número de placa: " + numeroPlaca[i]);
                    Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                    Console.WriteLine("Número de caseta: " + numeroCaseta[i]);
                    Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                    Console.WriteLine("Paga con: " + pagaCon[i]);
                    Console.WriteLine("Vuelto: " + vuelto[i]);

                    Console.WriteLine("\nSeleccione el dato que desea modificar:");
                    Console.WriteLine("1. Número de factura");
                    Console.WriteLine("2. Tipo de vehículo");
                    Console.WriteLine("3. Número de caseta");
                    Console.WriteLine("4. Monto a pagar");
                    Console.WriteLine("5. Paga con");
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nuevo número de factura:");
                            numeroFactura[i] = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el nuevo tipo de vehículo:");
                            tipoVehiculo[i] = int.Parse(Console.ReadLine());
                            montoPagar[i] = CalcularMontoPagar(tipoVehiculo[i]);
                            Console.WriteLine("Nuevo monto a pagar: " + montoPagar[i]);
                            Console.WriteLine("Ingrese el nuevo paga con:");
                            pagaCon[i] = Console.ReadLine();
                            vuelto[i] = CalcularVuelto(montoPagar[i], pagaCon[i]);
                            break;
                        case 3:
                            Console.WriteLine("Ingrese el nuevo número de caseta:");
                            numeroCaseta[i] = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Ingrese el nuevo monto a pagar:");
                            montoPagar[i] = double.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese el nuevo paga con:");
                            pagaCon[i] = Console.ReadLine();
                            vuelto[i] = CalcularVuelto(montoPagar[i], pagaCon[i]);
                            break;
                        case 5:
                            Console.WriteLine("Ingrese el nuevo paga con:");
                            pagaCon[i] = Console.ReadLine();
                            vuelto[i] = CalcularVuelto(montoPagar[i], pagaCon[i]);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron vehículos con el número de placa proporcionado.");
            }
        }

        static void ReporteTodosDatos()
        {
            Console.WriteLine("Reporte de todos los datos de los vehículos:");
            for (int i = 0; i < tamano; i++)
            {
                if (numeroFactura[i] != 0)
                {
                    Console.WriteLine("Número de factura: " + numeroFactura[i]);
                    Console.WriteLine("Número de placa: " + numeroPlaca[i]);
                    Console.WriteLine("Tipo de vehículo: " + tipoVehiculo[i]);
                    Console.WriteLine("Número de caseta: " + numeroCaseta[i]);
                    Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                    Console.WriteLine("Paga con: " + pagaCon[i]);
                    Console.WriteLine("Vuelto: " + vuelto[i]);
                    Console.WriteLine("-------------------------------------");
                }
            }
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A889126.Actividad02
{
    class Aeropuertos
    {
        public void Aeropuerto()
        {
            List<string> Aeropuertos = new List<string>();

            Dictionary<string, int> Vuelos = new Dictionary<string, int>()
            { };

            Dictionary<int, string> ReservaVuelos = new Dictionary<int, string>()
            { };

            Dictionary<int, int> ReservaPasajeros = new Dictionary<int, int>()
            { };

            Dictionary<string, int> RelacionVuelos = new Dictionary<string, int>()
            { };

            string codigoAeropuerto;
            string vuelosSalida;
            string vuelosDestino;
            string ingreso;
            int capacidadVuelos = 0;
            string condicion;
            bool flag;

            //A
            do
            {
                do
                {
                    Console.WriteLine("Ingrese el codigo del aeropuerto: ");
                    codigoAeropuerto = Console.ReadLine();
                    flag = ValidarVacio(codigoAeropuerto, "Codigo de aeropuerto");
                } while (flag == false);

                codigoAeropuerto = codigoAeropuerto.ToUpper();
                Aeropuertos.Add(codigoAeropuerto);

                do
                {
                    Console.WriteLine("Escriba SI para agregar mas aeropuertos: ");
                    condicion = Console.ReadLine();
                    flag = ValidarVacio(condicion, "Condicion");
                } while (flag == false);

            } while (condicion == "SI");

            foreach (string aeropuertos in Aeropuertos)
            {
                Console.WriteLine($"Los aeropuertos son: {aeropuertos}");
            }


            //B
            do
            {
                do
                {
                    Console.WriteLine("Ingrese el codigo de la salida: ");
                    vuelosSalida = Console.ReadLine();
                    flag = ValidarVacio(vuelosSalida, "Vuelo de salida");
                } while (flag == false);

                vuelosSalida = vuelosSalida.ToUpper();

                do
                {
                    Console.WriteLine("Ingrese el codigo de destino: ");
                    vuelosDestino = Console.ReadLine();
                    flag = ValidarVacio(vuelosDestino, "Vuelo de destino");
                } while (flag == false);

                vuelosDestino = vuelosDestino.ToUpper();

                string SALDES = (vuelosSalida + "-" + vuelosDestino);

                do
                {
                    Console.WriteLine("Ingrese la capacidad del vuelo " + SALDES + ": ");
                    ingreso = Console.ReadLine();
                    flag = ValidarNumero(ingreso, ref capacidadVuelos);
                } while (flag == false);


                //Relaciono el viaje con la respectiva capacidad
                Vuelos.Add(SALDES, capacidadVuelos);

                do
                {
                    Console.WriteLine("Escriba SI para agregar mas aeropuertos: ");
                    condicion = Console.ReadLine();
                    flag = ValidarVacio(condicion, "Condicion");
                } while (flag == false);

            } while (condicion == "SI");


            foreach (KeyValuePair<string, int> vVuelos in Vuelos)
            {
                Console.WriteLine($"Los vuelos planeados son: {vVuelos.Key} y tienen una capacidad de {vVuelos.Value} pasajeros");
            }


            int numeroReserva = 0;
            string origen;
            string destino;
            int pasajerosAdultos = 0;
            int pasajerosMenores = 0;
            int pasajerosInfantes = 0;
            int cantidadPasajeros = 0;

            //C
            do
            {
                do
                {
                    Console.WriteLine("Ingrese el numero de reserva: ");
                    ingreso = Console.ReadLine();
                    flag = ValidarNumero(ingreso, ref numeroReserva);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Ingrese el origen: ");
                    origen = Console.ReadLine();
                    flag = ValidarVacio(origen, "Origen");
                } while (flag == false);

                origen = origen.ToUpper();

                do
                {
                    Console.WriteLine("Ingrese el nombre de destino: ");
                    destino = Console.ReadLine();
                    flag = ValidarVacio(destino, "Destino");
                } while (flag == false);

                destino = destino.ToUpper();

                string SALDESR = (origen + "-" + destino);

                //Relaciono el numero de reserva con el viaje
                ReservaVuelos.Add(numeroReserva, SALDESR);

                do
                {
                    Console.WriteLine("Cantidad de pasajeros adultos: ");
                    ingreso = Console.ReadLine();
                    flag = ValidarNumero(ingreso, ref pasajerosAdultos);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Cantidad de pasajeros menores (3 a 10 años): ");
                    ingreso = Console.ReadLine();
                    flag = ValidarNumero(ingreso, ref pasajerosMenores);
                } while (flag == false);

                do
                {
                    Console.WriteLine("Cantidad de pasajeros infantes (menores a 3 años): ");
                    ingreso = Console.ReadLine();
                    flag = ValidarNumero(ingreso, ref pasajerosInfantes);
                } while (flag == false);

                cantidadPasajeros += pasajerosAdultos + pasajerosMenores + pasajerosInfantes;

                //Relaciono numero de reserva con cantidad de pasajeros
                ReservaPasajeros.Add(numeroReserva, cantidadPasajeros);

                //Relaciono salida y destino de reserva con CPasajeros
                RelacionVuelos.Add(SALDESR, cantidadPasajeros);

                //Probar la manera para que funcione
                var result =
                               // first loop
                               Vuelos.Select(s =>
                               // second loop
                               RelacionVuelos.Where(f => (s.Key == f.Key) && s.Value > f.Value));

                //var dConsumos = Consumos.Where(c => dClientes.Keys.Contains(c.IdCliente))
                //        .GroupBy(x => x.IdCliente)
                //        .SelectMany(b => b.Where(c => c.Gasto == b.Max(d => d.Gasto)))
                //        .GroupBy(x => x.IdCliente)
                //        .ToDictionary(c => c.Key, v => v.ToList<Consumo>());

                //foreach (var maximo in dConsumos)
                //{
                //    Console.WriteLine("{0}\t{1}\t{2}", dClientes[maximo.Key].NombreCliente, dClientes[maximo.Key].Mercado, maximo.Value.First().Gasto);
                //}

                do
                {
                    Console.WriteLine("Escriba SI para agregar mas aeropuertos: ");
                    condicion = Console.ReadLine();
                    flag = ValidarVacio(condicion, "Condicion");
                } while (flag == false);
            } while (condicion == "SI");


            /*
             Yo tengo los datos de los vuelos disponibles almacenados acá, con su capacidad como value:
            Vuelos.Add(SALDES, CapacidadVuelos);

            Acá tengo los numeros de reserva con el vuelo correspondiente:
            RVuelos.Add(NReserva, SALDESR);

            Acá tengo los NReserva con la capadidad que van a ocupar:
            RPasajeros.Add(NReserva, CantidadPasajeros);

            1) quizas deberia relacionar la CantidadPasajeros con SALDESR para comparar con la cantidad de pasajeros disponibles y saber si puedo seguir agregando
            EJ: xx.Add(SALDESR, CantidadPasajeros);
            Recorro los dos diccionarios y veo si CapacidadVuelos sigue siendo mayor


             */

            //Ejercicio 4
            //foreach (----)
            //{
            //    Console.WriteLine($"Los vuelos asignados son.... ");
            //}

        }

        private bool ValidarNumero(string Numero, ref int Salida)
        {
            bool flag = false;

            if (!int.TryParse(Numero, out Salida))
            {
                Console.WriteLine("Usted debe ingresar un dato númerico.");
            }
            else if (Salida < 0)
            {
                Console.WriteLine("Usted debe ingresar un numero positivo.");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        private bool ValidarVacio(string Valor, string campoDependiendoDeVariable)
        {
            bool flag = false;

            if (string.IsNullOrEmpty(Valor))
            {
                Console.WriteLine("El campo " + campoDependiendoDeVariable + " no puede estar vacio");
            }
            if (!Valor.All(char.IsLetter))
            {
                Console.WriteLine("El campo " + campoDependiendoDeVariable + " debe tener letras");
            }
            if (Valor.Length != 3)
            {
                Console.WriteLine("El campo " + campoDependiendoDeVariable + " no puede ser mayor a 3 letras");
            }
            else
            {
                flag = true;
            }
            return flag;
        }

    }
}

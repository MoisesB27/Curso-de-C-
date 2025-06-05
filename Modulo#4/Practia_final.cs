using System;
using System.Collections.Generic;
using System.Linq;

namespace GimnasioConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sistema = new SistemaGimnasio();
            sistema.Iniciar();
        }
    }

    public class SistemaGimnasio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private int siguienteId = 1;

        public void Iniciar()
        {
            Console.Title = "Sistema de Gestión de Gimnasio";
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrecargarClientesDemo();

            bool salir = false;
            while (!salir)
            {
                MostrarMenuPrincipal();
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarNuevoCliente();
                        break;
                    case "2":
                        MostrarDetallesCliente();
                        break;
                    case "3":
                        ListarTodosClientes();
                        break;
                    case "4":
                        BuscarClientePorNombre();
                        break;
                    case "5":
                        DarDeBajaCliente();
                        break;
                    case "6":
                        ModificarCliente();
                        break;
                    case "7":
                        salir = true;
                        break;
                    default:
                        MostrarError("Opción no válida. Por favor, seleccione 1-7.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nGracias por usar el Sistema de Gestión de Gimnasio. ¡Hasta pronto!");
        }

        private void MostrarMenuPrincipal()
        {
            Console.Clear();
            DibujarEncabezado("MENÚ PRINCIPAL");

            Console.WriteLine("1. Registrar nuevo cliente");
            Console.WriteLine("2. Mostrar detalles de un cliente");
            Console.WriteLine("3. Listar todos los clientes");
            Console.WriteLine("4. Buscar cliente por nombre");
            Console.WriteLine("5. Dar de baja a un cliente");
            Console.WriteLine("6. Modificar datos de cliente");
            Console.WriteLine("7. Salir del sistema");
            Console.WriteLine("\nSeleccione una opción (1-7): ");
        }

        private void RegistrarNuevoCliente()
        {
            Console.Clear();
            DibujarEncabezado("REGISTRAR NUEVO CLIENTE");

            var cliente = new Cliente
            {
                Id = siguienteId++
            };

            Console.Write("Nombre: ");
            cliente.Nombre = ValidarEntradaRequerida();

            Console.Write("Apellido: ");
            cliente.Apellido = ValidarEntradaRequerida();

            Console.Write("Fecha de nacimiento (dd/mm/aaaa): ");
            cliente.FechaNacimiento = ValidarFecha();

            Console.Write("Teléfono: ");
            cliente.Telefono = Console.ReadLine();

            Console.Write("Email: ");
            cliente.Email = ValidarEmail();

            Console.Write("Tipo de membresía (Básica/Intermedia/Premium): ");
            cliente.TipoMembresia = ValidarMembresia();

            Console.Write("Fecha de inicio (dd/mm/aaaa): ");
            cliente.FechaInicio = ValidarFecha();

            Console.Write("Fecha de fin (dd/mm/aaaa): ");
            cliente.FechaFin = ValidarFecha(cliente.FechaInicio);

            clientes.Add(cliente);
            MostrarExito($"Cliente {cliente.NombreCompleto} registrado exitosamente con ID: {cliente.Id}");
        }

        private void MostrarDetallesCliente()
        {
            Console.Clear();
            DibujarEncabezado("DETALLES DEL CLIENTE");

            Console.Write("Ingrese el ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID no válido.");
                return;
            }

            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                MostrarError("Cliente no encontrado.");
                return;
            }

            MostrarDetallesCliente(cliente);
        }

        private void ListarTodosClientes()
        {
            Console.Clear();
            DibujarEncabezado("LISTADO DE CLIENTES");

            if (!clientes.Any())
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-12} {4,-10}", "ID", "Nombre", "Teléfono", "Membresía", "Estado");
            Console.WriteLine(new string('-', 65));

            foreach (var cliente in clientes.OrderBy(c => c.Apellido))
            {
                var estado = cliente.FechaFin >= DateTime.Today ? "Activo" : "Inactivo";
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,-12} {4,-10}",
                    cliente.Id,
                    cliente.NombreCompleto,
                    cliente.Telefono,
                    cliente.TipoMembresia,
                    estado);
            }

            Console.WriteLine($"\nTotal de clientes: {clientes.Count}");
        }

        private void BuscarClientePorNombre()
        {
            Console.Clear();
            DibujarEncabezado("BUSCAR CLIENTE POR NOMBRE");

            Console.Write("Ingrese nombre o apellido a buscar: ");
            var busqueda = Console.ReadLine().ToLower();

            var resultados = clientes.Where(c =>
                c.Nombre.ToLower().Contains(busqueda) ||
                c.Apellido.ToLower().Contains(busqueda)).ToList();

            if (!resultados.Any())
            {
                MostrarError("No se encontraron clientes con ese criterio.");
                return;
            }

            Console.WriteLine("\nResultados de la búsqueda:");
            Console.WriteLine("{0,-5} {1,-20} {2,-15}", "ID", "Nombre", "Teléfono");
            Console.WriteLine(new string('-', 45));

            foreach (var cliente in resultados)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-15}",
                    cliente.Id,
                    cliente.NombreCompleto,
                    cliente.Telefono);
            }
        }

        private void DarDeBajaCliente()
        {
            Console.Clear();
            DibujarEncabezado("DAR DE BAJA CLIENTE");

            Console.Write("Ingrese el ID del cliente a dar de baja: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID no válido.");
                return;
            }

            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                MostrarError("Cliente no encontrado.");
                return;
            }

            MostrarDetallesCliente(cliente);
            Console.Write("\n¿Está seguro que desea dar de baja a este cliente? (S/N): ");
            var confirmacion = Console.ReadLine().ToUpper();

            if (confirmacion == "S")
            {
                clientes.Remove(cliente);
                MostrarExito($"Cliente {cliente.NombreCompleto} ha sido dado de baja exitosamente.");
            }
            else
            {
                MostrarError("Operación cancelada.");
            }
        }

        private void ModificarCliente()
        {
            Console.Clear();
            DibujarEncabezado("MODIFICAR CLIENTE");

            Console.Write("Ingrese el ID del cliente a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID no válido.");
                return;
            }

            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                MostrarError("Cliente no encontrado.");
                return;
            }

            MostrarDetallesCliente(cliente);
            Console.WriteLine("\nIngrese los nuevos datos (deje en blanco para mantener el valor actual):");

            Console.Write($"Nombre ({cliente.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) cliente.Nombre = nombre;

            Console.Write($"Apellido ({cliente.Apellido}): ");
            var apellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellido)) cliente.Apellido = apellido;

            Console.Write($"Teléfono ({cliente.Telefono}): ");
            var telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) cliente.Telefono = telefono;

            Console.Write($"Email ({cliente.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) cliente.Email = ValidarEmail(email);

            Console.Write($"Tipo de membresía ({cliente.TipoMembresia}): ");
            var membresia = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(membresia)) cliente.TipoMembresia = ValidarMembresia(membresia);

            Console.Write($"Fecha de fin ({cliente.FechaFin:dd/MM/yyyy}): ");
            var fechaFin = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fechaFin)) cliente.FechaFin = ValidarFecha(cliente.FechaInicio, fechaFin);

            MostrarExito($"Datos del cliente {cliente.NombreCompleto} actualizados exitosamente.");
        }

        #region Métodos de apoyo
        private void DibujarEncabezado(string titulo)
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(titulo.PadLeft(25 + titulo.Length / 2).PadRight(50));
            Console.WriteLine(new string('=', 50) + "\n");
        }

        private void MostrarError(string mensaje)
        {
            var colorOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {mensaje}");
            Console.ForegroundColor = colorOriginal;
        }

        private void MostrarExito(string mensaje)
        {
            var colorOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nÉxito: {mensaje}");
            Console.ForegroundColor = colorOriginal;
        }

        private void MostrarDetallesCliente(Cliente cliente)
        {
            Console.WriteLine("\nDetalles del cliente:");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {cliente.Id}");
            Console.WriteLine($"Nombre completo: {cliente.NombreCompleto}");
            Console.WriteLine($"Fecha nacimiento: {cliente.FechaNacimiento:dd/MM/yyyy} (Edad: {cliente.Edad} años)");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Tipo membresía: {cliente.TipoMembresia}");
            Console.WriteLine($"Fecha inicio: {cliente.FechaInicio:dd/MM/yyyy}");
            Console.WriteLine($"Fecha fin: {cliente.FechaFin:dd/MM/yyyy}");
            Console.WriteLine($"Estado: {(cliente.FechaFin >= DateTime.Today ? "Activo" : "Inactivo")}");
            Console.WriteLine(new string('-', 40));
        }

        private string ValidarEntradaRequerida()
        {
            while (true)
            {
                var entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada;

                Console.Write("Este campo es requerido. Por favor ingrese un valor: ");
            }
        }

        private DateTime ValidarFecha(DateTime? minDate = null, string input = null)
        {
            while (true)
            {
                try
                {
                    var fechaStr = input ?? Console.ReadLine();
                    if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    {
                        if (minDate.HasValue && fecha < minDate.Value)
                        {
                            throw new Exception($"La fecha debe ser posterior a {minDate.Value:dd/MM/yyyy}");
                        }
                        return fecha;
                    }
                    throw new Exception("Formato de fecha inválido. Use dd/mm/aaaa");
                }
                catch (Exception ex)
                {
                    if (input != null) throw;
                    Console.Write($"{ex.Message}. Intente nuevamente: ");
                }
            }
        }

        private string ValidarEmail(string input = null)
        {
            while (true)
            {
                try
                {
                    var email = input ?? Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(email) && input == null)
                        return string.Empty;

                    if (!email.Contains("@") || !email.Contains("."))
                        throw new Exception("Email no válido");

                    return email;
                }
                catch (Exception ex)
                {
                    if (input != null) throw;
                    Console.Write($"{ex.Message}. Intente nuevamente: ");
                }
            }
        }

        private string ValidarMembresia(string input = null)
        {
            var tiposValidos = new[] { "Básica", "Intermedia", "Premium" };

            while (true)
            {
                try
                {
                    var membresia = input ?? Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(membresia)
                        return input == null ? "Básica" : throw new Exception("Tipo de membresía requerido");

                    if (tiposValidos.Contains(membresia, StringComparer.OrdinalIgnoreCase))
                        return char.ToUpper(membresia[0]) + membresia.Substring(1).ToLower();

                    throw new Exception("Tipo no válido. Opciones: Básica, Intermedia, Premium");
                }
                catch (Exception ex)
                {
                    if (input != null) throw;
                    Console.Write($"{ex.Message}. Intente nuevamente: ");
                }
            }
        }

        private void PrecargarClientesDemo()
        {
            clientes.Add(new Cliente
            {
                Id = siguienteId++,
                Nombre = "Juan",
                Apellido = "Pérez",
                FechaNacimiento = new DateTime(1985, 5, 15),
                Telefono = "555-1234",
                Email = "juan.perez@mail.com",
                TipoMembresia = "Premium",
                FechaInicio = DateTime.Today.AddMonths(-2),
                FechaFin = DateTime.Today.AddMonths(1)
            });

            clientes.Add(new Cliente
            {
                Id = siguienteId++,
                Nombre = "María",
                Apellido = "Gómez",
                FechaNacimiento = new DateTime(1990, 8, 22),
                Telefono = "555-5678",
                Email = "maria.gomez@mail.com",
                TipoMembresia = "Intermedia",
                FechaInicio = DateTime.Today.AddMonths(-6),
                FechaFin = DateTime.Today.AddDays(-5)
            });

            clientes.Add(new Cliente
            {
                Id = siguienteId++,
                Nombre = "Carlos",
                Apellido = "López",
                FechaNacimiento = new DateTime(1978, 3, 10),
                Telefono = "555-9012",
                Email = "carlos.lopez@mail.com",
                TipoMembresia = "Básica",
                FechaInicio = DateTime.Today.AddMonths(-1),
                FechaFin = DateTime.Today.AddMonths(11)
            });
        }
        #endregion
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string TipoMembresia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int Edad => DateTime.Today.Year - FechaNacimiento.Year -
                         (DateTime.Today.DayOfYear < FechaNacimiento.DayOfYear ? 1 : 0);
    }
}
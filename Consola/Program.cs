using ModeloDB;
using Modelo;
using System;
using Helpers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Consola
{
    public class Program
    {
        static void Main(string[] args)

        {

            Grabar grabar = new Grabar();
            grabar.DatosIni();

            using (var db = ModeloDBBuilder.Crear())
            {
                var listaHistorialCliente = db.historial_cliente
                    .Where(historial_cliente => historial_cliente.ClienteId == 1);
                double suma = 0;
                foreach (var item in listaHistorialCliente) {
                    suma += item.DiasRetrasoCliente;
                }
                double promedio = 0;
                promedio = suma / listaHistorialCliente.Count();

                var listaGarantes = db.garante
                    .Include(garante => garante.Cliente)
                    .ThenInclude(cliente => cliente.Garante)
                    ;

                Console.WriteLine("Listado de garantes");
                foreach (var garante in listaGarantes)
                {
                    Console.WriteLine(
                        garante.NombreGarante + " " + garante.ApellidoGarante 

                    ) ;
                }

               /*
                var listaMatriculas = db.matriculas
                    .Include(matricula => matricula.Estudiante)
                    .Include(matricula => matricula.Periodo)
                    .Include(matricula => matricula.Matricula_Dets)
                        .ThenInclude(matricula_dets => matricula_dets.Curso)
                    .Include(matricula => matricula.Matricula_Dets)
                        .ThenInclude(matricula_dets => matricula_dets.Calificacion)
                    ;

                Console.WriteLine("Lista de Matrículas");
                foreach (var matricula in listaMatriculas)
                {
                    Console.WriteLine(
                        matricula.MatriculaId + " " +
                        matricula.EstudianteId + " " +
                        matricula.Estudiante.Nombre + " " +
                        matricula.Periodo.Nombre
                        );
                    foreach (var dets in matricula.Matricula_Dets)
                    {
                        Console.WriteLine(
                            " - " +
                            dets.Matricula_DetId + " " +
                            dets.CursoId + " " +
                            dets.Curso.Nombre + " " +
                            (dets.Calificacion != null ?
                                "   - " + dets.Calificacion.Nota1 + " " + dets.Calificacion.Nota2 + " " + dets.Calificacion.Nota3
                                : "   - - - -")
                        );
                    }
                }
              
                */
            }
        }
    }
}

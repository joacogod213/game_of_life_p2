using System;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    // su única razón de cambio es "cómo se orquesta el flujo del
    // juego". No sabe leer archivos, ni calcular reglas, ni imprimir: delega cada cosa en
    // LectorArchivo, Grilla y Print respectivamente.
    // no es "experta" en ningún dato del dominio (no tiene el
    // tablero ni el archivo), sino que actúa como coordinador o controlador ya que
    // conoce a quién pedirle cada tarea, pero no la hace ella misma. Esto la
    // mantiene liviana y evita que concentre lógica que le corresponde a
    // otras clases.
    public class Game
    {
        private const int MilisegundosEntreGeneraciones = 500;

        /// <summary>
        /// Inicia el juego: lee el tablero desde un archivo, crea la grilla con las celulas iniciales,
        /// y luego, en un ciclo infinito, muestra el estado actual y calcula
        /// la siguiente generación.
        /// </summary>
        public void Iniciar(string rutaTablero)
        {
            LectorArchivo lector = new LectorArchivo();
            bool[,] celulasIniciales = lector.Leer(rutaTablero);
            Grilla grilla = new Grilla(celulasIniciales);
            Print print = new Print();

            while (true)
            {
                print.Mostrar(grilla);
                grilla.SiguienteGeneracion();
                Thread.Sleep(MilisegundosEntreGeneraciones);
            }
        }
    }
}

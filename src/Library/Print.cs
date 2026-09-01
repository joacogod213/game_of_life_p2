using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    // su única razón de cambio es "cómo se muestra el tablero"
    // (símbolos usados, formato de consola, etc.). No conoce las reglas del
    // juego ni cómo se lee el archivo, solo sabe recorrer una Grilla y
    // convertirla en texto.
    // no guarda ni calcula el estado del tablero, solo lo consume a
    // través de Grilla.EstaViva; por eso no es "experta" en el estado (esa
    // responsabilidad es de Grilla), pero sí es la clase indicada para
    // decidir cómo se representa visualmente cada célula.
    public class Print
    {
        /// <summary>
        /// Imprime el estado actual de la grilla por consola, representando
        /// las células vivas con "|X|" y las muertas con "___".
        /// </summary>
        public void Mostrar(Grilla grilla)
        {
            Console.Clear();
            StringBuilder texto = new StringBuilder();
            for (int y = 0; y < grilla.Alto; y++)
            {
                for (int x = 0; x < grilla.Ancho; x++)
                {
                    if (grilla.EstaViva(x, y))
                    {
                        texto.Append("|X|");
                    }
                    else
                    {
                        texto.Append("___");
                    }
                }

                texto.Append('\n');
            }

            Console.WriteLine(texto.ToString());
        }
    }
}

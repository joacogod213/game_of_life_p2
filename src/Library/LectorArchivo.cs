using System.IO;

namespace Ucu.Poo.GameOfLife
{
    // SRP: la única razón de cambio de esta clase es "cómo se lee el tablero
    // desde su fuente de datos" (formato de archivo, encoding, separadores).
    // No calcula generaciones ni imprime nada, así que no mezcla otras
    // responsabilidades.
    // Expert: es la clase que tiene toda la información necesaria para leer
    // el archivo (la ruta) y construir la matriz inicial, así que es la
    // indicada para hacerlo (nadie más necesita conocer el formato del
    // archivo de texto).
    public class LectorArchivo
    {
        /// <summary>
        /// Lee el archivo ubicado en <paramref name="ruta"/> y arma la matriz
        /// de booleanos que representa el estado inicial del tablero
        /// ('1' = célula viva, cualquier otro carácter = célula muerta).
        /// </summary>
        /// <param name="ruta">Ruta del archivo de texto con el tablero.</param>
        /// <returns>Matriz de booleanos con el estado inicial del tablero.</returns>
        public bool[,] Leer(string ruta)
        {
            string contenido = File.ReadAllText(ruta);
            string[] lineas = contenido.Split('\n');
            bool[,] tablero = new bool[lineas[0].Trim().Length, lineas.Length];
            for (int y = 0; y < lineas.Length; y++)
            {
                string lineaActual = lineas[y].Trim();
                for (int x = 0; x < lineaActual.Length; x++)
                {
                    if (lineaActual[x] == '1')
                    {
                        tablero[x, y] = true;
                    }
                }
            }

            return tablero;
        }
    }
}
namespace Ucu.Poo.GameOfLife
{
    // su única razón de cambio es la lógica del juego en sí. esto incluye las reglas
    // de Conway y el tamaño del tablero. No sabe leer archivos ni imprimir
    // por consola, así que un cambio en el formato de entrada o en la forma
    // de mostrar el tablero no la afecta.
    // es la clase que tiene el estado de las células (this.celulas),
    // así que es la que tiene la información necesaria para saber quién está
    // viva, contar vecinos y calcular la siguiente generación. Ninguna otra
    // clase debería conocer ni manipular esa matriz directamente.
    public class Grilla
    {
        private bool[,] celulas;

        public Grilla(bool[,] celulasIniciales)
        {
            this.celulas = celulasIniciales;
        }

        /// <summary>
        /// Gets el ancho (cantidad de columnas) del tablero.
        /// </summary>
        public int Ancho
        {
            get { return this.celulas.GetLength(0); }
        }

        /// <summary>
        /// Gets el alto (cantidad de filas) del tablero.
        /// </summary>
        public int Alto
        {
            get { return this.celulas.GetLength(1); }
        }

        /// <summary>
        /// Indica si la célula ubicada en (x, y) está viva.
        /// </summary>
        public bool EstaViva(int x, int y)
        {
            return this.celulas[x, y];
        }

        /// <summary>
        /// Calcula la siguiente generación del tablero aplicando las reglas
        /// de Conway (subpoblación, supervivencia, sobrepoblación y
        /// reproducción) y reemplaza el estado actual por el nuevo.
        /// </summary>
        public void SiguienteGeneracion()
        {
            bool[,] clon = new bool[this.Ancho, this.Alto];
            for (int x = 0; x < this.Ancho; x++)
            {
                for (int y = 0; y < this.Alto; y++)
                {
                    int vecinosVivos = this.ContarVecinosVivos(x, y);
                    if (this.celulas[x, y] && vecinosVivos < 2)
                    {
                        clon[x, y] = false;
                    }
                    else if (this.celulas[x, y] && vecinosVivos > 3)
                    {
                        clon[x, y] = false;
                    }
                    else if (!this.celulas[x, y] && vecinosVivos == 3)
                    {
                        clon[x, y] = true;
                    }
                    else
                    {
                        clon[x, y] = this.celulas[x, y];
                    }
                }
            }

            this.celulas = clon;
        }

        /// <summary>
        /// Cuenta cuántas de las 8 células vecinas de (x, y) están vivas.
        /// </summary>
        private int ContarVecinosVivos(int x, int y)
        {
            int vecinosVivos = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < this.Ancho && j >= 0 && j < this.Alto && this.celulas[i, j])
                    {
                        vecinosVivos++;
                    }
                }
            }

            if (this.celulas[x, y])
            {
                vecinosVivos--;
            }

            return vecinosVivos;
        }
    }
}

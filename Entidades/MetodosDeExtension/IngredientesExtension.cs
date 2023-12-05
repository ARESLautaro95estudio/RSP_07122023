using Entidades.Enumerados;


namespace Entidades.MetodosDeExtension
{
    public static class IngredientesExtension
    {
        public static double CalcularCostoIngrediente(this List<EIngrediente> lista,int costoInicial)
        {
            foreach (EIngrediente e in lista)
            { 
                costoInicial=costoInicial *((int)e/100);
            }
            return costoInicial;
        }
        public static List<EIngrediente> IngredientesAleatorios(this Random rand)
        { 
            List<EIngrediente> ingredientes = new List<EIngrediente>()
            {
                EIngrediente.QUESO,
                EIngrediente.PANCETA,
                EIngrediente.ADHERESO,
                EIngrediente.HUEVO,
                EIngrediente.JAMON,
            };
            return ingredientes.Take(rand.Next(1, ingredientes.Count + 1)).ToList<EIngrediente>();
        }
    }
}

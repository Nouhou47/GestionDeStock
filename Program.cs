using System;

namespace GestionDeStock
{
    public enum Etat
    {
        DISPONIBLE,
        EN_RUPTURE,
        EN_REAPPROVISIONNEMENT
    }
    class Program
    {     
        private const int taillePermiseNomProduit = 44;
        private const int taillePermiseStock = 10;
        private const int taillePermiseEtat = 24;
        static void Main(String[] args)
        {}

         /**
            * Cette méthode est nécessaire lors de 
            * l'affichage des produits dans le tableau.
        */
        static void afficherEspaceNFois(int n)
        {
            for (int i = 0; i<n; i++) Console.Write(" ");
        }

        /**
            * n fonction du stock d'un produit, 
            * son état exact est retourné.
        */
        static Etat etatExact(int quantite)
        {
            Etat state = Etat.EN_RUPTURE;
            
            if (quantite > 5) state = Etat.DISPONIBLE;
            if (quantite <= 5) state = Etat.EN_REAPPROVISIONNEMENT;
            if (quantite <= 0) state = Etat.EN_RUPTURE;
            
            return state;
        }
    }   
}
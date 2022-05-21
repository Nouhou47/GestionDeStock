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
            * Cette méthode permet de charger les enregistrements contenus dans
            * le fichier produits.txt. Un enregistrement représente un produit.  
        */        
        static List<Product> loadProductsIntoList(string filePath)
        {
            var lineProductsArray = File.ReadAllLines(filePath).ToList();
            var products = new List<Product>();

            int id;
            int stock;
            string name;
            Etat etat;
            string[] productDataArray;

            foreach( var line in lineProductsArray)
            {
                productDataArray = line.Split(":");

                int.TryParse(productDataArray[0], out id);
                name = productDataArray[1];

                int.TryParse(productDataArray[2], out stock);
                etat = etatExact(stock);

                Product p = new Product(id, name, stock, etat);
                products.Add(p);
            }
            return products;
        }

        /**
            * Cette méthode prend en paramètre un objet Etat et
            * retourne sa valeur en chaine de caractères.
        */
        static string matchEtatToString(Etat etat)
        {
            string state;

            switch (etat)
            {
                case Etat.DISPONIBLE:
                    state = "Disponible";
                break;
                case Etat.EN_RUPTURE:
                    state = "Rupture";
                break;
                case Etat.EN_REAPPROVISIONNEMENT:
                    state = "Réapprovisionnement";
                break;
                default: state = "Rupture";
                break;
            }
            return state;
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
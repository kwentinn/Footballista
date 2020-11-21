namespace Footballista.Wasm.Client.Routing
{
	internal static class AllRoutes
	{
		public static Route Home = new Route("/home", "Page d'accueil");
		public static Route Career = new Route("/career", "", Children: new Route[] 
		{
			new Route("/create", "Créer carrière"),
			new Route("/load", "Charger carrière existante")
		});
	}
}

POUR CREER DES TABLES VIA MIGRATIONS SUR C# :
- Creer la classe correspondante a la table voulue
- Bien definir les champs, les relations avec d'autres tables
- Ouvrir le fichier AppDbContext.cs
- Ecrire : public DbSet<NomClasse> NomTable { get; set; }
- Dans Visual Studio > Tools > NuGet Package Manager > Package Manager Console :
- Generer la migration en ecrivant: Add-Migration AddNomTable
- Mettre a jour en écrivant : Update-Database
 



using EspacioPersonaje;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Personaje personaje;
personaje =  new FabricaDePersonaje().CrearPersonaje();
System.Console.WriteLine(personaje.Nombre+", "+personaje.Apodo);
List<Personaje> listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();

for (int i = 0; i < 10; i++){
    listaDePersonajes.Add(fp.CrearPersonaje());
}
PersonajesJson pjson = new PersonajesJson();
pjson.GuardarPersonajes(listaDePersonajes, "Personajes");

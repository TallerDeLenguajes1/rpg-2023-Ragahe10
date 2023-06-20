using EspacioPersonaje;
using EspacioCombates;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();
PersonajesJson pjson = new PersonajesJson();

if(!(pjson.Existe("Personajes.json"))){
    for (int i = 0; i < 16; i++){
        listaDePersonajes.Add(fp.CrearPersonaje());
    }
    pjson.GuardarPersonajes(listaDePersonajes, "Personajes");
}
listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
if(listaDePersonajes != null){
    var combate = new Combates();
    listaDePersonajes = combate.Sorteo(listaDePersonajes);
    System.Console.WriteLine("--------------------------");
    listaDePersonajes[0].MostrarPersonaje();
    System.Console.WriteLine("--------------------------");
    listaDePersonajes[1].MostrarPersonaje();
    System.Console.WriteLine("--------------------------");
    // System.Console.WriteLine("---------PERSONAJES-------");
    // foreach (var personaje in listaDePersonajes){
    //    personaje.MostrarPersonaje();
    // }
    // System.Console.WriteLine("--------------------------");
    combate.Combate(listaDePersonajes[0],listaDePersonajes[1]).MostrarPersonaje();
}else{
    System.Console.WriteLine("no hay personajes");
}

using EspacioPersonaje;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();
PersonajesJson pjson = new PersonajesJson();

if(!(pjson.Existe("Personajes.json"))){
    for (int i = 0; i < 10; i++){
    listaDePersonajes.Add(fp.CrearPersonaje());
    }
    pjson.GuardarPersonajes(listaDePersonajes, "Personajes");
}
listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
if(listaDePersonajes != null){
    System.Console.WriteLine("---------PERSONAJES-------");
    foreach (var personaje in listaDePersonajes){
       personaje.MostrarPersonaje();
    }
    System.Console.WriteLine("--------------------------");
}else{
    System.Console.WriteLine("no hay personajes");
}

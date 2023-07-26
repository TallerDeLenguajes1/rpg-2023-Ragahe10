using EspacioPersonaje;
using InterfasVisual;
// See https://aka.ms/new-console-template for more information
Console.Clear();
Conductor.CrearConductor();
Interfas.Presentacion();
List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();
PersonajesJson pjson = new PersonajesJson();
var restablecer = pjson.LeerPersonajes("PersonajesPrueba.json");
if(restablecer!=null){
    pjson.GuardarPersonajes(restablecer,"Personajes");
}
if(!(pjson.Existe("Personajes.json"))){
    for (int i = 1; i < 10; i++){
        listaDePersonajes.Add(fp.CrearPersonaje());
    }
    pjson.GuardarPersonajes(listaDePersonajes, "Personajes");
}
listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
if(listaDePersonajes != null){
    Interfas.Menu(pjson, fp);
}else{
    Console.WriteLine("no hay personajes");
}
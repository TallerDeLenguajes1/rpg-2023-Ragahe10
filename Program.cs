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
        System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
        System.Console.WriteLine(" - NOMBRE: "+ personaje.Nombre);
        System.Console.WriteLine(" - APODO: "+ personaje.Apodo);
        System.Console.WriteLine(" - TIPO: "+ personaje.Tipo);
        System.Console.WriteLine(" - FECHA DE NACIMIENTO: "+ personaje.FechaDeNacimiento);
        System.Console.WriteLine(" - EDAD: "+ personaje.Edad);
        System.Console.WriteLine(" - NIVEL: "+ personaje.Nivel);
        System.Console.WriteLine(" - SALUD: "+ personaje.Salud);
        System.Console.WriteLine(" - VELOCIDAD: "+ personaje.Velocidad);
        System.Console.WriteLine(" - DESTREZA: "+ personaje.Destreza);
        System.Console.WriteLine(" - FUERZA: "+ personaje.Fuerza);
        System.Console.WriteLine(" - ARMADURA: "+ personaje.Armadura);
    }
    System.Console.WriteLine("--------------------------");
}else{
    System.Console.WriteLine("no hay personajes");
}

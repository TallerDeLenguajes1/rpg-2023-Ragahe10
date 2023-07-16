using EspacioPersonaje;
using EspacioCombates;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Presentacion();
Console.ReadKey();
Console.Clear();

List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();
PersonajesJson pjson = new PersonajesJson();

if(!(pjson.Existe("Personajes.json"))){
    for (int i = 1; i < 10; i++){
        listaDePersonajes.Add(fp.CrearPersonaje(i));
    }
    pjson.GuardarPersonajes(listaDePersonajes, "Personajes");
}
listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
if(listaDePersonajes != null){
    Menu(pjson, listaDePersonajes);
}else{
    Console.WriteLine("no hay personajes");
}

// listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
// if(listaDePersonajes != null){
//     var combate = new Combates();
//     combate.Torneo(listaDePersonajes);
// }else{
//     System.Console.WriteLine("no hay personajes");
// }

static void Presentacion()
{
    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
    Console.WriteLine("│ ┌───────┐┌───────┐  ┌────────────┐  ┌──────────┐   	 ┌───┐        ┌───┐  ┌────────────┐  ┌──────────┐   │");
    Console.WriteLine("│ │       └┘       │  │            │  │          └─┐ 	 │   │        │   │  │            │  │          └─┐ │");
    Console.WriteLine("│ │   ┌──┐  ┌──┐   │  │  ┌──────┐  │  │  ┌─────┐   └┐	 │   │        │   │  │  ┌──────┐  │  │  ┌─────┐   │ │");
    Console.WriteLine("│ │   │  │  │  │   │  │  │      │  │  │  │     └─┐  │	 │   │        │   │  │  │      │  │  │  │     └┐  │ │");
    Console.WriteLine("│ │   │  │  │  │   │  │  │      │  │  │  │       │  │	 │   │        │   │  │  │      │  │  │  │     ┌┘  │ │");
    Console.WriteLine("│ │   │  │  │  │   │  │  └──────┘  │  │  │       │  │	 │   │  ┌──┐  │   │  │  └──────┘  │  │  └─────┘  ┌┘ │");
    Console.WriteLine("│ │   │  │  │  │   │  │            │  │  │       │  │	 │   │  │  │  │   │  │            │  │         ┌─┘  │");
    Console.WriteLine("│ │   │  └──┘  │   │  │  ┌──────┐  │  │  │       │  │	 │   │  │  │  │   │  │  ┌──────┐  │  │  ┌───┐  └─┐  │");
    Console.WriteLine("│ │   │        │   │  │  │      │  │  │  │     ┌─┘  │	 │   │  │  │  │   │  │  │      │  │  │  │   └─┐  └┐ │");
    Console.WriteLine("│ │   │        │   │  │  │      │  │  │  └─────┘   ┌┘	 │   └──┘  └──┘   │  │  │      │  │  │  │     └┐  │ │");
    Console.WriteLine("│ │   │        │   │  │  │      │  │  │          ┌─┘ 	 │       ┌┐       │  │  │      │  │  │  │      │  │ │");
    Console.WriteLine("│ └───┘        └───┘  └──┘      └──┘  └──────────┘   	 └───────┘└───────┘  └──┘      └──┘  └──┘      └──┘ │");
    Console.WriteLine("└───────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
    Console.WriteLine("                                          >>press ENTER to start<<");
}
static void Menu(PersonajesJson pjson, List<Personaje> listaP)
{
    ConsoleKeyInfo key, aux;
    int option = 1, salida=0;
    
    do{
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                 ╔══════╗                 ║");
        Console.WriteLine("║                 ║INICIO║                 ║");
        Console.WriteLine("║                 ╚══════╝                 ║");
        Console.WriteLine("║         ┌─────────────────────┐          ║");
        if(option == 1){
            Console.WriteLine("║        >│1.      Jugar      .1│<         ║");
        }else{
            Console.WriteLine("║         │1.      Jugar      .1│          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 2){
            Console.WriteLine("║        >│2.    Personajes   .2│<         ║");
        }else{
            Console.WriteLine("║         │2.    Personajes   .2│          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 3){
            Console.WriteLine("║        >│3.      SALIR      .3│<         ║");
        }else{
            Console.WriteLine("║         │3.      SALIR      .3│          ║");
        }
        Console.WriteLine("║         └─────────────────────┘          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        key = Console.ReadKey();
        Console.Clear();
        if(key.Key == ConsoleKey.Enter){
            switch (option){
                case 1:
                    //menu para elejir personaje y empezar partida
                    break;
                case 2:
                    int i = 0;
                    do{
                        Console.Clear();
                        System.Console.WriteLine("          ╔══════════════════════╗");
                        System.Console.WriteLine("          ║  >>> PERSONAJES <<<  ║");
                        System.Console.WriteLine("          ╚══════════════════════╝");
                        listaP[i].MostrarPersonaje();
                        System.Console.WriteLine("'Usa las flechas para avanzar o retroceder'");
                        System.Console.WriteLine("        >>Toca ESC para volver<<");
                        aux = Console.ReadKey(intercept: true);
                        if(aux.Key == ConsoleKey.RightArrow || aux.Key == ConsoleKey.UpArrow){
                            i++;
                        }else if(aux.Key == ConsoleKey.LeftArrow || aux.Key == ConsoleKey.DownArrow){
                            i--;
                        }
                        if(i<0){
                            i = (listaP.Count()-1);
                        }else if(i>(listaP.Count()-1)){
                            i = 0;
                        }
                    }while(aux.Key != ConsoleKey.Escape );
                    break;
                case 3:
                    salida = 3;
                    break;
            }
        }else if(key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.DownArrow){
            option++;
        }else if(key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.UpArrow){
            option--;
        }
        if(option<1){
            option = 3;
        }else if(option>3){
            option = 1;
        }
        Console.Clear();
    }while(salida != 3 && key.Key != ConsoleKey.Escape);
}

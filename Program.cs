using EspacioPersonaje;
using EspacioCombates;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Presentacion();

List<Personaje>? listaDePersonajes = new List<Personaje>();

var fp = new FabricaDePersonaje();
PersonajesJson pjson = new PersonajesJson();

if(!(pjson.Existe("Personajes.json"))){
    for (int i = 1; i < 10; i++){
        listaDePersonajes.Add(fp.CrearPersonaje());
    }
    pjson.GuardarPersonajes(listaDePersonajes, "Personajes");
}
listaDePersonajes = pjson.LeerPersonajes("Personajes.json");
if(listaDePersonajes != null){
    Menu(pjson, listaDePersonajes, fp);
}else{
    Console.WriteLine("no hay personajes");
}

static void Presentacion()
{
    Console.WriteLine("┌─────────────────────────────────────────────────────────────────────────────────────────┐");
    Console.WriteLine("│ ┌───────┐┌───────┐┌──────────┐┌────────┐     ┌───┐        ┌───┐┌──────────┐┌────────┐   │");
    Console.WriteLine("│ │       └┘       ││          ││        └─┐   │   │        │   ││          ││        └─┐ │");
    Console.WriteLine("│ │   ┌──┐  ┌──┐   ││  ┌────┐  ││  ┌───┐   └┐  │   │        │   ││  ┌────┐  ││  ┌───┐   │ │");
    Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │   └─┐  │  │   │        │   ││  │    │  ││  │   └┐  │ │");
    Console.WriteLine("│ │   │  │  │  │   ││  │    │  ││  │     │  │  │   │        │   ││  │    │  ││  │   ┌┘  │ │");
    Console.WriteLine("│ │   │  │  │  │   ││  └────┘  ││  │     │  │  │   │  ┌──┐  │   ││  └────┘  ││  └───┘  ┌┘ │");
    Console.WriteLine("│ │   │  └──┘  │   ││  ┌────┐  ││  │     │  │  │   │  │  │  │   ││  ┌────┐  ││       ┌─┘  │");
    Console.WriteLine("│ │   │        │   ││  │    │  ││  │   ┌─┘  │  │   │  │  │  │   ││  │    │  ││  ┌─┐  └─┐  │");
    Console.WriteLine("│ │   │        │   ││  │    │  ││  └───┘   ┌┘  │   └──┘  └──┘   ││  │    │  ││  │ └─┐  └┐ │");
    Console.WriteLine("│ │   │        │   ││  │    │  ││        ┌─┘   │       ┌┐       ││  │    │  ││  │   └┐  │ │");
    Console.WriteLine("│ └───┘        └───┘└──┘    └──┘└────────┘     └───────┘└───────┘└──┘    └──┘└──┘    └──┘ │");
    Console.WriteLine("└─────────────────────────────────────────────────────────────────────────────────────────┘");
    Console.WriteLine("                                 >>press ENTER to start<<");
    Console.ReadKey();
    Console.Clear();
}

static void Menu(PersonajesJson pjson, List<Personaje> listaP, FabricaDePersonaje fp){
    ConsoleKeyInfo key;
    int option = 1, salida=0;
    
    do{
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                 ╔══════╗                 ║");
        Console.WriteLine("║                 ║INICIO║                 ║");
        Console.WriteLine("║                 ╚══════╝                 ║");
        Console.WriteLine("║         ┌─────────────────────┐          ║");
        if(option == 1){
            Console.WriteLine("║        »│ .      Jugar      . │«         ║");
        }else{
            Console.WriteLine("║         │ .      Jugar      . │          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 2){
            Console.WriteLine("║        »│ .    Personajes   . │«         ║");
        }else{
            Console.WriteLine("║         │ .    Personajes   . │          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 3){
            Console.WriteLine("║        »│ .      SALIR      . │«         ║");
        }else{
            Console.WriteLine("║         │ .      SALIR      . │          ║");
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
                    OpJugar(listaP, fp);
                    break;
                case 2:
                    OpPersonajes(listaP, fp);
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
            option = 1;
        }else if(option>3){
            option = 3;
        }
        Console.Clear();
    }while(salida != 3 && key.Key != ConsoleKey.Escape);
}

static void OpJugar(List<Personaje> listaP, FabricaDePersonaje fp){
    ConsoleKeyInfo key;
    int option = 1, salida=0;
    
    do{
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║                ╔═══════╗                 ║");
        Console.WriteLine("║                ║ JUGAR ║                 ║");
        Console.WriteLine("║                ╚═══════╝                 ║");
        Console.WriteLine("║         ┌─────────────────────┐          ║");
        if(option == 1){
            Console.WriteLine("║        »│ .     1 vs 1      . │«         ║");
        }else{
            Console.WriteLine("║         │ .     1 vs 1      . │          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 2){
            Console.WriteLine("║        »│ .     Torneo      . │«         ║");
        }else{
            Console.WriteLine("║         │ .     Torneo      . │          ║");
        }
        Console.WriteLine("║         ├─────────────────────┤          ║");
        if(option == 3){
            Console.WriteLine("║        »│ .     VOLVER      . │«         ║");
        }else{
            Console.WriteLine("║         │ .     VOLVER      . │          ║");
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
                    //
                    break;
                case 2:
                    //
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
            option = 1;
        }else if(option>3){
            option = 3;
        }
        Console.Clear();
    }while(salida != 3 && key.Key != ConsoleKey.Escape);
}

static void OpPersonajes(List<Personaje> listaP, FabricaDePersonaje fp){
    int i = 0, prim = listaP.Count()-1;
    ConsoleKeyInfo aux;
    int op =1, salida =0;
    do{
        Console.Clear();
        System.Console.WriteLine("          ╔══════════════════════╗");
        System.Console.WriteLine("          ║  >>> PERSONAJES <<<  ║");
        System.Console.WriteLine("          ╚══════════════════════╝");
        listaP[i].MostrarPersonaje();
        System.Console.WriteLine("'Usa las flechas (<- ó ->)para cambiar de personaje'");
        System.Console.WriteLine("          ┌─────────────────────┐");
        if(op == 1){
        System.Console.WriteLine("         »│ . Crear Personaje . │«");
        }else{
        System.Console.WriteLine("          │ . Crear Personaje . │");
        }
        System.Console.WriteLine("          ├─────────────────────┤");
        if(i>prim){
            if(op == 2){
            System.Console.WriteLine("         »│ .      SALIR      . │«");
            }else{
            System.Console.WriteLine("          │ .      SALIR      . │");
            }
            System.Console.WriteLine("          ├─────────────────────┤");
            if(op == 3){
            System.Console.WriteLine("         »│ .      BORRAR     . │«");
            }else{
            System.Console.WriteLine("          │ .      BORRAR     . │");
            }
            System.Console.WriteLine("          └─────────────────────┘");
            aux = Console.ReadKey(intercept: true);
            if(aux.Key == ConsoleKey.UpArrow){
                op--;
            }else if(aux.Key == ConsoleKey.DownArrow){
                op++;
            }
            if(op<0){
                op = 1;
            }else if(op>3){
                op = 3;
            }
        }else{
            if(op == 2){
            System.Console.WriteLine("         »│ .      SALIR      . │«");
            }else{
            System.Console.WriteLine("          │ .      SALIR      . │");
            }
            System.Console.WriteLine("          └─────────────────────┘");
            aux = Console.ReadKey(intercept: true);
            if(aux.Key == ConsoleKey.UpArrow){
                op--;
            }else if(aux.Key == ConsoleKey.DownArrow){
                op++;
            }
            if(op<0){
                op = 1;
            }else if(op>2){
                op = 2;
            }
        }
        if(aux.Key == ConsoleKey.RightArrow){
            i++;
        }else if(aux.Key == ConsoleKey.LeftArrow){
            i--;
        }
        if(i<0){
            i = (listaP.Count()-1);
        }else if(i>(listaP.Count()-1)){
            i = 0;
        }
        if(aux.Key == ConsoleKey.Enter){
            if(op==1){
                var nuevo = fp.CrearPersonaje();
                string? name;
                do{
                    Console.Clear();
                    System.Console.WriteLine("          ╔═══════════════════════╗");
                    System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                    System.Console.WriteLine("          ╚═══════════════════════╝");
                    System.Console.WriteLine("Ingrese el NOMBRE del Personaje: ");
                    name = Console.ReadLine();
                }while(name == null || name =="");
                nuevo.Nombre = name;
                do{
                    Console.Clear();
                    System.Console.WriteLine("          ╔═══════════════════════╗");
                    System.Console.WriteLine("          ║ >> CREAR PERSONAJE << ║");
                    System.Console.WriteLine("          ╚═══════════════════════╝");
                    System.Console.WriteLine(">>NOMBRE: "+ nuevo.Nombre);
                    System.Console.WriteLine("Ingrese el APODO del Personaje: ");
                    name = Console.ReadLine();
                    if(name == null || name ==""){
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.WindowWidth));
                    }
                }while(name ==null || name =="");
                nuevo.Apodo = name;
                listaP.Add(nuevo);
                Console.Clear();
            }else if(op ==2){
                salida = 1;
            }else if(op==3){
                listaP.Remove(listaP[i]);
                op=1;
                i--;
            }
        }
    }while(aux.Key != ConsoleKey.Escape && salida !=1);
}

// static void VaciarPersonajes(string ruta){
//         // Verifica si el archivo existe antes de intentar borrarlo
//         if (File.Exists(ruta))
//         {
//             File.Delete(ruta);
//             //Console.WriteLine("El archivo ha sido borrado correctamente.");
//         }
//         else
//         {
//             //Console.WriteLine("El archivo no existe.");
//         }
// }
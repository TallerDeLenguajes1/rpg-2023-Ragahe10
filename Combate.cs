using EspacioPersonaje;
namespace EspacioCombates;

public class Combates{
    public List<Personaje> Sorteo(List<Personaje> listaP){
        var Comb = new List<Personaje>();
        var random = new Random();
        Personaje p;
        while(listaP.Count()!=0){
            p = listaP[random.Next(0,listaP.Count())];
            Comb.Add(p);
            listaP.Remove(p);
        }
        return Comb;
    }

    public void EscribirMensaje(string message){
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(100); // Retardo de 100 milisegundos entre cada carácter
        }
        Console.WriteLine();
    }
    public Personaje PeleaIndividual(Personaje p1, Personaje p2){
        //Guardar datos iniciales{
        Personaje auxp1 = new Personaje(), auxp2 = new Personaje();
        auxp1.Nombre = p1.Nombre;
        auxp1.Apodo = p1.Apodo;
        auxp1.Edad = p1.Edad;
        auxp1.Nivel = p1.Nivel;
        auxp1.Especial = p1.Especial;
        auxp1.FechaDeNacimiento = p1.FechaDeNacimiento;
        auxp1.Tipo = p1.Tipo;
        auxp1.Salud = p1.Salud;
        auxp1.Fuerza = p1.Fuerza;
        auxp1.Destreza = p1.Destreza;
        auxp1.Velocidad = p1.Velocidad;
        auxp1.Energia = p1.Energia;
        auxp1.Armadura = p1.Armadura;

        auxp2.Nombre = p2.Nombre;
        auxp2.Apodo = p2.Apodo;
        auxp2.Edad = p2.Edad;
        auxp2.Nivel = p2.Nivel;
        auxp2.Especial = p2.Especial;
        auxp2.FechaDeNacimiento = p2.FechaDeNacimiento;
        auxp2.Tipo = p2.Tipo;
        auxp2.Salud = p2.Salud;
        auxp2.Fuerza = p2.Fuerza;
        auxp2.Destreza = p2.Destreza;
        auxp2.Velocidad = p2.Velocidad;
        auxp2.Energia = p2.Energia;
        auxp2.Armadura = p2.Armadura;
        //}
        EscribirMensaje("- Damos la bienvenida a todos a la Arena de Mad War!!...");
        Console.ReadKey();
        Console.Clear();
        // presentacion del anfitrion
        EscribirMensaje("- Hoy contemplaremos una pelea de 1 vs 1...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- Un combate a 5 ronda, con un solo ganador...");
        Console.ReadKey();
        Console.Clear();
        string aux = "- A mi izquierda tenemos a ..." + p1.Nombre.ToUpper() +", "+ p1.Apodo.ToUpper();
        EscribirMensaje(aux);
        aux = "- Del otro lado está ..." + p2.Nombre.ToUpper() +", "+ p2.Apodo.ToUpper();
        EscribirMensaje(aux);
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- AHORA... Demos inicio al combate en ...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 3...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 2...");
        Console.ReadKey();
        Console.Clear();
        EscribirMensaje("- 1... A PELEAR!!");
        Console.ReadKey();
        Console.Clear();

        int i=0;
        while(p1.Salud >0 && p2.Salud > 0 && i<6){

            if(p1.Velocidad>p2.Velocidad){
                AtaqueManual(p1,p2);
                if(p2.Salud>0){
                    Ataque(p2,p1, true);
                }
            }else{
                Ataque(p2,p1, true);
                if(p1.Salud>0){
                    AtaqueManual(p1,p2);
                }
            }
            Pasiva(p1);
            Pasiva(p2);
            i++;
        }
        if(p1.Salud<0 || p2.Salud<0){
            EscribirMensaje("- TENEMOS GANADOR!! Por un claro nocaut");
            Console.ReadKey();
            Console.Clear();
            if(p1.Salud>0){
                return auxp1;
            }else{
                return auxp2;
            }
        }else{
            EscribirMensaje("- Sorprendentemente ambos siguen en pie...");
            Console.ReadKey();
            Console.Clear();
            EscribirMensaje("- Pero los datos nos dan un solo ganador...");
            Console.ReadKey();
            Console.Clear();
            if(PorcentajeSalud(auxp1.Salud,p1.Salud)<PorcentajeSalud(auxp2.Salud,p2.Salud)){
                return auxp2;
            }else{
                return auxp2;
            }
        }
    }
    public float PorcentajeSalud(float SaludIni, float SaludFin){
        return ((SaludFin*100)/SaludIni);
    }
    public void AtaqueManual(Personaje p1, Personaje p2){
        int pos = 1, op = 0;
        ConsoleKeyInfo aux;
        float daño=0;
        string especial = p1.Centrar(p1.Especial+"(-4)",23);
        do{
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              ╔══════════╗                ║");
            Console.WriteLine("║              ║ TÚ TURNO ║                ║");
            Console.WriteLine("║              ╚══════════╝                ║");
            Console.WriteLine("║"+p1.Centrar("ENERGÍA: "+p1.Energia,42)+"║");
            Console.WriteLine("║      ┌───────────────────────────┐       ║");
            if(pos == 1){
                Console.WriteLine("║     »│ .      Atacar(-2)       . │«      ║");
            }else{
                Console.WriteLine("║      │ .      Atacar(-2)       . │       ║");
            }
            Console.WriteLine("║      ├───────────────────────────┤       ║");
            if(pos == 2){
                Console.WriteLine("║     »│ .     Defender(+2)      . │«      ║");
            }else{
                Console.WriteLine("║      │ .     Defender(+2)      . │       ║");
            }
            Console.WriteLine("║      ├───────────────────────────┤       ║");
            if(pos == 3){
                Console.WriteLine("║     »│ ."+especial+". │«      ║");
            }else{
                Console.WriteLine("║      │ ."+especial+". │       ║");
            }
            Console.WriteLine("║      └───────────────────────────┘       ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║                                          ║");
            Console.WriteLine("║         ©Copyright El PricuQuicu         ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            aux = Console.ReadKey();
            Console.Clear();
            if(aux.Key == ConsoleKey.Enter){
            switch (pos){
                case 1:
                    if(p1.Energia>1){
                        p1.Energia -=2;
                        daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad));
                        p2.Salud = p2.Salud - daño;
                    }
                    op = 1;
                    break;
                case 2:
                    p1.Armadura += 1;
                    p1.Energia +=2;
                    op = 2;
                    break;
                case 3:
                    if(p1.Energia>3){
                            if(p1.Especial == "Escudo protector" || p1.Especial == "Flecha anestésica" || p1.Especial == "Frío envolvente" || p1.Especial == "Vendas"){
                            p1.Energia -= 4;
                            p1.Armadura += 2; 
                            p1.Salud += 10;
                        }else{
                            daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad))*1.30f;
                            p2.Salud = p2.Salud - daño;
                            p1.Energia = p1.Energia - 4;
                        }
                    }
                    op = 3;
                    break;
            }
            }else if(aux.Key == ConsoleKey.DownArrow){
                pos++;
            }else if(aux.Key == ConsoleKey.UpArrow){
                pos--;
            }
            if(pos<1){
                pos = 1;
            }else if(pos>3){
                pos = 3;
            }
            Console.Clear();
        }while(op!= pos);
    }
    public void Ataque(Personaje p1, Personaje p2, bool comentarios){
        var valor = new Random();
        float daño;
        switch(valor.Next(1,11)){
            case 1://Ataque normal
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                if(p1.Energia>=2){
                    if(comentarios){
                        EscribirMensaje(p1.Nombre + ", hizo un ataque normal");
                    }
                    daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad));
                    p2.Salud = p2.Salud - daño;
                    p1.Energia = p1.Energia - 2;
                }else{
                    if(comentarios){
                        System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque normal");   
                    }
                }
                break;
            case 7://defensa
            case 8:
            case 9:
                p1.Armadura += 1;
                p1.Energia +=2;
                if(comentarios){
                    System.Console.WriteLine(p1.Nombre + ", aumentó su defensa");        
                }
                break;
            case 10://Habilidad especial
                if(p1.Energia>=4){
                    if(comentarios){   
                        System.Console.WriteLine(p1.Nombre + ", usó su habilidad especial");
                    }
                    if(p1.Especial == "Escudo protector" || p1.Especial == "Flecha anestésica" || p1.Especial == "Frío envolvente" || p1.Especial == "Vendas"){
                        p1.Energia -= 4;
                        p1.Armadura += 2; 
                        p1.Salud += 10;
                    }else{
                        daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad))*1.30f;
                        p2.Salud = p2.Salud - daño;
                        p1.Energia = p1.Energia - 4;
                    }
                }else{
                    if(comentarios){   
                        System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque especial");
                    }
                }
                break;
         }
    }
    public void Pasiva(Personaje p){
        var valor = new Random();
        if(valor.Next(1,6)==1){
            if(p.Tipo!=null){
                string tipo = p.Tipo.Split(",")[0];
                //System.Console.WriteLine(p1.Nombre + ", pudo usar su pasiva como "+ tipo);
                switch (tipo){
                    case "Humano":
                        p.Armadura += 1;
                        break;
                    case "Elfo":
                        p.Velocidad += 1;
                        break;
                    case "Orco":
                        p.Fuerza += 1;
                        break;
                    case "Muerto Viviente":
                        p.Salud += 10;
                        break;
                }
            }
        }
    }
    public Personaje CombateAuto(Personaje p1, Personaje p2){
        var valor = new Random();
        Personaje auxp1 = new Personaje(), auxp2 = new Personaje();
        auxp1.Nombre = p1.Nombre;
        auxp1.Apodo = p1.Apodo;
        auxp1.Edad = p1.Edad;
        auxp1.Nivel = p1.Nivel;
        auxp1.Especial = p1.Especial;
        auxp1.FechaDeNacimiento = p1.FechaDeNacimiento;
        auxp1.Tipo = p1.Tipo;
        auxp1.Salud = p1.Salud;
        auxp1.Fuerza = p1.Fuerza;
        auxp1.Destreza = p1.Destreza;
        auxp1.Velocidad = p1.Velocidad;
        auxp1.Energia = p1.Energia;
        auxp1.Armadura = p1.Armadura;

        auxp2.Nombre = p2.Nombre;
        auxp2.Apodo = p2.Apodo;
        auxp2.Edad = p2.Edad;
        auxp2.Nivel = p2.Nivel;
        auxp2.Especial = p2.Especial;
        auxp2.FechaDeNacimiento = p2.FechaDeNacimiento;
        auxp2.Tipo = p2.Tipo;
        auxp2.Salud = p2.Salud;
        auxp2.Fuerza = p2.Fuerza;
        auxp2.Destreza = p2.Destreza;
        auxp2.Velocidad = p2.Velocidad;
        auxp2.Energia = p2.Energia;
        auxp2.Armadura = p2.Armadura;

        while(p1.Salud>0 && p2.Salud>0){
            if(p1.Velocidad>p2.Velocidad){
                Ataque(p1,p2,false);
                if(p2.Salud>0){
                    Ataque(p2,p1,false);
                }
            }else{
                Ataque(p2,p1, false);
                if(p1.Salud>0){
                    Ataque(p1,p2, false);
                }
            }
            Pasiva(p1);
            Pasiva(p2);
        }
        if(p1.Salud>0){
            return auxp1;
        }else{
            return auxp2;
        }
    }
    public float DañoProvocado(Personaje p1, float defensa){
        float daño, ataque;
        var efectividad = new Random();
        int efe = efectividad.Next(1,101);
        ataque = p1.Fuerza * p1.Destreza * p1.Nivel;
        daño = ((ataque * efe)- defensa)/100;

        return daño;
    }
    public void Torneo(List<Personaje> competidores){
        int i =1, j;
        competidores = Sorteo(competidores);
        while(competidores.Count()>1){
            System.Console.WriteLine(i+"° Combates");
            i++;
            j=1;
            foreach (var item in competidores)
            {
                System.Console.WriteLine(" "+j+"- "+item.Nombre+", "+item.Apodo+"("+item.Tipo+")");
                if(j%2 == 0){
                    System.Console.WriteLine(" ");
                }
                j++;
            }
            competidores = Ganadores(competidores);
        }
        System.Console.WriteLine("EL GANADOR ES ");
        competidores[0].MostrarPersonaje();
    }
    public List<Personaje> Ganadores(List<Personaje> Competidores){
        var resultados = new List<Personaje>();
        while(Competidores.Count()>0){
            if(Competidores.Count()>1){
                resultados.Add(CombateAuto(Competidores[0],Competidores[1]));
                Competidores.Remove(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }else{
                resultados.Add(Competidores[0]);
                Competidores.Remove(Competidores[0]);
            }
        }
        return resultados;
    }
}
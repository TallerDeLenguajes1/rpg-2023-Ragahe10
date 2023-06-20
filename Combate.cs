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
    public Personaje Combate(Personaje p1, Personaje p2){
        var valor = new Random();
        float daño;
        Personaje auxp1 = p1, auxp2 = p2;
        int i = 1;
        while(p1.Salud>0 && p2.Salud>0){
            System.Console.WriteLine($"************************RONDA "+ i +"************************");
            i++;
            System.Console.WriteLine(p1.Nombre + ", " + p1.Apodo);
            System.Console.WriteLine(" - Salud: "+ p1.Salud);
            System.Console.WriteLine(" - Energía: "+ p1.Energia);
            System.Console.WriteLine("-------------------------------------------------");
            System.Console.WriteLine(p2.Nombre + ", " + p2.Apodo);
            System.Console.WriteLine(" - Salud: "+ p2.Salud);
            System.Console.WriteLine(" - Energía: "+ p2.Energia);
            System.Console.WriteLine("-------------------------------------------------");
            if(p1.Velocidad>p2.Velocidad){
                System.Console.WriteLine("TURNO DE " + p1.Nombre);
                switch(valor.Next(1,6)){
                    case 1://Ataque normal
                        if(p1.Energia>=2){
                            System.Console.WriteLine(p1.Nombre + ", hizo un ataque normal");
                            daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad));
                            p2.Salud = p2.Salud - daño;
                            p1.Energia = p1.Energia - 2;
                        }else{
                            System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque normal");
                        }
                        break;
                    case 2://defensa
                    case 3:
                    case 4:
                        p1.Armadura += 1;
                        p1.Energia +=2;
                        System.Console.WriteLine(p1.Nombre + ", aumentó su defensa");
                        break;
                    case 5://Habilidad especial
                        if(p1.Energia>=4){
                            System.Console.WriteLine(p1.Nombre + ", usó su habilidad especial");
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
                            System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque especial");
                        }
                        break;
                }
                if(p2.Salud>0){
                    switch(valor.Next(1,6)){
                        case 1://Ataque normal
                            if(p2.Energia>=2){
                                System.Console.WriteLine(p2.Nombre + ", hizo un ataque normal");
                                daño = DañoProvocado(p2,(p1.Armadura*p1.Velocidad));
                                p1.Salud = p1.Salud - daño;
                                p2.Energia = p2.Energia - 2;
                            }else{
                                System.Console.WriteLine(p2.Nombre + ", no tiene energias para su ataque normal");
                            }
                            break;
                        case 2://defensa
                        case 3:
                        case 4:
                            p2.Armadura += 1;
                            p2.Energia +=2;
                            System.Console.WriteLine(p2.Nombre + ", aumentó su defensa");
                            break;
                        case 5://Habilidad especial
                            if(p2.Energia>=4){
                                System.Console.WriteLine(p2.Nombre + ", usó su habilidad especial");
                                if(p2.Especial == "Escudo protector" || p2.Especial == "Flecha anestésica" || p2.Especial == "Frío envolvente" || p2.Especial == "Vendas"){
                                    p2.Energia -= 4;
                                    p2.Armadura += 2;
                                    p2.Salud += 10;
                                }else{
                                    daño = DañoProvocado(p2,(p1.Armadura*p1.Velocidad))*1.30f;
                                    p1.Salud = p1.Salud - daño;
                                    p2.Energia = p2.Energia - 4;
                                }
                            }else{
                                System.Console.WriteLine(p2.Nombre + ", no tiene energias para su ataque especial");
                            }
                            break;
                    }
                }
            }else{
                switch(valor.Next(1,6)){
                    case 1://Ataque normal
                        if(p2.Energia>=2){
                            System.Console.WriteLine(p2.Nombre + ", hizo un ataque normal");
                            daño = DañoProvocado(p2,(p1.Armadura*p1.Velocidad));
                            p1.Salud = p1.Salud - daño;
                            p2.Energia = p2.Energia - 2;
                        }else{
                            System.Console.WriteLine(p2.Nombre + ", no tiene energias para su ataque normal");
                        }
                        break;
                    case 2://defensa
                    case 3:
                    case 4:
                        p2.Armadura += 1;
                        p2.Energia +=2;
                        System.Console.WriteLine(p2.Nombre + ", aumentó su defensa");
                        break;
                    case 5://Habilidad especial
                        if(p2.Energia>=4){
                            System.Console.WriteLine(p2.Nombre + ", usó su habilidad especial");
                            if(p2.Especial == "Escudo protector" || p2.Especial == "Flecha anestésica" || p2.Especial == "Frío envolvente" || p2.Especial == "Vendas"){
                                p2.Energia -= 4;
                                p2.Armadura += 2;
                                p2.Salud += 10;
                            }else{
                                daño = DañoProvocado(p2,(p1.Armadura*p1.Velocidad))*1.30f;
                                p1.Salud = p1.Salud - daño;
                                p2.Energia = p2.Energia - 4;
                            }
                        }else{
                            System.Console.WriteLine(p2.Nombre + ", no tiene energias para su ataque especial");
                        }
                        break;
                }
                if(p1.Salud>0){
                    switch(valor.Next(1,6)){
                        case 1://Ataque normal
                            if(p1.Energia>=2){
                                System.Console.WriteLine(p1.Nombre + ", hizo un ataque normal");
                                daño = DañoProvocado(p1,(p2.Armadura*p2.Velocidad));
                                p2.Salud = p2.Salud - daño;
                                p1.Energia = p1.Energia - 2;
                            }else{
                                System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque normal");
                            }
                            break;
                        case 2://defensa
                        case 3:
                        case 4:
                            p1.Armadura += 1;
                            p1.Energia +=2;
                            System.Console.WriteLine(p1.Nombre + ", aumentó su defensa");
                            break;
                        case 5://Habilidad especial
                            if(p1.Energia>=4){
                                System.Console.WriteLine(p1.Nombre + ", usó su habilidad especial");
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
                                System.Console.WriteLine(p1.Nombre + ", no tiene energias para su ataque especial");
                            }
                            break;
                    }
                }
            }
            System.Console.WriteLine("******FIN DE LOS ATAQUES******");
            if(valor.Next(1,6)==1){
                if(p1.Tipo!=null){
                    string tipo = p1.Tipo.Split(",")[0];
                    System.Console.WriteLine(p1.Nombre + ", pudo usar su pasiva como "+ tipo);
                    switch (tipo){
                        case "Humano":
                            p1.Armadura += 1;
                            break;
                        case "Elfo":
                            p1.Velocidad += 1;
                            break;
                        case "Orco":
                            p1.Fuerza += 1;
                            break;
                        case "Muerto Viviente":
                            p1.Salud += 10;
                            break;
                    }
                }
            }
            if(valor.Next(1,6)==1){
                if(p2.Tipo!=null){
                    string tipo = p2.Tipo.Split(",")[0];
                    System.Console.WriteLine(p2.Nombre + ", pudo usar su pasiva como "+ tipo);
                    switch (tipo){
                        case "Humano":
                            p2.Armadura += 1;
                            break;
                        case "Elfo":
                            p2.Velocidad += 1;
                            break;
                        case "Orco":
                            p2.Fuerza += 1;
                            break;
                        case "Muerto Viviente":
                            p2.Salud += 10;
                            break;
                    }
                }
            }
            System.Console.WriteLine($"**********************FIN DE RONDA***********************");
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
        ataque = p1.Fuerza * p1.Destreza * p1.Nivel;

        daño = ((ataque * efectividad.Next(1,101))- defensa)/500;

        return daño;
    }
}
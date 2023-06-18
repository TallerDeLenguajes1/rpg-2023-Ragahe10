namespace EspacioPersonaje;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Personaje{
    //ATRIBUTOS
    //DATOS
    private string? tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fechaDeNacimiento;
    private int edad;
    //CARACTERISTICAS
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;
    //Propiedades de datos
    public string? Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value; }
    //Propiedades de Caracteristicas
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class FabricaDePersonaje{
    public string[] Nombres = {
        "Carlos",
        "Pepe",
        "Juan",
        "Colo",
        "Jose",
        "Rama",
        "Guillo",
        "Gaby",
        "Luciano",
        "Sergio"
    };
    public string[] Apodos = {
        "EL Tronco",
        "EL Oso",
        "EL Pato",
        "La Cabra",
        "EL Enano",
        "EL Fideo",
        "La Pulga",
        "EL Buitre",
        "La Neblina",
        "El Profe"
    };
    public string[] Tipos ={
        "Orco Luchador",
        "Orco Hechicero",
        "Orco Arquero",
        "Orco Sanador",
        "Humano Luchador",
        "Humano Hechicero",
        "Humano Arquero",
        "Humano Sanador",
        "Elfo Luchador",
        "Elfo Hechicero",
        "Elfo Arquero",
        "Elfo Sanador",
        "Luchador Muerto",
        "Hechicero Muerto",
        "Arquero Muerto",
        "Sanador Muerto"
    };
    public Personaje CrearPersonaje(){
        Personaje nuevo = new Personaje();
        Random valor = new Random();
        int anio = valor.Next(1723,2023);
        int mes = valor.Next(1,13);
        int dia;
        switch (mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                dia = valor.Next(1,32);
                break;
            case 2:
                dia = valor.Next(1,29);
                break;
            default:
                dia = valor.Next(1,31);
                break;
        }

        //Datos
        nuevo.Nombre = Nombres[valor.Next(0,9)];
        nuevo.Apodo = Apodos[valor.Next(0,9)];
        nuevo.Tipo = Tipos[valor.Next(0,16)];
        nuevo.FechaDeNacimiento = new DateTime(anio, mes, dia);
        nuevo.Edad = CalcularEdad(nuevo.FechaDeNacimiento);
        //Caracteristicas
        
        nuevo.Velocidad = valor.Next(1,11);
        nuevo.Destreza = valor.Next(1,6);
        nuevo.Fuerza = valor.Next(1,11);
        nuevo.Nivel = valor.Next(1,11);
        nuevo.Armadura = valor.Next(1,11);
        nuevo.Salud = 100;

        return  nuevo;
    }
    public  int CalcularEdad(DateTime fechaNacimiento)
    {
        DateTime fechaActual = DateTime.Now;
        int edad = fechaActual.Year - fechaNacimiento.Year;

        if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
        {
            edad--;
        }
        return edad;
    }
}

public class PersonajesJson{
    //serializacion
    public void GuardarPersonajes(List<Personaje> lista, string Nombre){
        string json ;
        //var config = new JsonSerializerOptions { WriteIndented = true };
        // foreach (var personaje in lista){
        //     json = json +"\n\r"+JsonSerializer.Serialize(personaje/*, config*/);
        // }
        json = JsonSerializer.Serialize(lista);
        File.WriteAllText(Nombre+".json",json);
    }
    //deserializacion
    public List<Personaje>? LeerPersonajes(string nombreArch){
        List<Personaje>? listPer = null;
        if(Existe(nombreArch)){
            string json = File.ReadAllText(nombreArch);
            listPer = JsonSerializer.Deserialize<List<Personaje>>(json);
        }
        return listPer;
    }
    public bool Existe(string nombreArch){
        return (File.Exists(nombreArch));
    }
}

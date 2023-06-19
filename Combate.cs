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
    
}
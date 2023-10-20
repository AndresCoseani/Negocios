using Negocios.MODELS;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Negocios
{
    class Program
    {
        //static NegocioContext Context;//todos los metodos son estaticos
        static void Main(string[] args)
        {
            var Context = new NegocioContext();
            Modificar();
        }
        static void Listar()
        {
            var Context = new NegocioContext();
            var query = from a in Context.Productos//a es alias de la tabla
                        where a.Stock > 0//traer todos los productos q tengan stock mayor a 100
                        orderby a.Id//ordena la tabla por ID
                        select a;//selecciona la tabla
            foreach (var Producto in query)//recorre la tabla
            {
                Console.WriteLine(Producto.Id + "-" + Producto.Nombre + "-" + Producto.Stock);
                //lista la id y el nombre
            }
        }
        static void Grabar()
        {
            var Context = new NegocioContext();//objeto para entrar a la base de datos

            var oProductos = new Producto();//productos para grabar la tabla
            oProductos.Nombre = "DISCO DURO";//graba en la tabla nombre
            oProductos.Stock = 115;//graba en la tabla stock
            Context.Add(oProductos);//agrega lo que se grabo a la tabla
            Context.SaveChanges();//guarda los cambios
        }
        static void Listar2()
        {
            var Context = new NegocioContext();
            foreach (var p in Context.Productos.ToList())//traer todas las columnas 
            {
                Console.WriteLine(p.Nombre);
            }
        }
        static void Eliminar()
        {
            var Context = new NegocioContext();

            var p = Context.Productos.Find((long)3);//Encuentra el producto 5
            Context.Remove(p);//Elimina el producto
            Context.SaveChanges();//Guarda los cambios
        }
        static void Modificar()
        { 
            var Context = new NegocioContext();
            var p = Context.Productos.Find((long)2);
            p.Nombre = "PROCESADOR";
            p.Stock = 500;
            Context.Entry(p).State = EntityState.Modified;//es para avisarle al entity q cambiaste un registro
            //se cambia el state por el entitystate
            Context.SaveChanges();
        }
    }
}

using ApiTiendaMascotas.Entities;
using ApiTiendaMascotas.ModeloBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTiendaMascotas.Models
{
    public class ProductosModel
    {

        public List<ProductoEnt> MostrarProductos()
        {
            using (var conexion = new ProyectoPAEntities())
            {
                List<ProductoEnt> respuesta = new List<ProductoEnt>();
                var datosBD = conexion.MostrarProductos().ToList();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new ProductoEnt()
                        {
                            idProducto = item.idProducto,
                            nombre = item.nombre,
                            //idTipoProducto = item.tipoProducto,
                            descripcion = item.descripcion,
                            cantidad = item.cantidad,
                            precio = item.precio,
                            descuento = item.descuento,
                            imagen = item.imagen
                        });
                    }
                }
                return respuesta;
            }
        }

        /*//TIPO PRODUCTO (ELIMINADO)
        public List<TipoProductoEnt> ConsultarProductos()
        {
            using (var conexion = new ProyectoPAEntities())
            {
                List<TipoProductoEnt> respuesta = new List<TipoProductoEnt>();
                var datosBD = (from x in conexion.TipoProductos
                               select x).ToList();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new TipoProductoEnt()
                        {
                            idTipoProducto = item.idTipoProducto,
                            TipoProducto = item.tipoProducto
                        });
                    }
                }
                return respuesta;
            }
        }*/


        public int RegistrarProducto(ProductoEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                return conexion.RegistrarProducto(entidad.nombre, entidad.descripcion, entidad.cantidad, entidad.precio, entidad.descuento, entidad.imagen);
            }
        }

    }


}

   
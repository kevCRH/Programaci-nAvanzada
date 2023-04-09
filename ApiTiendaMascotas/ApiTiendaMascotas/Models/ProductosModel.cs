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
                            descuento = (int)item.descuento,
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

        public ProductoEnt ConsultarProducto(long q)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                ProductoEnt respuesta = new ProductoEnt();
                var datosBD = (from x in conexion.Productos
                               where x.idProducto == q
                               select x).FirstOrDefault();
                if (datosBD != null)
                {
                    respuesta.idProducto = datosBD.idProducto;
                    respuesta.nombre = datosBD.nombre;
                    respuesta.descripcion = datosBD.descripcion;
                    respuesta.cantidad = datosBD.cantidad;
                    respuesta.precio = datosBD.precio;
                    respuesta.descuento = (int)datosBD.descuento;
                    respuesta.imagen = datosBD.imagen;
                }
                return respuesta;
            }
        }

        public void ActualizarProducto(ProductoEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Productos
                                 where x.idProducto == entidad.idProducto
                                 select x).FirstOrDefault();
                if (respuesta != null)
                {
                    respuesta.idProducto = entidad.idProducto;
                    respuesta.nombre = entidad.nombre;
                    respuesta.descripcion = entidad.descripcion;
                    respuesta.cantidad = entidad.cantidad;
                    respuesta.precio = entidad.precio;
                    respuesta.descuento = (int)entidad.descuento;
                    if (entidad.imagen != null)
                    {
                        respuesta.imagen = entidad.imagen;
                    }
                    conexion.SaveChanges();
                }
            }
        }

    }


}

   
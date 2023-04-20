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

        public void ActualizarCarrito(ProductoEnt entidad)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Carrito
                                 where x.idProducto == entidad.idProducto
                                    && x.ConsecutivoUsuario == entidad.ConsecutivoUsuario
                                 select x).FirstOrDefault();

                if (respuesta == null)
                {
                    //Insert
                    Carrito carrito = new Carrito();
                    carrito.idProducto = entidad.idProducto;
                    carrito.ConsecutivoUsuario = entidad.ConsecutivoUsuario;
                    carrito.Cantidad = entidad.cantidad;
                    carrito.Fecha = DateTime.Now;
                    conexion.Carrito.Add(carrito);
                    conexion.SaveChanges();
                }
                else
                {
                    if (entidad.cantidad == 0)
                    {
                        //Delete
                        conexion.Carrito.Remove(respuesta);
                        conexion.SaveChanges();
                    }
                    else
                    {
                        //Update
                        respuesta.Cantidad = entidad.cantidad;
                        respuesta.Fecha = DateTime.Now;
                        conexion.SaveChanges();
                    }
                }


            }
        }


        // Eliminar usando LinQ, por lo tanto no existe procedimiento en la DB, recibe el ID (q) desde el Productos
        // Controller y salva los cambios, una vez finaliza se devuelve al webapp ProductosController/EliminarProducto
        public void EliminarProducto(int q)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var respuesta = (from x in conexion.Productos
                                 where x.idProducto == q
                                 select x).FirstOrDefault();

                if (respuesta != null)
                {
                    conexion.Productos.Remove(respuesta);
                    conexion.SaveChanges();
                }
            }
        }

        public CompraEnt MostrarCompraCarrito(int idUsuario)
        {
            using (var conexion = new ProyectoPAEntities())
            {
                var datosBD = conexion.MostrarCompraCarrito(idUsuario).FirstOrDefault();

                CompraEnt respuesta = new CompraEnt();

                if (datosBD != null)
                {
                    respuesta.CantidadCompra = datosBD.CantidadCompra;
                    respuesta.MontoCompra = datosBD.MontoCompra;
                }

                return respuesta;
            }
        }

        public List<DetalleComprasEnt> MostrarDetalleCarrito(int idUsuario)
        {
            using (var conexion = new ProyectoPAEntities())
            {

                var datosBD = conexion.MostrarDetalleCarrito(idUsuario).ToList();

                List<DetalleComprasEnt> respuesta = new List<DetalleComprasEnt>();

                if (datosBD.Count > 0)
                {
                    foreach (var item in datosBD)
                    {
                        respuesta.Add(new DetalleComprasEnt
                        {
                            Nombre = item.Nombre,
                            Cantidad = item.Cantidad,
                            Precio = item.Precio,
                            SubTotal = item.SubTotal,
                            Impuesto = item.Impuesto,
                            Total = item.Total
                        });
                    }
                }

                return respuesta;
            }
        }

    }


}

   
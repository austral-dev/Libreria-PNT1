using libreria_PNT1.Models;
using System;


public class Cliente
{
    public string IdCliente { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    private string Contrasena { get; set; } = string.Empty;

    public void Registrar(string id, string nom, string ape, string mail, string password)
    {
        IdCliente = id;
        Nombre = nom;
        Apellido = ape;
        Email = mail;
        Contrasena = password;
    }

    public void ActualizarDatos()
    {
        //TODO: Implementar el método ActualizarDatos
        //
        // Lógica para actualizar la información del cliente
    }

    // Asociación unidireccional con Carrito (Cardinalidad 1)
    // Se recomienda inicializar el Carrito en el constructor o al registrarse.
    public Carrito Carrito { get; set; }

    // Asociación con HistorialPedido (Cardinalidad 1..n, implementada con una lista)
    public List<HistorialPedido> Historial { get; set; }

    public Cliente()
    {
        Historial = new List<HistorialPedido>();
        Carrito = new Carrito(this); // Asumiendo que Carrito se inicializa con el cliente
    }
}
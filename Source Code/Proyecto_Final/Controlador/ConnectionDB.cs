﻿using Npgsql;
using System;
using System.Data;

namespace Proyecto_Final.Controlador
{
    public static class ConnectionDB
    {
        private static string host = "127.0.0.1",
            database = "ProyectoFinal_ArkanoidDB",
            userId = "postgres",
            password = "uca";

        private static string sConnection =
            $"Host={host};Port=5432;User Id={userId};Password={password};Database={database};";

        // Metodo de consultas para la DB
        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            DataSet ds = new DataSet();
            connection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);
            connection.Close();
            return ds.Tables[0];
        }

        // Metodo para ejecutar comandos de acciones en la DB
        public static void ExecuteNonQuery(string act)
        {
            Console.WriteLine(sConnection);
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

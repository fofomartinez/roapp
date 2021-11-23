using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Roapp.Modelo;
using Roapp.Servicios;


namespace Roapp.VistasModelo
{
    public class VMhistorico
    {
        List<Mhistorico> historico = new List<Mhistorico>();

        public async Task <List<Mhistorico>> mostrar_historico()
        {
            var data = await Conexionfirebase.firebase
                .Child("Historico")
                //.OrderByKey()
                .OnceAsync<Mhistorico>();

            foreach ( var rdr in data)
            {
                Mhistorico parametros = new Mhistorico();
                parametros.Id_transaccion = rdr.Key;
                parametros.Fecha = rdr.Object.Fecha;
                parametros.Ubicacion = rdr.Object.Ubicacion;
                parametros.Tipo = rdr.Object.Tipo;

                historico.Add(parametros);

            }

            return historico;
        }

        public async Task insertar_historico(Mhistorico parametros)
        {
            await Conexionfirebase.firebase
                .Child("Historico")
                .PostAsync(new Mhistorico()
                {
                    Fecha = parametros.Fecha,
                    Ubicacion = parametros.Ubicacion,
                    Tipo = parametros.Tipo
                });
        }
    }
}
